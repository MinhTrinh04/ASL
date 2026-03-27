using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Samples.GestureSample;
using System.Collections.Generic;
using System.Reflection;

public class AmbidextrousSetup : EditorWindow
{
    [MenuItem("Tools/Finalize ASL Gesture Setup")]
    public static void Setup()
    {
        GameObject manager = GameObject.Find("[System_GestureManager]");
        if (manager == null) { Debug.LogError("Manager '[System_GestureManager]' not found!"); return; }

        GestureHub hub = manager.GetComponent<GestureHub>();
        GestureTopicController topicCtrl = manager.GetComponent<GestureTopicController>();
        
        Transform leftT = manager.transform.Find("Left Hand Gesture Detection");
        Transform rightT = manager.transform.Find("Right Hand Gesture Detection");

        if (leftT == null || rightT == null) { Debug.LogError("Trackers not found under manager!"); return; }
        GameObject leftTracker = leftT.gameObject;
        GameObject rightTracker = rightT.gameObject;

        // 1. Setup Topic Controller
        topicCtrl.topics.Clear();
        Transform poseCanvas = manager.transform.Find("Pose Canvas");
        if (poseCanvas == null) { Debug.LogError("Pose Canvas not found under manager!"); return; }

        foreach (Transform child in poseCanvas)
        {
            if (child.name.StartsWith("Gestures_"))
            {
                topicCtrl.topics.Add(new GestureTopicController.TopicGroup { 
                    topicName = child.name.Replace("Gestures_", ""), 
                    gestureGroupObject = child.gameObject 
                });
                Debug.Log($"Found Topic: {child.name}");
            }
        }

        // 2. Setup Individual Gestures
        foreach (var topic in topicCtrl.topics)
        {
            if (topic.gestureGroupObject == null) continue;
            GameObject groupObj = topic.gestureGroupObject;
            Debug.Log($"--- Processing Topic Group: {topic.topicName} ---");
            
            // Step 2a: Process Static Poses (Recursive)
            StaticHandGesture[] allStatic = groupObj.GetComponentsInChildren<StaticHandGesture>(true);
            HashSet<GameObject> processedObjects = new HashSet<GameObject>();

            foreach (var sample in allStatic)
            {
                if (sample == null) continue;
                GameObject gestureObj = sample.gameObject;
                if (processedObjects.Contains(gestureObj)) continue;
                processedObjects.Add(gestureObj);

                StaticHandGesture[] existingOnObject = gestureObj.GetComponents<StaticHandGesture>();
                
                // Capture state
                var first = existingOnObject[0];
                var asset = first.handShapeOrPose;
                Image bg = first.background;
                Image hl = first.highlight;
                float hold = first.minimumHoldTime;
                float interval = first.gestureDetectionInterval;

                // UI Recovery
                if (bg == null) bg = gestureObj.GetComponent<Image>();
                if (hl == null) {
                    Transform t = gestureObj.transform.Find("HighlightOutline") ?? gestureObj.transform.Find("Highlight");
                    if (t != null) hl = t.GetComponent<Image>();
                }
                if (hold <= 0) hold = 0.2f;
                if (interval <= 0) interval = 0.1f;

                if (asset == null) continue;

                // Duplicate Ambidextrous
                UnityEditorInternal.ComponentUtility.CopyComponent(first);
                foreach(var c in existingOnObject) { DestroyImmediate(c); }

                // Add Proxy ONLY if not part of a dynamic sequence
                bool isSubPose = gestureObj.GetComponentInParent<DynamicGesture>() != null;
                GestureTrigger trigger = null;
                if (!isSubPose)
                {
                    trigger = gestureObj.GetComponent<GestureTrigger>();
                    if (trigger == null) trigger = gestureObj.AddComponent<GestureTrigger>();
                    trigger.gestureID = gestureObj.name;
                }

                // Paste Right
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gestureObj);
                var compsR = gestureObj.GetComponents<StaticHandGesture>();
                var rightComp = compsR[compsR.Length - 1];
                rightComp.handTrackingEvents = rightTracker.GetComponent<XRHandTrackingEvents>();
                rightComp.background = bg;
                rightComp.highlight = hl;
                rightComp.minimumHoldTime = hold;
                rightComp.gestureDetectionInterval = interval;
                
                // Paste Left
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gestureObj);
                var compsL = gestureObj.GetComponents<StaticHandGesture>();
                var leftComp = compsL[compsL.Length - 1];
                leftComp.handTrackingEvents = leftTracker.GetComponent<XRHandTrackingEvents>();
                leftComp.background = bg;
                leftComp.highlight = hl;
                leftComp.minimumHoldTime = hold;
                leftComp.gestureDetectionInterval = interval;

                // Bind if not sub-pose
                if (trigger != null)
                {
                    UnityEventTools.AddVoidPersistentListener(rightComp.gesturePerformed, trigger.Trigger);
                    UnityEventTools.AddVoidPersistentListener(leftComp.gesturePerformed, trigger.Trigger);
                    UnityEventTools.AddVoidPersistentListener(rightComp.gestureEnded, trigger.TriggerEnded);
                    UnityEventTools.AddVoidPersistentListener(leftComp.gestureEnded, trigger.TriggerEnded);
                }

                Debug.Log($"Configured Static Gesture: {gestureObj.name} (Sub-Pose: {isSubPose})");
            }

            // Step 2b: Process Dynamic Sequences
            DynamicGesture[] allDynamic = groupObj.GetComponentsInChildren<DynamicGesture>(true);
            foreach (var dyn in allDynamic)
            {
                GameObject gestureObj = dyn.gameObject;
                
                // Recover Private UI References via Reflection
                FieldInfo bgField = typeof(DynamicGesture).GetField("m_Background", BindingFlags.NonPublic | BindingFlags.Instance);
                FieldInfo hlField = typeof(DynamicGesture).GetField("m_Highlight", BindingFlags.NonPublic | BindingFlags.Instance);

                Image bg = bgField?.GetValue(dyn) as Image;
                Image hl = hlField?.GetValue(dyn) as Image;

                if (bg == null)
                {
                    bg = gestureObj.GetComponent<Image>();
                    bgField?.SetValue(dyn, bg);
                }
                if (hl == null)
                {
                    Transform t = gestureObj.transform.Find("HighlightOutline") ?? gestureObj.transform.Find("Highlight");
                    if (t != null) hl = t.GetComponent<Image>();
                    hlField?.SetValue(dyn, hl);
                }

                // Add Proxy
                var trigger = gestureObj.GetComponent<GestureTrigger>();
                if (trigger == null) trigger = gestureObj.AddComponent<GestureTrigger>();
                trigger.gestureID = gestureObj.name;

                // Bind Events
                while(dyn.DynamicGestureDetected.GetPersistentEventCount() > 0)
                    UnityEventTools.RemovePersistentListener(dyn.DynamicGestureDetected, 0);
                while(dyn.DynamicGestureEnded.GetPersistentEventCount() > 0)
                    UnityEventTools.RemovePersistentListener(dyn.DynamicGestureEnded, 0);

                UnityEventTools.AddVoidPersistentListener(dyn.DynamicGestureDetected, trigger.Trigger);
                UnityEventTools.AddVoidPersistentListener(dyn.DynamicGestureEnded, trigger.TriggerEnded);

                // Setup Aliases for Numbers 11-19
                dyn.openPoseIDs.Clear();
                dyn.closedPoseIDs.Clear();
                
                string dName = gestureObj.name;
                if (dName == "11" || dName == "12" || dName == "13" || dName == "14" || dName == "15")
                {
                    dyn.openPoseIDs.Add(dName + " Start");
                    dyn.openPoseIDs.Add("10"); // Alias
                    dyn.closedPoseIDs.Add(dName + " End");
                    dyn.closedPoseIDs.Add((int.Parse(dName)-10).ToString()); // Unit Digit Alias (e.g., "3" for "13")
                }
                else if (dName == "16" || dName == "17" || dName == "18" || dName == "19")
                {
                    // 16-19 are often the base number (6-9) flicked or shaken
                    string baseNum = (int.Parse(dName)-10).ToString();
                    dyn.openPoseIDs.Add(baseNum);
                    dyn.closedPoseIDs.Add(dName); // Usually name itself is the dynamic target
                }
                else if (dName == "Goodbye")
                {
                    dyn.openPoseIDs.Add("Goodbye Open");
                    dyn.closedPoseIDs.Add("Goodbye Close");
                }
                else if (dName == "Thank you")
                {
                    dyn.openPoseIDs.Add("Thank you start");
                    dyn.closedPoseIDs.Add("Thank you end");
                }
                
                EditorUtility.SetDirty(dyn);
                Debug.Log($"Configured Dynamic Gesture: {gestureObj.name} (UI: FIXED, Aliases: {dyn.openPoseIDs.Count})");
            }
        }

        EditorUtility.SetDirty(manager);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(manager.scene);
        Debug.Log("Ambidextrous Gesture Setup Finalized!");
    }
}