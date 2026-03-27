using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class HierarchyOrganizer : EditorWindow
{
    [MenuItem("Tools/Organize ASL Hierarchy")]
    public static void Organize()
    {
        GameObject manager = GameObject.Find("[System_GestureManager]");
        if (manager == null)
        {
            manager = new GameObject("[System_GestureManager]");
        }

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);
        List<GameObject> poseCanvases = new List<GameObject>();

        foreach (var obj in allObjects)
        {
            if (obj.name == "Pose Canvas")
            {
                poseCanvases.Add(obj);
            }
        }

        bool trackersMoved = false;

        foreach (var canvas in poseCanvases)
        {
            string topicName = canvas.transform.parent ? canvas.transform.parent.name : "Unknown";
            Debug.Log($"Processing Pose Canvas for topic: {topicName}");

            Transform gestures = canvas.transform.Find("Gestures");
            if (gestures != null)
            {
                gestures.SetParent(manager.transform);
                gestures.name = "Gestures_" + topicName;
                Debug.Log($"Moved and renamed Gestures for {topicName}");
            }

            Transform leftTracker = canvas.transform.Find("Left Hand Gesture Detection");
            Transform rightTracker = canvas.transform.Find("Right Hand Gesture Detection");

            if (!trackersMoved)
            {
                if (leftTracker != null) { leftTracker.SetParent(manager.transform); }
                if (rightTracker != null) { rightTracker.SetParent(manager.transform); }
                trackersMoved = true;
                Debug.Log($"Moved primary trackers from {topicName}");
            }
            else
            {
                if (leftTracker != null) { GameObject.DestroyImmediate(leftTracker.gameObject); }
                if (rightTracker != null) { GameObject.DestroyImmediate(rightTracker.gameObject); }
                Debug.Log($"Destroyed redundant trackers from {topicName}");
            }

            // Cleanup the now empty canvas if it's not being used for other things
            // (Assumed based on user request to centralize "all objects in Pose Canvas/Gestures")
            // GameObject.DestroyImmediate(canvas); 
        }

        Debug.Log("ASL Hierarchy Organization Complete!");
    }
}