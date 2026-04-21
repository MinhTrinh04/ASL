using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SetupWatchButton : EditorWindow
{
    [MenuItem("Tools/ASL/Setup Floating Watch Button")]
    public static void SetupButton()
    {
        Debug.Log("Generating Floating Watch Button...");

        // Find targets
        GameObject leftController = GameObject.Find("Left Hand");
        if (leftController == null)
        {
            Debug.LogError("Setup failed: Could not find 'Left Hand'.");
            return;
        }

        GameObject dashboardObj = GameObject.Find("WristDashboardCanvas");
        if (dashboardObj == null)
        {
            Debug.LogError("Setup failed: 'WristDashboardCanvas' not found. Ensure the Dashboard is generated first.");
            return;
        }
        
        WristDashboardUI targetUI = dashboardObj.GetComponent<WristDashboardUI>();
        
        // Hide dashboard by default
        dashboardObj.SetActive(false);

        // Find or create WatchToggleCanvas
        GameObject watchObj = GameObject.Find("WatchToggleCanvas");
        if (watchObj != null)
        {
            DestroyImmediate(watchObj);
        }

        watchObj = new GameObject("WatchToggleCanvas");
        watchObj.transform.SetParent(leftController.transform, false);

        Canvas canvas = watchObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        RectTransform rect = watchObj.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(40, 40); // small button
        rect.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        rect.localPosition = new Vector3(0f, 0.05f, 0f); // adjust to wrist
        rect.localEulerAngles = new Vector3(90f, 0f, 0f); // face up when wrist is horizontal

        watchObj.AddComponent<GraphicRaycaster>(); // Allows poke/raycast to hit it

        // Button Background
        Image bgImg = watchObj.AddComponent<Image>();
        bgImg.color = new Color(0.2f, 0.6f, 1f, 0.9f); // Blueish

        // Unity UI Button
        Button btn = watchObj.AddComponent<Button>();
        
        // Hook up persistent listener directly to Dashboard Toggle
        if (targetUI != null)
        {
            UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityAction(targetUI.ToggleDashboard));
        }

        // Add Text child
        GameObject txtObj = new GameObject("Text");
        txtObj.transform.SetParent(watchObj.transform, false);
        TextMeshProUGUI txt = txtObj.AddComponent<TextMeshProUGUI>();
        txt.text = "Menu";
        txt.color = Color.white;
        txt.alignment = TextAlignmentOptions.Center;
        txt.enableAutoSizing = true;
        txt.fontSizeMin = 8;
        txt.fontSizeMax = 16;
        txt.fontStyle = FontStyles.Bold;

        RectTransform textRect = txt.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = Vector2.zero;

        Debug.Log("Floating Watch Button generated successfully on the Left Controller!");
    }
}
