using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Samples.GestureSample;
using System.Collections.Generic;

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

        // 1. Setup Topic Controller (Search under Pose Canvas)
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

        // 2. Setup Individual Gestures (RECURSIVE)
        foreach (var topic in topicCtrl.topics)
        {
            if (topic.gestureGroupObject == null) continue;
            GameObject groupObj = topic.gestureGroupObject;
            Debug.Log($"--- Processing Topic Group: {topic.topicName} ---");
            
            // Step 2a: Process all StaticHandGesture in the hierarchy
            StaticHandGesture[] allStatic = groupObj.GetComponentsInChildren<StaticHandGesture>(true);
            HashSet<GameObject> processedObjects = new HashSet<GameObject>();

            foreach (var oldComp in allStatic)
            {
                if (oldComp == null) continue; // Skip if already destroyed by previous iteration on same object
                GameObject gestureObj = oldComp.gameObject;
                if (processedObjects.Contains(gestureObj)) continue;
                processedObjects.Add(gestureObj);

                StaticHandGesture[] existingOnObject = gestureObj.GetComponents<StaticHandGesture>();

                // Capture required references from the FIRST one found
                var sample = existingOnObject[0];
                var asset = sample.handShapeOrPose;
                Image bg = sample.background;
                Image hl = sample.highlight;
                float hold = sample.minimumHoldTime;
                float interval = sample.gestureDetectionInterval;

                // AUTO-RECOVERY: Nếu các Image bị null, tìm lại theo cấu trúc chuẩn
                if (bg == null) bg = gestureObj.GetComponent<Image>();
                if (hl == null) {
                    Transform t = gestureObj.transform.Find("HighlightOutline") ?? gestureObj.transform.Find("Highlight");
                    if (t != null) hl = t.GetComponent<Image>();
                }
                if (hold <= 0) hold = 0.2f;
                if (interval <= 0) interval = 0.1f;

                if (asset == null) {
                    Debug.LogWarning($"Skipping {gestureObj.name} - handShapeOrPose asset is null.");
                    continue;
                }

                // Copy state chuẩn để nhân bản
                UnityEditorInternal.ComponentUtility.CopyComponent(sample);
                
                // Xoá sạch các bản lỗi cũ
                foreach(var c in existingOnObject) { DestroyImmediate(c); }

                // Add GestureTrigger Proxy nếu chưa có
                var trigger = gestureObj.GetComponent<GestureTrigger>();
                if (trigger == null) trigger = gestureObj.AddComponent<GestureTrigger>();
                trigger.gestureID = gestureObj.name;

                // Add Right Hand Component
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gestureObj);
                var compsR = gestureObj.GetComponents<StaticHandGesture>();
                var rightComp = compsR[compsR.Length - 1];
                rightComp.handTrackingEvents = rightTracker.GetComponent<XRHandTrackingEvents>();
                rightComp.background = bg;
                rightComp.highlight = hl;
                rightComp.minimumHoldTime = hold;
                rightComp.gestureDetectionInterval = interval;
                
                // Add Left Hand Component
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(gestureObj);
                var compsL = gestureObj.GetComponents<StaticHandGesture>();
                var leftComp = compsL[compsL.Length - 1];
                leftComp.handTrackingEvents = leftTracker.GetComponent<XRHandTrackingEvents>();
                leftComp.background = bg;
                leftComp.highlight = hl;
                leftComp.minimumHoldTime = hold;
                leftComp.gestureDetectionInterval = interval;

                // Sync Internal UnityEvents
                var field = typeof(StaticHandGesture).GetField("m_GesturePerformed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (field != null) {
                    if (field.GetValue(rightComp) == null) field.SetValue(rightComp, new UnityEngine.Events.UnityEvent());
                    if (field.GetValue(leftComp) == null) field.SetValue(leftComp, new UnityEngine.Events.UnityEvent());
                }
                var fieldEnd = typeof(StaticHandGesture).GetField("m_GestureEnded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (fieldEnd != null) {
                    if (fieldEnd.GetValue(rightComp) == null) fieldEnd.SetValue(rightComp, new UnityEngine.Events.UnityEvent());
                    if (fieldEnd.GetValue(leftComp) == null) fieldEnd.SetValue(leftComp, new UnityEngine.Events.UnityEvent());
                }

                // Bind Event qua Proxy (Trigger & TriggerEnded)
                UnityEventTools.AddVoidPersistentListener(rightComp.gesturePerformed, trigger.Trigger);
                UnityEventTools.AddVoidPersistentListener(leftComp.gesturePerformed, trigger.Trigger);
                UnityEventTools.AddVoidPersistentListener(rightComp.gestureEnded, trigger.TriggerEnded);
                UnityEventTools.AddVoidPersistentListener(leftComp.gestureEnded, trigger.TriggerEnded);

                Debug.Log($"Configured Static Gesture: {gestureObj.name}");
            }

            // Step 2b: Process all DynamicGesture in the hierarchy
            DynamicGesture[] allDynamic = groupObj.GetComponentsInChildren<DynamicGesture>(true);
            foreach (var dyn in allDynamic)
            {
                var gestureObj = dyn.gameObject;
                var trigger = gestureObj.GetComponent<GestureTrigger>();
                if (trigger == null) trigger = gestureObj.AddComponent<GestureTrigger>();
                trigger.gestureID = gestureObj.name;

                // Bind Dynamic Events to Proxy
                // Note: Clear existing listeners to avoid duplicates if re-run
                while(dyn.DynamicGestureDetected.GetPersistentEventCount() > 0)
                    UnityEventTools.RemovePersistentListener(dyn.DynamicGestureDetected, 0);
                while(dyn.DynamicGestureEnded.GetPersistentEventCount() > 0)
                    UnityEventTools.RemovePersistentListener(dyn.DynamicGestureEnded, 0);

                UnityEventTools.AddVoidPersistentListener(dyn.DynamicGestureDetected, trigger.Trigger);
                UnityEventTools.AddVoidPersistentListener(dyn.DynamicGestureEnded, trigger.TriggerEnded);
                
                Debug.Log($"Configured Dynamic Gesture: {gestureObj.name}");
            }
        }

        EditorUtility.SetDirty(manager);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(manager.scene);
        Debug.Log("Ambidextrous Gesture Setup Finalized!");
    }
}