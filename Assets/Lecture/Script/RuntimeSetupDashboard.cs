using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteAlways]
public class RuntimeSetupDashboard : MonoBehaviour
{
    private void Start()
    {
        if (Application.isPlaying) return;

        Debug.Log("Starting Automated Setup for Progress System...");

        // 1. Setup Progress Manager
        GameObject managersObj = GameObject.Find("[System_GestureManager]");
        if (managersObj == null)
            managersObj = new GameObject("[Managers]");
        
        ProgressManager progressManager = managersObj.GetComponent<ProgressManager>();
        if (progressManager == null)
            progressManager = managersObj.AddComponent<ProgressManager>();

        ClassroomManager[] classrooms = GameObject.FindObjectsOfType<ClassroomManager>();
        if (classrooms.Length > 0)
            progressManager.classrooms = new System.Collections.Generic.List<ClassroomManager>(classrooms); 
            
        progressManager.gestureTopicController = GameObject.FindObjectOfType<GestureTopicController>();

        // 3. Create Wrist Dashboard
        GameObject leftController = GameObject.Find("Left Controller");
        GameObject dashboardObj = GameObject.Find("WristDashboardCanvas");

        if (leftController != null && dashboardObj == null)
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

            // Generate Buttons
            if (progressManager.gestureTopicController != null && progressManager.gestureTopicController.topics != null)
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
        
        Debug.Log("UI Generation Complete!");
        
        // Destroy the object we added this script to, to clean up.
        // Needs a delay or invoke to avoid DestroyImmediate running inside layout/Start loop.
        // Actually since it's just a setup obj, let's just leave it empty and rename it so the user can delete it.
        this.gameObject.name = "DeleteThisObj_SetupDone";
        // Remove the component so it doesn't run again.
        DestroyImmediate(this);
    }
}
