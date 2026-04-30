using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public static class RefineWristDashboard
{
    [MenuItem("Tools/Rebuild Full Wrist Dashboard")]
    public static void Execute()
    {
        // 1. Dọn dẹp bản cũ nếu có
        string[] targets = { "WristRoot", "WristCanvas", "WristDashboardContainer" };
        foreach (var name in targets)
        {
            GameObject old = GameObject.Find(name);
            while (old != null) { Object.DestroyImmediate(old); old = GameObject.Find(name); }
        }

        GameObject leftHand = GameObject.Find("XR Origin/Camera Offset/Left Hand");
        if (leftHand == null)
        {
            Debug.LogError("Không tìm thấy Left Hand. Bạn cần có XR Origin trong Scene.");
            return;
        }

        // 2. Tạo Gốc Bám Tay (WristRoot)
        GameObject wristRoot = new GameObject("WristRoot");
        wristRoot.transform.SetParent(leftHand.transform, false);
        
        WristFollower follower = wristRoot.AddComponent<WristFollower>();
        follower.targetWrist = leftHand.transform;
        follower.localPositionOffset = new Vector3(0, 0.05f, -0.05f);
        follower.localRotationOffset = new Vector3(90, 0, 0); // Ngửa mặt lên cổ tay

        // 3. Tạo Canvas Chung
        GameObject canvasObj = new GameObject("WristSharedCanvas");
        canvasObj.transform.SetParent(wristRoot.transform, false);
        Canvas c = canvasObj.AddComponent<Canvas>();
        c.renderMode = RenderMode.WorldSpace;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<UnityEngine.XR.Interaction.Toolkit.UI.TrackedDeviceGraphicRaycaster>();
        
        RectTransform rtCanvas = canvasObj.GetComponent<RectTransform>();
        rtCanvas.sizeDelta = new Vector2(400, 500);
        rtCanvas.localScale = Vector3.one * 0.0006f; // Kích thước thật trên tay

        // 4. Tạo Nút Bấm Đồng Hồ (WatchButton)
        GameObject btnObj = new GameObject("WatchButton");
        btnObj.transform.SetParent(canvasObj.transform, false);
        Image btnImg = btnObj.AddComponent<Image>();
        btnImg.color = new Color(0.2f, 0.6f, 1f, 1f); // Xanh dương
        Button toggleBtn = btnObj.AddComponent<Button>();
        
        RectTransform rtBtn = btnObj.GetComponent<RectTransform>();
        rtBtn.sizeDelta = new Vector2(80, 80);
        rtBtn.anchoredPosition = new Vector2(0, -200); // Đặt ở mép dưới

        // Text cho nút
        GameObject btnTextObj = new GameObject("Text");
        btnTextObj.transform.SetParent(btnObj.transform, false);
        TMPro.TextMeshProUGUI btnText = btnTextObj.AddComponent<TMPro.TextMeshProUGUI>();
        btnText.text = "MENU";
        btnText.fontSize = 24;
        btnText.alignment = TMPro.TextAlignmentOptions.Center;
        btnText.color = Color.white;
        btnTextObj.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);

        // 5. Tạo Dashboard Panel (Menu Chính)
        GameObject panelObj = new GameObject("DashboardPanel");
        panelObj.transform.SetParent(canvasObj.transform, false);
        Image panelImg = panelObj.AddComponent<Image>();
        panelImg.color = new Color(0.1f, 0.1f, 0.1f, 0.95f); // Nền đen mờ
        
        RectTransform rtPanel = panelObj.GetComponent<RectTransform>();
        rtPanel.sizeDelta = new Vector2(350, 400);
        rtPanel.anchoredPosition = new Vector2(0, 50); // Nằm trên nút MENU

        UnityEngine.UI.VerticalLayoutGroup layout = panelObj.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
        layout.padding = new RectOffset(20, 20, 20, 20);
        layout.spacing = 20;
        layout.childAlignment = TextAnchor.UpperCenter;
        layout.childControlHeight = false;
        layout.childForceExpandHeight = false;

        // Tiêu đề Menu
        GameObject titleObj = new GameObject("Title");
        titleObj.transform.SetParent(panelObj.transform, false);
        TMPro.TextMeshProUGUI titleTxt = titleObj.AddComponent<TMPro.TextMeshProUGUI>();
        titleTxt.text = "LEARNING DASHBOARD";
        titleTxt.fontSize = 28;
        titleTxt.fontStyle = TMPro.FontStyles.Bold;
        titleTxt.alignment = TMPro.TextAlignmentOptions.Center;
        titleObj.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 40);

        // Thêm Script UI
        WristDashboardUI dashboardUI = wristRoot.AddComponent<WristDashboardUI>();
        dashboardUI.targetMenu = panelObj;
        UnityEditor.Events.UnityEventTools.AddPersistentListener(toggleBtn.onClick, dashboardUI.ToggleDashboard);

        // 6. Tạo 3 Nút Bài Học tự động
        string[] topics = { "Alphabets", "Numbers", "Greetings" };
        var slots = new System.Collections.Generic.List<WristDashboardUI.TopicUIElements>();

        foreach (string t in topics)
        {
            GameObject topicBtnObj = new GameObject(t + "_Button");
            topicBtnObj.transform.SetParent(panelObj.transform, false);
            Image tImg = topicBtnObj.AddComponent<Image>();
            tImg.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            Button tBtn = topicBtnObj.AddComponent<Button>();
            topicBtnObj.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 80);

            // Tên bài học
            GameObject nameObj = new GameObject("NameText");
            nameObj.transform.SetParent(topicBtnObj.transform, false);
            TMPro.TextMeshProUGUI nameTxt = nameObj.AddComponent<TMPro.TextMeshProUGUI>();
            nameTxt.text = t;
            nameTxt.fontSize = 26;
            nameTxt.alignment = TMPro.TextAlignmentOptions.Left;
            RectTransform rtName = nameObj.GetComponent<RectTransform>();
            rtName.anchorMin = new Vector2(0, 0); rtName.anchorMax = new Vector2(1, 1);
            rtName.offsetMin = new Vector2(20, 0); rtName.offsetMax = new Vector2(0, 0);

            // Điểm số
            GameObject scoreObj = new GameObject("ScoreText");
            scoreObj.transform.SetParent(topicBtnObj.transform, false);
            TMPro.TextMeshProUGUI scoreTxt = scoreObj.AddComponent<TMPro.TextMeshProUGUI>();
            scoreTxt.text = "0/0";
            scoreTxt.fontSize = 22;
            scoreTxt.alignment = TMPro.TextAlignmentOptions.Right;
            scoreTxt.color = Color.yellow;
            RectTransform rtScore = scoreObj.GetComponent<RectTransform>();
            rtScore.anchorMin = new Vector2(0, 0); rtScore.anchorMax = new Vector2(1, 1);
            rtScore.offsetMin = new Vector2(0, 0); rtScore.offsetMax = new Vector2(-60, 0);

            // Khóa
            GameObject lockObj = new GameObject("LockIcon");
            lockObj.transform.SetParent(topicBtnObj.transform, false);
            Image lockIcon = lockObj.AddComponent<Image>();
            lockIcon.color = Color.red;
            RectTransform rtLock = lockObj.GetComponent<RectTransform>();
            rtLock.anchorMin = new Vector2(1, 0.5f); rtLock.anchorMax = new Vector2(1, 0.5f);
            rtLock.sizeDelta = new Vector2(30, 40);
            rtLock.anchoredPosition = new Vector2(-30, 0);

            WristDashboardUI.TopicUIElements element = new WristDashboardUI.TopicUIElements();
            element.selectionButton = tBtn;
            element.topicNameText = nameTxt;
            element.scoreText = scoreTxt;
            element.lockImage = lockIcon;
            element.unlockedColor = new Color(0.3f, 0.6f, 0.3f, 1f);
            element.lockedColor = new Color(0.3f, 0.3f, 0.3f, 1f);
            element.masteredColor = new Color(0.8f, 0.6f, 0.1f, 1f);
            slots.Add(element);
        }

        dashboardUI.topicSlots = slots;

        // 7. Progress Manager
        if (GameObject.Find("ProgressManager") == null)
        {
            GameObject pmObj = new GameObject("ProgressManager");
            pmObj.AddComponent<ProgressManager>();
        }

        Selection.activeGameObject = wristRoot;
        Debug.Log("Tạo mới hoàn toàn Menu cổ tay thành công!");
    }
}
