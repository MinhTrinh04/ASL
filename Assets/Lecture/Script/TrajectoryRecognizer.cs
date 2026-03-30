using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;
using System.Collections.Generic;

public class VRMagicTrajectory : MonoBehaviour
{
    [Header("Configuration")]
    public string gestureID; // e.g. "J" or "Z"
    public XRHandShape baseHandShape; // The shape to hold to start drawing
    public float matchThreshold = 0.3f;
    public float pointDistanceMin = 0.01f; // 1cm

    [Header("References")]
    public XRHandTrackingEvents handTrackingEvents; // Left or Right hand
    public LineRenderer lineRenderer;
    public Transform playerCamera;

    private bool isDrawing = false;
    private List<Vector3> worldPoints = new List<Vector3>();
    private VRMagicUnistroke.Template template;

    void Start()
    {
        if (playerCamera == null && Camera.main != null)
        {
            playerCamera = Camera.main.transform;
        }

        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Initialize template
        if (gestureID == "J")
        {
            template = new VRMagicUnistroke.Template("J", new List<VRMagicUnistroke.Point>()
            {
                new VRMagicUnistroke.Point(50, 100),
                new VRMagicUnistroke.Point(50, 0),
                new VRMagicUnistroke.Point(50, -50),
                new VRMagicUnistroke.Point(25, -100),
                new VRMagicUnistroke.Point(-25, -100),
                new VRMagicUnistroke.Point(-50, -50),
                new VRMagicUnistroke.Point(-50, 0)
            });
        }
        else if (gestureID == "Z")
        {
            template = new VRMagicUnistroke.Template("Z", new List<VRMagicUnistroke.Point>()
            {
                new VRMagicUnistroke.Point(-100, 100),
                new VRMagicUnistroke.Point(100, 100),
                new VRMagicUnistroke.Point(-100, -100),
                new VRMagicUnistroke.Point(100, -100)
            });
        }

        if (handTrackingEvents != null)
        {
            handTrackingEvents.jointsUpdated.AddListener(OnJointsUpdated);
        }
    }

    void OnDestroy()
    {
        if (handTrackingEvents != null)
        {
            handTrackingEvents.jointsUpdated.RemoveListener(OnJointsUpdated);
        }
    }

    private void OnJointsUpdated(XRHandJointsUpdatedEventArgs args)
    {
        if (baseHandShape == null) return;
        if (handTrackingEvents == null) return;

        bool shapeMatch = baseHandShape.CheckConditions(args);

        if (shapeMatch)
        {
            if (!isDrawing)
            {
                Debug.Log($"[VRMagicTrajectory] '{gestureID}' Shape Match Started ({handTrackingEvents.handedness}). Drawing...");
                StartDrawing();
            }
            RecordPoint(args);
        }
        else if (isDrawing)
        {
            Debug.Log($"[VRMagicTrajectory] '{gestureID}' Shape Match Ended. Evaluating {worldPoints.Count} points...");
            StopDrawingAndEvaluate();
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;
        worldPoints.Clear();
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
            lineRenderer.enabled = true;
        }
    }

    private void RecordPoint(XRHandJointsUpdatedEventArgs args)
    {
        // Use Index Tip for tracing
        var joint = args.hand.GetJoint(XRHandJointID.IndexTip);
        if (joint.TryGetPose(out Pose pose))
        {
            Vector3 point = pose.position;
            
            // Only add if it moved enough
            if (worldPoints.Count > 0)
            {
                if (Vector3.Distance(worldPoints[worldPoints.Count - 1], point) < pointDistanceMin)
                {
                    return;
                }
            }
            
            worldPoints.Add(point);

            if (lineRenderer != null)
            {
                lineRenderer.positionCount = worldPoints.Count;
                lineRenderer.SetPosition(worldPoints.Count - 1, point);
            }
        }
    }

    private void StopDrawingAndEvaluate()
    {
        isDrawing = false;
        
        if (worldPoints.Count > 10 && template != null)
        {
            // Project world points to Camera local space to get 2D points
            List<VRMagicUnistroke.Point> points2D = new List<VRMagicUnistroke.Point>();
            foreach (var wp in worldPoints)
            {
                Vector3 localPoint = playerCamera.InverseTransformPoint(wp);
                // localPoint.x and localPoint.y represent the 2D plane looking from the camera
                points2D.Add(new VRMagicUnistroke.Point(localPoint.x, localPoint.y));
            }

            float score = VRMagicUnistroke.Recognize(points2D, template);
            Debug.Log($"[VRMagicTrajectory] Gesture '{gestureID}' score: {score:F2}");

            if (score >= matchThreshold)
            {
                Debug.Log($"[VRMagicTrajectory] SUCCESS! Gesture '{gestureID}' published.");
                GestureHub.Publish(gestureID);
                
                // Keep the trail for a moment then clear
                Invoke(nameof(ClearTrail), 1.0f);
            }
            else
            {
                ClearTrail();
            }
        }
        else
        {
            ClearTrail();
        }
    }

    private void ClearTrail()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
            lineRenderer.enabled = false;
        }
    }
}
