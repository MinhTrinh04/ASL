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
    public bool showVisualTrail = true;

    [Header("References")]
    public XRHandTrackingEvents handTrackingEvents; // Left or Right hand
    public LineRenderer lineRenderer;
    public Transform playerCamera;

    private bool isDrawing = false;
    private List<Vector3> worldPoints = new List<Vector3>();
    private VRMagicUnistroke.Template template;
    private GestureHub gestureHub;

    private bool IsTrailEnabled => showVisualTrail && (gestureHub == null || gestureHub.showVisualTrail);

    void Start()
    {
        gestureHub = FindObjectOfType<GestureHub>();
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

        if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
            lineRenderer.positionCount = 0;
            
            if (IsTrailEnabled)
            {
                lineRenderer.startWidth = 0.01f;
                lineRenderer.endWidth = 0.005f;
                
                // ALWAYS assign a material that supports vertex color
                Shader spritesShader = Shader.Find("Sprites/Default");
                if (spritesShader != null)
                {
                    lineRenderer.material = new Material(spritesShader);
                }
                
                Color neonColor = gestureID == "J" ? Color.cyan : Color.magenta;
                lineRenderer.startColor = neonColor;
                lineRenderer.endColor = neonColor;
                lineRenderer.useWorldSpace = true;
            }
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
                StartDrawing();
            }
            RecordPoint(args);
        }
        else if (isDrawing)
        {
            StopDrawingAndEvaluate();
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;
        worldPoints.Clear();
        if (lineRenderer != null && IsTrailEnabled)
        {
            lineRenderer.positionCount = 0;
            lineRenderer.enabled = true;
            
            // Reset color back to original neon color in case it was green from last success
            Color neonColor = gestureID == "J" ? Color.cyan : Color.magenta;
            lineRenderer.startColor = neonColor;
            lineRenderer.endColor = neonColor;
        }
    }

    private void RecordPoint(XRHandJointsUpdatedEventArgs args)
    {
        // Use Index Tip for tracing
        var joint = args.hand.GetJoint(XRHandJointID.IndexTip);
        if (joint.TryGetPose(out Pose pose))
        {
            Vector3 point = pose.position;
            
            if (playerCamera == null && Camera.main != null)
            {
                playerCamera = Camera.main.transform;
            }

            // Convert coordinate from local tracking space to World Space
            Vector3 worldPoint = point;
            if (playerCamera != null)
            {
                if (playerCamera.parent != null)
                {
                    worldPoint = playerCamera.parent.TransformPoint(point);
                }
                else
                {
                    worldPoint = playerCamera.TransformPoint(point);
                }
            }

            // Only add if it moved enough (using world space distance)
            if (worldPoints.Count > 0)
            {
                if (Vector3.Distance(worldPoints[worldPoints.Count - 1], worldPoint) < pointDistanceMin)
                {
                    return;
                }
            }
            
            worldPoints.Add(worldPoint);

            if (lineRenderer != null && IsTrailEnabled)
            {
                lineRenderer.positionCount = worldPoints.Count;
                lineRenderer.SetPosition(worldPoints.Count - 1, worldPoint);
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
            // Log removed for noise reduction

            if (score >= matchThreshold)
            {
                GestureHub.Publish(gestureID);
                
                // Show green feedback on success
                if (lineRenderer != null && IsTrailEnabled)
                {
                    lineRenderer.startColor = Color.green;
                    lineRenderer.endColor = Color.green;
                }
                
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
