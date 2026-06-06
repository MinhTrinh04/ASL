using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Samples.GestureSample;
using UnityEditor.SceneManagement;
using TMPro;
using UnityEditor.Events;
using UnityEngine.Events;

public class LobbySetupHelper : EditorWindow
{
    [MenuItem("Tools/Setup Lobby Scene")]
    public static void SetupLobby()
    {
        Debug.Log("[LobbySetupHelper] Starting Lobby Scene setup...");

        // 1. Find [System_GestureManager]
        GameObject gestureManager = GameObject.Find("[System_GestureManager]");
        if (gestureManager == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find [System_GestureManager] in the scene!");
            return;
        }

        // Get ProgressManager
        ProgressManager progressManager = gestureManager.GetComponent<ProgressManager>();
        if (progressManager == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find ProgressManager component on [System_GestureManager]!");
            return;
        }

        // Get Left and Right Hand Gesture Detection components
        XRHandTrackingEvents leftHandEvents = null;
        XRHandTrackingEvents rightHandEvents = null;

        var trackingEventsList = gestureManager.GetComponentsInChildren<XRHandTrackingEvents>(true);
        foreach (var trackingEvents in trackingEventsList)
        {
            if (trackingEvents.gameObject.name.Contains("Left"))
            {
                leftHandEvents = trackingEvents;
            }
            else if (trackingEvents.gameObject.name.Contains("Right"))
            {
                rightHandEvents = trackingEvents;
            }
        }

        if (leftHandEvents == null || rightHandEvents == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find left or right hand XRHandTrackingEvents under [System_GestureManager]!");
            return;
        }

        // 2. Setup SpawnPoint_Lobby
        GameObject spawnPointLobby = GameObject.Find("SpawnPoint_Lobby");
        if (spawnPointLobby == null)
        {
            spawnPointLobby = new GameObject("SpawnPoint_Lobby");
            spawnPointLobby.transform.position = new Vector3(0.75f, 1.008f, -10.0f);
            spawnPointLobby.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Debug.Log("[LobbySetupHelper] Created SpawnPoint_Lobby.");
        }
        else
        {
            Debug.Log("[LobbySetupHelper] Reusing existing SpawnPoint_Lobby.");
        }

        // 3. Setup Gestures_Lobby under Pose Canvas
        Transform poseCanvas = gestureManager.transform.Find("Pose Canvas");
        if (poseCanvas == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find 'Pose Canvas' child under [System_GestureManager]!");
            return;
        }

        Transform gesturesLobbyTransform = poseCanvas.Find("Gestures_Lobby");
        GameObject gesturesLobby;
        if (gesturesLobbyTransform == null)
        {
            gesturesLobby = new GameObject("Gestures_Lobby");
            gesturesLobby.transform.SetParent(poseCanvas, false);
            Debug.Log("[LobbySetupHelper] Created Gestures_Lobby GameObject under Pose Canvas.");
        }
        else
        {
            gesturesLobby = gesturesLobbyTransform.gameObject;
            Debug.Log("[LobbySetupHelper] Reusing existing Gestures_Lobby GameObject.");
            // Clear existing children to recreate them
            int childCount = gesturesLobby.transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject.DestroyImmediate(gesturesLobby.transform.GetChild(i).gameObject);
            }
            Debug.Log("[LobbySetupHelper] Cleared old children under Gestures_Lobby.");
        }

        // Make sure it has a RectTransform
        RectTransform lobbyRT = gesturesLobby.GetComponent<RectTransform>();
        if (lobbyRT == null)
        {
            lobbyRT = gesturesLobby.AddComponent<RectTransform>();
        }
        // Match siblings' typical rect parameters
        lobbyRT.anchoredPosition3D = new Vector3(-451.01f, 481.01f, 0f);
        lobbyRT.sizeDelta = Vector2.zero;
        lobbyRT.anchorMin = new Vector2(0.5f, 0.5f);
        lobbyRT.anchorMax = new Vector2(0.5f, 0.5f);
        lobbyRT.pivot = new Vector2(0.5f, 0.5f);
        lobbyRT.localRotation = Quaternion.identity;
        lobbyRT.localScale = Vector3.one;

        // 4. Create the three gestures
        string[] gestureNames = { "1", "Hello", "A" };
        string[] assetPaths = {
            "Assets/HandShapePose/Numbers/1/1.asset",
            "Assets/HandShapePose/Greeting/Hello/Hello Pose.asset",
            "Assets/HandShapePose/Alphabet/A/A.asset"
        };

        Sprite backgroundSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Samples/XR Hands/1.4.3/Gestures/Debug Tools/Sprites/RoundedCornerBackground.png");

        for (int i = 0; i < gestureNames.Length; i++)
        {
            string name = gestureNames[i];
            string path = assetPaths[i];

            ScriptableObject poseAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            if (poseAsset == null)
            {
                Debug.LogError($"[LobbySetupHelper] Could not load pose/shape asset at path: {path} for gesture {name}!");
                continue;
            }

            GameObject gestureObj = new GameObject(name);
            gestureObj.transform.SetParent(gesturesLobby.transform, false);

            RectTransform rt = gestureObj.AddComponent<RectTransform>();
            rt.localPosition = Vector3.zero;
            rt.sizeDelta = new Vector2(80f, 80f);
            rt.anchorMin = new Vector2(0.5f, 0.5f);
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.localRotation = Quaternion.identity;
            rt.localScale = Vector3.one;

            gestureObj.AddComponent<CanvasRenderer>();
            Image image = gestureObj.AddComponent<Image>();
            image.sprite = backgroundSprite;
            image.type = Image.Type.Sliced;
            image.color = new Color(0f, 0f, 0f, 0.749f);
            image.raycastTarget = false;

            GestureTrigger trigger = gestureObj.AddComponent<GestureTrigger>();
            trigger.gestureID = name;

            // Right Hand
            StaticHandGesture rightGesture = gestureObj.AddComponent<StaticHandGesture>();
            rightGesture.handTrackingEvents = rightHandEvents;
            rightGesture.handShapeOrPose = poseAsset;
            rightGesture.background = image;
            rightGesture.minimumHoldTime = 0.2f;
            rightGesture.gestureDetectionInterval = 0.1f;

            // Left Hand
            StaticHandGesture leftGesture = gestureObj.AddComponent<StaticHandGesture>();
            leftGesture.handTrackingEvents = leftHandEvents;
            leftGesture.handShapeOrPose = poseAsset;
            leftGesture.background = image;
            leftGesture.minimumHoldTime = 0.2f;
            leftGesture.gestureDetectionInterval = 0.1f;

            Debug.Log($"[LobbySetupHelper] Created gesture detector for '{name}' successfully.");
        }

        // 5. Find TeleportationProvider
        var teleportationProvider = GameObject.FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider>(true);
        if (teleportationProvider == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find TeleportationProvider in the scene!");
            return;
        }

        // 6. Assign ProgressManager references
        progressManager.lobbySpawnPoint = spawnPointLobby.transform;
        progressManager.lobbyGestureGroup = gesturesLobby;
        progressManager.teleportProvider = teleportationProvider;
        progressManager.defaultTopicIndex = -1; // -1 means start in Lobby

        EditorUtility.SetDirty(progressManager);
        
        // Save scene
        EditorSceneManager.SaveOpenScenes();
        Debug.Log("[LobbySetupHelper] Lobby Scene Setup Complete and Scene Saved successfully!");
    }

    [MenuItem("Tools/Setup Wrist Dashboard")]
    public static void SetupWristDashboard()
    {
        Debug.Log("[LobbySetupHelper] Configuring Wrist Dashboard...");

        // 1. Find DashboardPanel
        GameObject dashboardPanel = GameObject.Find("DashboardPanel");
        if (dashboardPanel == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find DashboardPanel in the scene!");
            return;
        }

        RectTransform panelRT = dashboardPanel.GetComponent<RectTransform>();
        if (panelRT == null)
        {
            Debug.LogError("[LobbySetupHelper] DashboardPanel does not have a RectTransform!");
            return;
        }

        // Adjust VerticalLayoutGroup spacing
        VerticalLayoutGroup layoutGroup = dashboardPanel.GetComponent<VerticalLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.spacing = 12f;
            layoutGroup.padding.top = 20;
            layoutGroup.padding.bottom = 20;
            layoutGroup.padding.left = 20;
            layoutGroup.padding.right = 20;
        }

        // Set overall scale and size (highly compact!)
        panelRT.localScale = new Vector3(0.82f, 0.82f, 0.82f);
        panelRT.sizeDelta = new Vector2(350f, 380f);
        Debug.Log("[LobbySetupHelper] Updated DashboardPanel localScale and reduced height to 380.");

        // 2. Adjust existing classroom buttons height to 60
        string[] classroomButtonNames = { "Alphabets_Button", "Numbers_Button", "Greetings_Button" };
        foreach (var btnName in classroomButtonNames)
        {
            GameObject btnObj = GameObject.Find(btnName);
            if (btnObj != null)
            {
                RectTransform rt = btnObj.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.sizeDelta = new Vector2(300f, 60f);
                }
            }
        }
        Debug.Log("[LobbySetupHelper] Shrunk classroom buttons height to 60.");

        // 3. Find Greetings_Button to use as template for Lobby_Button
        GameObject greetingsButton = GameObject.Find("Greetings_Button");
        if (greetingsButton == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find Greetings_Button to use as a template!");
            return;
        }

        // 4. Check for existing Lobby_Button and clear
        Transform existingLobbyButton = dashboardPanel.transform.Find("Lobby_Button");
        if (existingLobbyButton != null)
        {
            GameObject.DestroyImmediate(existingLobbyButton.gameObject);
            Debug.Log("[LobbySetupHelper] Removed existing Lobby_Button to rebuild.");
        }

        // 5. Duplicate Greetings_Button
        GameObject lobbyButton = GameObject.Instantiate(greetingsButton);
        lobbyButton.name = "Lobby_Button";
        lobbyButton.transform.SetParent(dashboardPanel.transform, false);
        Debug.Log("[LobbySetupHelper] Duplicated Greetings_Button to create Lobby_Button.");

        // Adjust Lobby_Button height to 60
        RectTransform lobbyButtonRT = lobbyButton.GetComponent<RectTransform>();
        if (lobbyButtonRT != null)
        {
            lobbyButtonRT.sizeDelta = new Vector2(300f, 60f);
        }

        // 6. Refine Lobby_Button children
        // NameText (Centered and styled)
        Transform nameTextTransform = lobbyButton.transform.Find("NameText");
        if (nameTextTransform != null)
        {
            TMP_Text tmp = nameTextTransform.GetComponent<TMP_Text>();
            if (tmp != null)
            {
                tmp.text = "Main Lobby";
                tmp.color = Color.white;
                tmp.alignment = TextAlignmentOptions.Center;
            }

            RectTransform textRT = nameTextTransform.GetComponent<RectTransform>();
            if (textRT != null)
            {
                textRT.anchorMin = Vector2.zero;
                textRT.anchorMax = Vector2.one;
                textRT.offsetMin = Vector2.zero;
                textRT.offsetMax = Vector2.zero;
                textRT.anchoredPosition3D = Vector3.zero;
                textRT.sizeDelta = Vector2.zero;
            }
        }

        // Destroy ScoreText (Lobby doesn't have score)
        Transform scoreTextTransform = lobbyButton.transform.Find("ScoreText");
        if (scoreTextTransform != null)
        {
            GameObject.DestroyImmediate(scoreTextTransform.gameObject);
        }

        // Destroy LockIcon (Lobby is never locked)
        Transform lockIconTransform = lobbyButton.transform.Find("LockIcon");
        if (lockIconTransform != null)
        {
            GameObject.DestroyImmediate(lockIconTransform.gameObject);
        }

        // 7. Configure Button component
        Button button = lobbyButton.GetComponent<Button>();
        if (button != null)
        {
            button.interactable = true;

            // Clear old click events
            button.onClick = new Button.ButtonClickedEvent();

            // Set background color to standard bright VR Blue/Cyan
            Image buttonImage = lobbyButton.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = new Color(0f, 0.627f, 1f, 1.0f); // Bright VR Blue
            }

            // Reset normalColor transitions
            ColorBlock cb = button.colors;
            cb.normalColor = Color.white;
            button.colors = cb;

            // Bind click event to WristDashboardUI.OnLobbySelected
            WristDashboardUI dashboardUI = GameObject.FindObjectOfType<WristDashboardUI>(true);
            if (dashboardUI != null)
            {
                UnityEventTools.AddPersistentListener(button.onClick, new UnityAction(dashboardUI.OnLobbySelected));
                Debug.Log("[LobbySetupHelper] Bound Lobby_Button click event to WristDashboardUI.OnLobbySelected.");
            }
            else
            {
                Debug.LogWarning("[LobbySetupHelper] WristDashboardUI script not found in scene; could not bind event!");
            }
        }

        EditorUtility.SetDirty(dashboardPanel);
        EditorSceneManager.SaveOpenScenes();
        Debug.Log("[LobbySetupHelper] Wrist Dashboard Refinement Complete and Scene Saved successfully!");
    }

    [MenuItem("Tools/Disable Poke Displacers")]
    public static void DisablePokeDisplacers()
    {
        Debug.Log("[LobbySetupHelper] Disabling Poke Displacers on hands...");

        var displacers = GameObject.FindObjectsOfType<UnityEngine.XR.Interaction.Toolkit.Inputs.XRHandSkeletonPokeDisplacer>(true);
        foreach (var displacer in displacers)
        {
            displacer.enabled = false;
            EditorUtility.SetDirty(displacer.gameObject);
            Debug.Log($"[LobbySetupHelper] Disabled XRHandSkeletonPokeDisplacer on: {displacer.gameObject.name}");
        }

        EditorSceneManager.SaveOpenScenes();
        Debug.Log("[LobbySetupHelper] Poke Displacers disabled and scene saved successfully!");
    }

    [MenuItem("Tools/Find Colliders On Hands and UI")]
    public static void FindColliders()
    {
        Debug.Log("[LobbySetupHelper] Finding all colliders under XR Origin and UIRoot...");
        var xrOrigin = GameObject.Find("XR Origin");
        if (xrOrigin != null)
        {
            var colliders = xrOrigin.GetComponentsInChildren<Collider>(true);
            foreach (var col in colliders)
            {
                Debug.Log($"[LobbySetupHelper] Found collider on XR Origin: {col.gameObject.name} (Type: {col.GetType().Name}, Enabled: {col.enabled}, IsTrigger: {col.isTrigger}, Layer: {col.gameObject.layer})");
            }
        }
        else
        {
            Debug.LogError("[LobbySetupHelper] Could not find XR Origin GameObject!");
        }
        var uiRoot = GameObject.Find("UIRoot");
        if (uiRoot != null)
        {
            var colliders = uiRoot.GetComponentsInChildren<Collider>(true);
            foreach (var col in colliders)
            {
                Debug.Log($"[LobbySetupHelper] Found collider on UIRoot: {col.gameObject.name} (Type: {col.GetType().Name}, Enabled: {col.enabled}, IsTrigger: {col.isTrigger}, Layer: {col.gameObject.layer})");
            }
        }
        else
        {
            Debug.LogError("[LobbySetupHelper] Could not find UIRoot GameObject!");
        }
    }

    [MenuItem("Tools/Optimize Hand Poke Interaction")]
    public static void OptimizeHandPokeInteraction()
    {
        Debug.Log("[LobbySetupHelper] Starting Hand Poke Interaction optimization...");

        // 1. Optimize XRPokeInteractor parameters on all poke interactors
        var interactors = GameObject.FindObjectsOfType<UnityEngine.XR.Interaction.Toolkit.Interactors.XRPokeInteractor>(true);
        foreach (var interactor in interactors)
        {
            // Only optimize for hand-related poke interactors
            string path = GetGameObjectPath(interactor.gameObject);
            if (path.Contains("Left Hand") || path.Contains("Right Hand"))
            {
                interactor.pokeDepth = 0.075f; // 7.5 cm for reliable, easy Canvas intersection
                interactor.pokeWidth = 0.01f;  // 1.0 cm
                interactor.pokeSelectWidth = 0.02f; // 2.0 cm for forgiving clicks
                interactor.pokeHoverRadius = 0.03f;  // 3.0 cm for easy hovers
                interactor.pokeInteractionOffset = 0.005f; // 0.5 cm offset buffer
                
                EditorUtility.SetDirty(interactor);
                Debug.Log($"[LobbySetupHelper] Optimized XRPokeInteractor parameters on: {path}");
            }
        }

        // 2. Wire up PokeGestureDetector to only enable Poke Interactor during a poke gesture
        var leftHand = GameObject.Find("XR Origin/Camera Offset/Left Hand");
        if (leftHand != null)
        {
            var detector = leftHand.GetComponent<UnityEngine.XR.Interaction.Toolkit.Samples.Hands.PokeGestureDetector>();
            var pokeInteractor = leftHand.transform.Find("Poke Interactor")?.gameObject;
            if (detector != null && pokeInteractor != null)
            {
                // Use reflection to access private event fields
                var detectorType = typeof(UnityEngine.XR.Interaction.Toolkit.Samples.Hands.PokeGestureDetector);
                var startedField = detectorType.GetField("m_PokeGestureStarted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var endedField = detectorType.GetField("m_PokeGestureEnded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (startedField != null && endedField != null)
                {
                    // Clear existing events by re-instantiating
                    var startedEvent = new UnityEngine.Events.UnityEvent();
                    var endedEvent = new UnityEngine.Events.UnityEvent();

                    // Bind startedEvent -> pokeInteractor.SetActive(true)
                    UnityEditor.Events.UnityEventTools.AddBoolPersistentListener(
                        startedEvent,
                        new UnityEngine.Events.UnityAction<bool>(pokeInteractor.SetActive),
                        true
                    );

                    // Bind endedEvent -> pokeInteractor.SetActive(false)
                    UnityEditor.Events.UnityEventTools.AddBoolPersistentListener(
                        endedEvent,
                        new UnityEngine.Events.UnityAction<bool>(pokeInteractor.SetActive),
                        false
                    );

                    // Save events back to detector fields
                    startedField.SetValue(detector, startedEvent);
                    endedField.SetValue(detector, endedEvent);

                    // Disable the interactor by default
                    pokeInteractor.SetActive(false);

                    EditorUtility.SetDirty(detector);
                    EditorUtility.SetDirty(pokeInteractor);
                    Debug.Log("[LobbySetupHelper] Left Hand: Successfully bound PokeGestureDetector to Poke Interactor and set disabled by default.");
                }
            }
        }

        var rightHand = GameObject.Find("XR Origin/Camera Offset/Right Hand");
        if (rightHand != null)
        {
            var detector = rightHand.GetComponent<UnityEngine.XR.Interaction.Toolkit.Samples.Hands.PokeGestureDetector>();
            var pokeInteractor = rightHand.transform.Find("Poke Interactor")?.gameObject;
            if (detector != null && pokeInteractor != null)
            {
                // Use reflection to access private event fields
                var detectorType = typeof(UnityEngine.XR.Interaction.Toolkit.Samples.Hands.PokeGestureDetector);
                var startedField = detectorType.GetField("m_PokeGestureStarted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var endedField = detectorType.GetField("m_PokeGestureEnded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (startedField != null && endedField != null)
                {
                    // Clear existing events by re-instantiating
                    var startedEvent = new UnityEngine.Events.UnityEvent();
                    var endedEvent = new UnityEngine.Events.UnityEvent();

                    // Bind startedEvent -> pokeInteractor.SetActive(true)
                    UnityEditor.Events.UnityEventTools.AddBoolPersistentListener(
                        startedEvent,
                        new UnityEngine.Events.UnityAction<bool>(pokeInteractor.SetActive),
                        true
                    );

                    // Bind endedEvent -> pokeInteractor.SetActive(false)
                    UnityEditor.Events.UnityEventTools.AddBoolPersistentListener(
                        endedEvent,
                        new UnityEngine.Events.UnityAction<bool>(pokeInteractor.SetActive),
                        false
                    );

                    // Save events back to detector fields
                    startedField.SetValue(detector, startedEvent);
                    endedField.SetValue(detector, endedEvent);

                    // Disable the interactor by default
                    pokeInteractor.SetActive(false);

                    EditorUtility.SetDirty(detector);
                    EditorUtility.SetDirty(pokeInteractor);
                    Debug.Log("[LobbySetupHelper] Right Hand: Successfully bound PokeGestureDetector to Poke Interactor and set disabled by default.");
                }
            }
        }

        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
        Debug.Log("[LobbySetupHelper] Hand Poke Interaction optimization complete and scene saved successfully!");
    }

    [MenuItem("Tools/Setup Lobby Instructor")]
    public static void SetupLobbyInstructor()
    {
        Debug.Log("[LobbySetupHelper] Starting Lobby Virtual Instructor NPC setup...");

        // 1. Clean existing RobotKyle_Lecturer
        GameObject existingKyle = GameObject.Find("RobotKyle_Lecturer");
        if (existingKyle != null)
        {
            Debug.Log("[LobbySetupHelper] Found existing RobotKyle_Lecturer. Destroying to recreate a clean setup.");
            DestroyImmediate(existingKyle);
        }

        // 2. Load RobotKyle Prefab
        GameObject kylePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UnityTechnologies/SpaceRobotKyle/Prefabs/RobotKyle.prefab");
        if (kylePrefab == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find RobotKyle prefab at: Assets/UnityTechnologies/SpaceRobotKyle/Prefabs/RobotKyle.prefab");
            return;
        }

        // 3. Instantiate Kyle as a Prefab Link
        GameObject kyle = (GameObject)PrefabUtility.InstantiatePrefab(kylePrefab);
        kyle.name = "RobotKyle_Lecturer";
        kyle.transform.position = new Vector3(2.5f, 0f, -9.0f);
        kyle.transform.rotation = Quaternion.Euler(0f, 230f, 0f);

        // 4. Configure Animator
        Animator animator = kyle.GetComponent<Animator>();
        if (animator == null)
        {
            animator = kyle.AddComponent<Animator>();
        }
        RuntimeAnimatorController kyleController = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>("Assets/Lecture/Resources/Animations/Kyle_Lecturer.controller");
        if (kyleController == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find Kyle_Lecturer Animator Controller at: Assets/Lecture/Resources/Animations/Kyle_Lecturer.controller");
        }
        else
        {
            animator.runtimeAnimatorController = kyleController;
        }

        // 5. Add NPCLobbyInstructorController
        NPCLobbyInstructorController controllerScript = kyle.AddComponent<NPCLobbyInstructorController>();

        // 6. Create World Space Canvas Parent & Canvas
        GameObject canvasParent = new GameObject("SpeechBubble_Parent");
        canvasParent.transform.SetParent(kyle.transform, false);
        canvasParent.transform.localPosition = new Vector3(0f, 2.1f, 0f);
        canvasParent.transform.localScale = Vector3.one;
        canvasParent.transform.localRotation = Quaternion.identity;
        canvasParent.AddComponent<UIFaceCamera>();

        GameObject canvasObj = new GameObject("SpeechBubble_Canvas");
        canvasObj.transform.SetParent(canvasParent.transform, false);
        canvasObj.transform.localPosition = Vector3.zero;
        canvasObj.transform.localScale = new Vector3(0.0015f, 0.0015f, 0.0015f);
        canvasObj.transform.localRotation = Quaternion.Euler(0f, 180f, 0f); // Rotate 180 degrees relative to parent to correct mirroring

        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
        scaler.dynamicPixelsPerUnit = 10f;

        canvasObj.AddComponent<GraphicRaycaster>();
        canvasObj.AddComponent<UnityEngine.XR.Interaction.Toolkit.UI.TrackedDeviceGraphicRaycaster>();

        // 7. Background Panel (Sliced image rounded corner)
        GameObject panelObj = new GameObject("Panel_Background");
        panelObj.transform.SetParent(canvasObj.transform, false);
        
        RectTransform panelRT = panelObj.AddComponent<RectTransform>();
        panelRT.sizeDelta = new Vector2(500f, 280f);
        panelRT.anchoredPosition = Vector2.zero;
        panelRT.localScale = Vector3.one;
        panelRT.localRotation = Quaternion.identity;

        panelObj.AddComponent<CanvasRenderer>();
        Image bgImg = panelObj.AddComponent<Image>();
        Sprite bgSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Samples/XR Hands/1.4.3/Gestures/Debug Tools/Sprites/RoundedCornerBackground.png");
        if (bgSprite != null)
        {
            bgImg.sprite = bgSprite;
            bgImg.type = Image.Type.Sliced;
        }
        bgImg.color = new Color(0.07f, 0.07f, 0.1f, 0.92f); // Beautiful dark glassmorphism

        // 8. Dialogue Text
        GameObject textObj = new GameObject("Text_Dialogue");
        textObj.transform.SetParent(panelObj.transform, false);

        RectTransform textRT = textObj.AddComponent<RectTransform>();
        textRT.anchorMin = new Vector2(0f, 0.25f);
        textRT.anchorMax = new Vector2(1f, 1f);
        textRT.offsetMin = new Vector2(25f, 10f);
        textRT.offsetMax = new Vector2(-25f, -25f);
        textRT.localScale = Vector3.one;
        textRT.localRotation = Quaternion.identity;

        textObj.AddComponent<CanvasRenderer>();
        TextMeshProUGUI diagText = textObj.AddComponent<TextMeshProUGUI>();
        diagText.fontSize = 24f;
        diagText.alignment = TextAlignmentOptions.MidlineLeft;
        diagText.enableWordWrapping = true;
        diagText.color = Color.white;

        // 9. Bottom Navigation Bar
        GameObject navObj = new GameObject("Panel_Navigation");
        navObj.transform.SetParent(panelObj.transform, false);

        RectTransform navRT = navObj.AddComponent<RectTransform>();
        navRT.anchorMin = new Vector2(0f, 0f);
        navRT.anchorMax = new Vector2(1f, 0.25f);
        navRT.offsetMin = new Vector2(25f, 15f);
        navRT.offsetMax = new Vector2(-25f, -15f);
        navRT.localScale = Vector3.one;
        navRT.localRotation = Quaternion.identity;

        HorizontalLayoutGroup navLayout = navObj.AddComponent<HorizontalLayoutGroup>();
        navLayout.childAlignment = TextAnchor.MiddleCenter;
        navLayout.spacing = 30f;
        navLayout.childControlWidth = false;
        navLayout.childControlHeight = false;
        navLayout.childForceExpandWidth = false;
        navLayout.childForceExpandHeight = false;

        // 10. Back Button
        GameObject backBtnObj = new GameObject("Button_Back");
        backBtnObj.transform.SetParent(navObj.transform, false);

        RectTransform backRT = backBtnObj.AddComponent<RectTransform>();
        backRT.sizeDelta = new Vector2(80f, 40f);

        backBtnObj.AddComponent<CanvasRenderer>();
        Image backImg = backBtnObj.AddComponent<Image>();
        if (bgSprite != null)
        {
            backImg.sprite = bgSprite;
            backImg.type = Image.Type.Sliced;
        }
        backImg.color = new Color(0f, 0.627f, 1f, 1.0f); // Bright VR Cyan/Blue

        Button backBtn = backBtnObj.AddComponent<Button>();

        // Text for Back Button
        GameObject backTextObj = new GameObject("Text");
        backTextObj.transform.SetParent(backBtnObj.transform, false);
        RectTransform backTextRT = backTextObj.AddComponent<RectTransform>();
        backTextRT.anchorMin = Vector2.zero;
        backTextRT.anchorMax = Vector2.one;
        backTextRT.offsetMin = Vector2.zero;
        backTextRT.offsetMax = Vector2.zero;
        
        backTextObj.AddComponent<CanvasRenderer>();
        TextMeshProUGUI backText = backTextObj.AddComponent<TextMeshProUGUI>();
        backText.text = "<";
        backText.fontSize = 22f;
        backText.alignment = TextAlignmentOptions.Center;
        backText.color = Color.white;

        // 11. Page Indicator Text
        GameObject pageTextObj = new GameObject("Text_PageIndicator");
        pageTextObj.transform.SetParent(navObj.transform, false);

        RectTransform pageRT = pageTextObj.AddComponent<RectTransform>();
        pageRT.sizeDelta = new Vector2(100f, 40f);

        pageTextObj.AddComponent<CanvasRenderer>();
        TextMeshProUGUI pageText = pageTextObj.AddComponent<TextMeshProUGUI>();
        pageText.text = "1 / 4";
        pageText.fontSize = 20f;
        pageText.alignment = TextAlignmentOptions.Center;
        pageText.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);

        // 12. Next Button
        GameObject nextBtnObj = new GameObject("Button_Next");
        nextBtnObj.transform.SetParent(navObj.transform, false);

        RectTransform nextRT = nextBtnObj.AddComponent<RectTransform>();
        nextRT.sizeDelta = new Vector2(110f, 40f);

        nextBtnObj.AddComponent<CanvasRenderer>();
        Image nextImg = nextBtnObj.AddComponent<Image>();
        if (bgSprite != null)
        {
            nextImg.sprite = bgSprite;
            nextImg.type = Image.Type.Sliced;
        }
        nextImg.color = new Color(0f, 0.627f, 1f, 1.0f); // Bright VR Cyan/Blue

        Button nextBtn = nextBtnObj.AddComponent<Button>();

        // Text for Next Button
        GameObject nextTextObj = new GameObject("Text_NextButtonLabel");
        nextTextObj.transform.SetParent(nextBtnObj.transform, false);
        RectTransform nextTextRT = nextTextObj.AddComponent<RectTransform>();
        nextTextRT.anchorMin = Vector2.zero;
        nextTextRT.anchorMax = Vector2.one;
        nextTextRT.offsetMin = Vector2.zero;
        nextTextRT.offsetMax = Vector2.zero;

        nextTextObj.AddComponent<CanvasRenderer>();
        TextMeshProUGUI nextText = nextTextObj.AddComponent<TextMeshProUGUI>();
        nextText.text = ">";
        nextText.fontSize = 22f;
        nextText.alignment = TextAlignmentOptions.Center;
        nextText.color = Color.white;

        // 13. Bind Events programmatically
        UnityEventTools.AddPersistentListener(backBtn.onClick, controllerScript.PrevSlide);
        UnityEventTools.AddPersistentListener(nextBtn.onClick, controllerScript.NextSlide);

        // 14. Assign references on controllerScript
        controllerScript.kyleAnim = animator;
        controllerScript.dialogueText = diagText;
        controllerScript.pageIndicatorText = pageText;
        controllerScript.backButton = backBtn;
        controllerScript.nextButton = nextBtn;
        controllerScript.nextButtonText = nextText;

        // 15. Set Dirty and Save
        EditorUtility.SetDirty(kyle);
        if (canvasParent != null) EditorUtility.SetDirty(canvasParent);
        EditorUtility.SetDirty(canvasObj);
        EditorUtility.SetDirty(panelObj);
        EditorUtility.SetDirty(textObj);
        EditorUtility.SetDirty(navObj);

        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
        Debug.Log("[LobbySetupHelper] Lobby Virtual Instructor NPC successfully spawned, configured, and bound!");
    }

    [MenuItem("Tools/Setup Gesture Locomotion")]
    public static void SetupGestureLocomotion()
    {
        Debug.Log("[LobbySetupHelper] Starting Gesture Locomotion setup...");

        // 1. Find XR Origin
        GameObject xrOrigin = GameObject.Find("XR Origin");
        if (xrOrigin == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not find 'XR Origin' GameObject in the scene!");
            return;
        }

        // 2. Get or Add CharacterController
        CharacterController cc = xrOrigin.GetComponent<CharacterController>();
        if (cc == null)
        {
            cc = xrOrigin.AddComponent<CharacterController>();
            Debug.Log("[LobbySetupHelper] Added CharacterController component to XR Origin.");
        }

        // 3. Get or Add GestureLocomotionProvider
        GestureLocomotionProvider locomotion = xrOrigin.GetComponent<GestureLocomotionProvider>();
        if (locomotion == null)
        {
            locomotion = xrOrigin.AddComponent<GestureLocomotionProvider>();
            Debug.Log("[LobbySetupHelper] Added GestureLocomotionProvider component to XR Origin.");
        }

        // 4. Find Hand Joint tracking events under [System_GestureManager]
        GameObject gestureManager = GameObject.Find("[System_GestureManager]");
        XRHandTrackingEvents leftHandEvents = null;
        XRHandTrackingEvents rightHandEvents = null;

        if (gestureManager != null)
        {
            var trackingEventsList = gestureManager.GetComponentsInChildren<XRHandTrackingEvents>(true);
            foreach (var trackingEvents in trackingEventsList)
            {
                if (trackingEvents.gameObject.name.Contains("Left"))
                {
                    leftHandEvents = trackingEvents;
                }
                else if (trackingEvents.gameObject.name.Contains("Right"))
                {
                    rightHandEvents = trackingEvents;
                }
            }
        }
        else
        {
            Debug.LogWarning("[LobbySetupHelper] Could not find [System_GestureManager] in the scene to bind tracking events!");
        }

        // 5. Find Left and Right Hand transforms under XR Origin
        Transform leftHandTransform = xrOrigin.transform.Find("Camera Offset/Left Hand");
        Transform rightHandTransform = xrOrigin.transform.Find("Camera Offset/Right Hand");

        if (leftHandTransform == null || rightHandTransform == null)
        {
            // Try fallback search
            leftHandTransform = GameObject.Find("Left Hand")?.transform;
            rightHandTransform = GameObject.Find("Right Hand")?.transform;
        }

        if (leftHandTransform == null || rightHandTransform == null)
        {
            Debug.LogWarning("[LobbySetupHelper] Could not find Left Hand or Right Hand transforms under Camera Offset. Please assign them manually in the inspector.");
        }

        // 6. Load hand shape asset for '1' gesture (pointing)
        ScriptableObject shapeAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>("Assets/HandShapePose/Numbers/1/1.asset");
        if (shapeAsset == null)
        {
            Debug.LogError("[LobbySetupHelper] Could not load shape asset at path: Assets/HandShapePose/Numbers/1/1.asset");
        }

        // 7. Configure references
        locomotion.leftPointingGestureID = "Pointing_Left";
        locomotion.rightPointingGestureID = "Pointing_Right";
        locomotion.leftHandTransform = leftHandTransform;
        locomotion.rightHandTransform = rightHandTransform;
        locomotion.characterController = cc;
        locomotion.moveSpeed = 1.5f;
        locomotion.lockYAxis = true;

        // 8. Mark Dirty and Save
        EditorUtility.SetDirty(xrOrigin);
        EditorUtility.SetDirty(locomotion);

        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
        Debug.Log("[LobbySetupHelper] Gesture Locomotion setup successfully complete and scene saved!");
    }

    private static string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        GameObject current = obj;
        while (current.transform.parent != null)
        {
            current = current.transform.parent.gameObject;
            path = current.name + "/" + path;
        }
        return path;
    }
}
