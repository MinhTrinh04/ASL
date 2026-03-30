using UnityEngine;
using UnityEditor;

public class AddVRMagicTrajectorys
{
    [MenuItem("Tools/Setup Trajectories")]
    public static void Setup()
    {
        var hands = GameObject.FindObjectsOfType<UnityEngine.XR.Hands.XRHandTrackingEvents>();
        
        SetupObject("J", hands, "Assets/HandShapePose/Alphabet/I/I.asset");
        SetupObject("Z", hands, "Assets/HandShapePose/Alphabet/X/X.asset");
    }

    private static void SetupObject(string name, UnityEngine.XR.Hands.XRHandTrackingEvents[] hands, string shapePath)
    {
        var obj = GameObject.Find(name);
        if (obj == null) return;

        // Remove existing to refresh
        var existing = obj.GetComponents<VRMagicTrajectory>();
        foreach (var e in existing) GameObject.DestroyImmediate(e);

        var shape = AssetDatabase.LoadAssetAtPath<UnityEngine.XR.Hands.Gestures.XRHandShape>(shapePath);
        var cam = Camera.main != null ? Camera.main.transform : null;
        
        var lr = obj.GetComponent<LineRenderer>();
        if (lr == null)
        {
            lr = obj.AddComponent<LineRenderer>();
            lr.startWidth = 0.01f;
            lr.endWidth = 0.005f;
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.startColor = name == "J" ? Color.cyan : Color.magenta;
            lr.endColor = Color.white;
            lr.useWorldSpace = true;
        }

        foreach (var hand in hands)
        {
            var t = obj.AddComponent<VRMagicTrajectory>();
            t.gestureID = name;
            t.baseHandShape = shape;
            t.handTrackingEvents = hand;
            t.playerCamera = cam;
            t.matchThreshold = 0.3f;
            t.lineRenderer = lr;
            Debug.Log($"Added VRMagicTrajectory ({hand.name}) to {name} with threshold 0.3");
        }
    }
}