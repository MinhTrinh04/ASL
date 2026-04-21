using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class ProgressSystemSetup : EditorWindow
{
    [MenuItem("Tools/ASL/Setup Progress And Dashboard")]
    public static void Setup()
    {
        Debug.Log("Starting Automated Setup for Progress System...");

        // 1. Setup Progress Manager
        GameObject managersObj = GameObject.Find("[System_GestureManager]");
        if (managersObj == null)
        {
            managersObj = new GameObject("[Managers]");
        }
        
        ProgressManager progressManager = managersObj.GetComponent<ProgressManager>();
        if (progressManager == null)
        {
            progressManager = managersObj.AddComponent<ProgressManager>();
        }

        // 2. Try to find the required existing controllers
        ClassroomManager[] classrooms = GameObject.FindObjectsOfType<ClassroomManager>();
        // Assuming we want to manage the first one found, or all of them. But typically there's a main ClassroomManager.
        // Actually, the user has 3 ClassroomManagers: Numbers, Greetings, Alphabets...
        // If there are multiple ClassroomManagers, my script might need to handle them differently.
        // But for ProgressManager, let's link the first one to avoid nulls, but warn if many.
        if (classrooms.Length > 0)
        {
            progressManager.classrooms = new System.Collections.Generic.List<ClassroomManager>(classrooms);
        }
        progressManager.gestureTopicController = GameObject.FindObjectOfType<GestureTopicController>();

        // 3. Create Wrist Dashboard
        GameObject leftController = GameObject.Find("Left Hand");
        if (leftController == null)
        {
            Debug.LogError("Setup failed: Could not find 'Left Hand' in the scene.");
            return;
        }

        GameObject dashboardObj = GameObject.Find("WristDashboardCanvas");
        if (dashboardObj == null)
        {
            dashboardObj = new GameObject("WristDashboardCanvas");
            dashboardObj.transform.SetParent(leftController.transform, false);
            
            Canvas canvas = dashboardObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            
            RectTransform rect = dashboardObj.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(300, 400);
            rect.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            rect.localPosition = new Vector3(0.05f, 0.1f, 0f);
            rect.localEulerAngles = new Vector3(45f, 90f, 0f);

            CanvasScaler scaler = dashboardObj.AddComponent<CanvasScaler>();
            scaler.dynamicPixelsPerUnit = 10;

            // Background Panel
            GameObject bgObj = new GameObject("BG_Panel");
            bgObj.transform.SetParent(dashboardObj.transform, false);
            Image bgImg = bgObj.AddComponent<Image>();
            bgImg.color = new Color(0.1f, 0.1f, 0.15f, 0.9f);
            RectTransform bgRect = bgObj.GetComponent<RectTransform>();
            bgRect.anchorMin = Vector2.zero;
            bgRect.anchorMax = Vector2.one;
            bgRect.sizeDelta = Vector2.zero;

            // Layout
            GameObject layoutObj = new GameObject("TopicsLayout");
            layoutObj.transform.SetParent(dashboardObj.transform, false);
            RectTransform layoutRect = layoutObj.AddComponent<RectTransform>();
            layoutRect.anchorMin = new Vector2(0.05f, 0.05f);
            layoutRect.anchorMax = new Vector2(0.95f, 0.95f);
            layoutRect.sizeDelta = Vector2.zero;

            VerticalLayoutGroup vlg = layoutObj.AddComponent<VerticalLayoutGroup>();
            vlg.childControlHeight = true;
            vlg.childControlWidth = true;
            vlg.childForceExpandHeight = false;
            vlg.spacing = 10;

            // Add script
            WristDashboardUI uiScript = dashboardObj.AddComponent<WristDashboardUI>();
            uiScript.dashboardPanel = layoutObj; // Content panel to toggle
            uiScript.topicSlots = new System.Collections.Generic.List<WristDashboardUI.TopicUIElements>();

            // Generate Buttons based on Gestures
            if (progressManager.gestureTopicController != null)
            {
                var topics = progressManager.gestureTopicController.topics;
                for (int i = 0; i < topics.Count; i++)
                {
                    GameObject btnObj = new GameObject("Btn_Topic_" + i);
                    btnObj.transform.SetParent(layoutObj.transform, false);
                    Image btnImg = btnObj.AddComponent<Image>();
                    Button btn = btnObj.AddComponent<Button>();

                    GameObject txtObj = new GameObject("Text");
                    txtObj.transform.SetParent(btnObj.transform, false);
                    TextMeshProUGUI txt = txtObj.AddComponent<TextMeshProUGUI>();
                    txt.text = topics[i].topicName;
                    txt.color = Color.white;
                    txt.alignment = TextAlignmentOptions.Center;
                    txt.enableAutoSizing = true;
                    txt.fontSizeMin = 14;
                    txt.fontSizeMax = 24;

                    RectTransform textRect = txt.GetComponent<RectTransform>();
                    textRect.anchorMin = Vector2.zero;
                    textRect.anchorMax = Vector2.one;
                    textRect.sizeDelta = Vector2.zero;

                    LayoutElement layoutElem = btnObj.AddComponent<LayoutElement>();
                    layoutElem.minHeight = 50;

                    WristDashboardUI.TopicUIElements element = new WristDashboardUI.TopicUIElements();
                    element.selectionButton = btn;
                    element.topicNameText = txt;
                    element.lockedColor = Color.gray;
                    element.unlockedColor = Color.white;
                    element.masteredColor = new Color(0.2f, 0.8f, 0.2f);
                    
                    uiScript.topicSlots.Add(element);
                }
            }
        }

        Debug.Log("Setup Complete! Please manually verify references in ProgressManager and ClassroomManagers.");
    }
}
