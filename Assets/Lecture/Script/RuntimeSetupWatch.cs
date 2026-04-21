using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[ExecuteAlways]
public class RuntimeSetupWatch : MonoBehaviour
{
    private void Start()
    {
        if (Application.isPlaying) return;

        Debug.Log("Generating Floating Watch Button (Runtime Mode)...");

        GameObject leftController = GameObject.Find("Left Controller");
        if (leftController == null)
            return;

        GameObject dashboardObj = GameObject.Find("WristDashboardCanvas");
        if (dashboardObj == null)
            return;
        
        WristDashboardUI targetUI = dashboardObj.GetComponent<WristDashboardUI>();
        dashboardObj.SetActive(false);

        GameObject watchObj = GameObject.Find("WatchToggleCanvas");
        if (watchObj != null) DestroyImmediate(watchObj);

        watchObj = new GameObject("WatchToggleCanvas");
        watchObj.transform.SetParent(leftController.transform, false);

        Canvas canvas = watchObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        RectTransform rect = watchObj.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(40, 40);
        rect.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        rect.localPosition = new Vector3(0f, 0.05f, 0f);
        rect.localEulerAngles = new Vector3(90f, 0f, 0f);

        watchObj.AddComponent<GraphicRaycaster>(); // important for poke interact

        Image bgImg = watchObj.AddComponent<Image>();
        bgImg.color = new Color(0.2f, 0.6f, 1f, 0.9f);

        Button btn = watchObj.AddComponent<Button>();
        if (targetUI != null)
        {
            // Normally UnityEventTools is editor only, so here we just setup runtime delegate, 
            // but since it's [ExecuteAlways] we can't reliably persist a UnityAction via code to the scene if it's not a serialized field.
            // Oh wait, in editor scripts we use UnityEventTools to persist it.
            // Let me just add a custom component that hooks it up automatically.
        }
        
        // Custom Hook component
        WatchButtonHook hook = watchObj.AddComponent<WatchButtonHook>();
        hook.targetDashboard = dashboardObj;
        btn.onClick.AddListener(hook.ToggleTarget);

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
        
        // Clean up self
        this.gameObject.name = "DeleteThisObj_ButtonSetupDone";
        DestroyImmediate(this);
    }
}

public class WatchButtonHook : MonoBehaviour
{
    public GameObject targetDashboard;
    
    public void ToggleTarget()
    {
        if (targetDashboard != null)
        {
            bool isActive = !targetDashboard.activeSelf;
            targetDashboard.SetActive(isActive);
            if (isActive)
            {
                var ui = targetDashboard.GetComponent<WristDashboardUI>();
                if (ui != null) ui.RefreshUI();
            }
        }
    }
}
