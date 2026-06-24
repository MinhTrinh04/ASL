using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using TMPro;

public class FixGestureCanvasRotations : EditorWindow
{
    [MenuItem("Tools/Fix Gesture Lesson Canvas Rotations")]
    public static void FixRotations()
    {
        Debug.Log("[FixGestureCanvasRotations] Finding all GestureLesson objects in the scene...");
        GestureLesson[] lessons = GameObject.FindObjectsOfType<GestureLesson>(true);
        int count = 0;

        foreach (var lesson in lessons)
        {
            // 1. Revert background local rotation Y back to 180
            Transform backgroundTransform = lesson.transform.Find("Background");
            if (backgroundTransform != null)
            {
                backgroundTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                EditorUtility.SetDirty(backgroundTransform.gameObject);
            }

            // 2. Find or create AttachPoint child
            Transform attachPoint = lesson.transform.Find("AttachPoint");
            if (attachPoint == null)
            {
                GameObject attachObj = new GameObject("AttachPoint");
                attachPoint = attachObj.transform;
                attachPoint.SetParent(lesson.transform, false);
            }

            // 3. Set local position to (0,0,0) and local rotation to Y = 180 (opposite of default grab)
            attachPoint.localPosition = Vector3.zero;
            attachPoint.localRotation = Quaternion.Euler(0f, 180f, 0f);
            EditorUtility.SetDirty(attachPoint.gameObject);

            // 4. Assign AttachPoint to XRGrabInteractable.attachTransform
            XRGrabInteractable grabInteractable = lesson.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.attachTransform = attachPoint;
                EditorUtility.SetDirty(grabInteractable);
                Debug.Log($"[FixGestureCanvasRotations] Configured attachTransform for '{lesson.name}' to Y=180. Path: {GetGameObjectPath(lesson.gameObject)}");
            }
            else
            {
                Debug.LogWarning($"[FixGestureCanvasRotations] No XRGrabInteractable found on '{lesson.name}'!");
            }

            EditorUtility.SetDirty(lesson.gameObject);
            count++;
        }

        if (count > 0)
        {
            EditorSceneManager.SaveOpenScenes();
            Debug.Log($"[FixGestureCanvasRotations] Successfully updated {count} GestureLesson objects in the scene.");
        }
        else
        {
            Debug.Log("[FixGestureCanvasRotations] No GestureLesson objects found.");
        }
    }

    [MenuItem("Tools/Reposition Play Audio Buttons")]
    public static void RepositionPlayAudioButtons()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Starting RepositionPlayAudioButtons...");

        try
        {
            sb.AppendLine("Reloading scene Assets/Scenes/all_.unity...");
            EditorSceneManager.OpenScene("Assets/Scenes/all_.unity");

            sb.AppendLine("Finding all QuizManager boards...");
            QuizManager[] quizManagers = GameObject.FindObjectsOfType<QuizManager>(true);
            int count = 0;

            foreach (var qm in quizManagers)
            {
                if (qm == null || qm.gameObject == null) continue;

                // Skip prefab assets or objects not in any scene
                if (EditorUtility.IsPersistent(qm.gameObject) || qm.gameObject.scene.name == null)
                {
                    sb.AppendLine($"Skipping prefab asset or stage object: {qm.name}");
                    continue;
                }

                sb.AppendLine($"Processing QuizManager: {qm.name} (Path: {GetGameObjectPath(qm.gameObject)})");

                try
                {
                    // 1. Find the Btn_PlayAudio under qm
                    Transform btnPlayAudio = qm.transform.Find("Board/Btn_PlayAudio");
                    if (btnPlayAudio == null)
                    {
                        // Try searching recursively under qm in case it was already moved
                        btnPlayAudio = FindChildRecursive(qm.transform, "Btn_PlayAudio");
                    }

                    if (btnPlayAudio == null)
                    {
                        sb.AppendLine($"Could not find 'Btn_PlayAudio' under '{qm.name}'.");
                        // Cleanup any empty AudioCanvas that might have been left over from previous runs
                        Transform existingCanvas = qm.transform.Find("AudioCanvas");
                        if (existingCanvas != null)
                        {
                            sb.AppendLine($"Destroying empty/unused AudioCanvas under '{qm.name}'");
                            DestroyImmediate(existingCanvas.gameObject);
                        }
                        continue;
                    }

                    // 2. Find ClassroomManager parent to locate Spawn Point
                    ClassroomManager classroom = qm.GetComponentInParent<ClassroomManager>(true);
                    if (classroom == null)
                    {
                        sb.AppendLine($"Could not find ClassroomManager parent for '{qm.name}'.");
                        continue;
                    }

                    Transform spawnPoint = classroom.transform.Find("Spawn Point");
                    if (spawnPoint == null)
                    {
                        sb.AppendLine($"Could not find 'Spawn Point' under classroom '{classroom.name}'.");
                        continue;
                    }

                    // 3. Find or create AudioCanvas to ensure we don't destroy objects unnecessarily and trigger prefab rebuilds
                    Transform audioCanvasTransform = qm.transform.Find("AudioCanvas");
                    GameObject audioCanvasObj;
                    if (audioCanvasTransform != null)
                    {
                        sb.AppendLine($"Reusing existing AudioCanvas for '{qm.name}'");
                        audioCanvasObj = audioCanvasTransform.gameObject;
                    }
                    else
                    {
                        sb.AppendLine($"Creating new AudioCanvas for '{qm.name}'");
                        audioCanvasObj = new GameObject("AudioCanvas");
                        audioCanvasTransform = audioCanvasObj.transform;
                        audioCanvasTransform.SetParent(qm.transform, false);
                    }

                    // Configure Canvas components
                    Canvas canvas = audioCanvasObj.GetComponent<Canvas>();
                    if (canvas == null) canvas = audioCanvasObj.AddComponent<Canvas>();
                    canvas.renderMode = RenderMode.WorldSpace;

                    CanvasScaler scaler = audioCanvasObj.GetComponent<CanvasScaler>();
                    if (scaler == null) scaler = audioCanvasObj.AddComponent<CanvasScaler>();
                    scaler.dynamicPixelsPerUnit = 10f;

                    if (audioCanvasObj.GetComponent<UnityEngine.UI.GraphicRaycaster>() == null)
                    {
                        audioCanvasObj.AddComponent<UnityEngine.UI.GraphicRaycaster>();
                    }

                    // Add TrackedDeviceGraphicRaycaster for VR pointer support
                    var xrRaycaster = audioCanvasObj.GetComponent<UnityEngine.XR.Interaction.Toolkit.UI.TrackedDeviceGraphicRaycaster>();
                    if (xrRaycaster == null)
                    {
                        audioCanvasObj.AddComponent<UnityEngine.XR.Interaction.Toolkit.UI.TrackedDeviceGraphicRaycaster>();
                    }

                    // Position Canvas near player spawn point:
                    // 0.6m forward, 0.4m right, at height y = 1.1m (comfortable hand height)
                    Vector3 targetPos = spawnPoint.position + spawnPoint.forward * 0.6f + spawnPoint.right * 0.4f;
                    targetPos.y = 1.1f; 

                    if (audioCanvasTransform == null)
                    {
                        sb.AppendLine("audioCanvasTransform is null before positioning!");
                        continue;
                    }

                    audioCanvasTransform.position = targetPos;
                    audioCanvasTransform.rotation = spawnPoint.rotation;
                    audioCanvasTransform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

                    RectTransform rectTransform = audioCanvasObj.GetComponent<RectTransform>();
                    if (rectTransform != null)
                    {
                        rectTransform.sizeDelta = new Vector2(150f, 150f);
                    }

                    // Move the button to the new canvas
                    btnPlayAudio.SetParent(audioCanvasTransform, false);
                    btnPlayAudio.localPosition = Vector3.zero;
                    btnPlayAudio.localRotation = Quaternion.identity;
                    btnPlayAudio.localScale = Vector3.one;

                    RectTransform btnRect = btnPlayAudio.GetComponent<RectTransform>();
                    if (btnRect != null)
                    {
                        btnRect.sizeDelta = new Vector2(150f, 150f);
                        btnRect.anchoredPosition = Vector2.zero;
                    }

                    // Change child of the audio play button to use the Play sprite instead of TMPro text
                    Transform iconChild = btnPlayAudio.Find("Icon");
                    if (iconChild == null)
                    {
                        iconChild = btnPlayAudio.Find("Text");
                    }

                    if (iconChild != null)
                    {
                        iconChild.name = "Icon";

                        TextMeshProUGUI tmpText = iconChild.GetComponent<TextMeshProUGUI>();
                        if (tmpText != null)
                        {
                            DestroyImmediate(tmpText);
                        }

                        Image iconImage = iconChild.GetComponent<Image>();
                        if (iconImage == null)
                        {
                            iconImage = iconChild.gameObject.AddComponent<Image>();
                        }

                        Sprite playSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/VRTemplateAssets/Sprites/Icons/Play.png");
                        if (playSprite != null)
                        {
                            iconImage.sprite = playSprite;
                        }
                        else
                        {
                            sb.AppendLine("Warning: Could not load play sprite at Assets/VRTemplateAssets/Sprites/Icons/Play.png");
                        }

                        iconImage.color = Color.white;

                        RectTransform iconRect = iconChild.GetComponent<RectTransform>();
                        if (iconRect != null)
                        {
                            iconRect.sizeDelta = new Vector2(40f, 40f);
                            iconRect.anchoredPosition = Vector2.zero;
                        }

                        EditorUtility.SetDirty(iconChild.gameObject);
                    }

                    EditorUtility.SetDirty(qm.gameObject);
                    EditorUtility.SetDirty(audioCanvasObj);
                    EditorUtility.SetDirty(btnPlayAudio.gameObject);
                    count++;
                }
                catch (System.Exception ex)
                {
                    sb.AppendLine($"Error processing {qm.name}: {ex.Message}\n{ex.StackTrace}");
                }
            }

            if (count > 0)
            {
                EditorSceneManager.SaveOpenScenes();
                sb.AppendLine($"Successfully repositioned {count} Play Audio buttons near spawn points.");
            }
            else
            {
                sb.AppendLine("No buttons repositioned.");
            }
        }
        catch (System.Exception outerEx)
        {
            sb.AppendLine($"Outer Error: {outerEx.Message}\n{outerEx.StackTrace}");
        }

        System.IO.File.WriteAllText("C:/Github/ASL/reposition_log.txt", sb.ToString());
        Debug.Log("Finished RepositionPlayAudioButtons. Log saved to reposition_log.txt");
    }

    private static Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name) return child;
            Transform result = FindChildRecursive(child, name);
            if (result != null) return result;
        }
        return null;
    }

    private static string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = obj.name + "/" + path;
        }
        return path;
    }

    [MenuItem("Tools/Fix Back Buttons")]
    public static void FixBackButtons()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Starting FixBackButtons...");
        
        try
        {
            sb.AppendLine("Opening scene Assets/Scenes/all_.unity...");
            EditorSceneManager.OpenScene("Assets/Scenes/all_.unity");
            
            Unity.VRTemplate.StepManager[] managers = GameObject.FindObjectsOfType<Unity.VRTemplate.StepManager>(true);
            sb.AppendLine($"Found {managers.Length} StepManager components in the scene.");
            int count = 0;

            foreach (var manager in managers)
            {
                if (manager == null || manager.gameObject == null) continue;
                
                sb.AppendLine($"Processing StepManager on GameObject: '{manager.name}' (Path: {GetGameObjectPath(manager.gameObject)})");

                Transform backTransform = manager.transform.Find("Back");
                if (backTransform == null)
                {
                    backTransform = FindChildRecursive(manager.transform, "Back");
                }

                if (backTransform != null)
                {
                    Button btn = backTransform.GetComponent<Button>();
                    if (btn != null)
                    {
                        sb.AppendLine($"  Found Back button on path: {GetGameObjectPath(backTransform.gameObject)}");
                        
                        // Clear existing onClick listeners
                        int clearedCount = btn.onClick.GetPersistentEventCount();
                        while (btn.onClick.GetPersistentEventCount() > 0)
                        {
                            UnityEditor.Events.UnityEventTools.RemovePersistentListener(btn.onClick, 0);
                        }
                        sb.AppendLine($"  Cleared {clearedCount} existing onClick persistent events.");

                        // Add persistent listener calling manager.Back()
                        UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(btn.onClick, new UnityEngine.Events.UnityAction(manager.Back));
                        sb.AppendLine("  Added void persistent listener calling manager.Back().");
                        
                        EditorUtility.SetDirty(btn);
                        EditorUtility.SetDirty(manager);
                        EditorSceneManager.MarkSceneDirty(manager.gameObject.scene);
                        
                        count++;
                    }
                    else
                    {
                        sb.AppendLine("  GameObject named 'Back' does not have a Button component!");
                    }
                }
                else
                {
                    sb.AppendLine("  Could not find any child GameObject named 'Back'.");
                }
            }

            if (count > 0)
            {
                EditorSceneManager.SaveOpenScenes();
                sb.AppendLine($"Successfully saved and wired up {count} Back buttons to their StepManagers.");
            }
            else
            {
                sb.AppendLine("No Back buttons were wired up.");
            }
        }
        catch (System.Exception ex)
        {
            sb.AppendLine($"Error: {ex.Message}\n{ex.StackTrace}");
        }

        System.IO.File.WriteAllText("C:/Github/ASL/fix_back_buttons_log.txt", sb.ToString());
        Debug.Log("Finished FixBackButtons. Log saved to fix_back_buttons_log.txt");
    }

    [MenuItem("Tools/Update Quiz Correct Sound to Duolingo")]
    public static void UpdateQuizSounds()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Starting UpdateQuizSounds...");

        try
        {
            sb.AppendLine("Opening scene Assets/Scenes/all_.unity...");
            EditorSceneManager.OpenScene("Assets/Scenes/all_.unity");

            AssetDatabase.ImportAsset("Assets/Lecture/Audio/duolingo_correct.wav");
            AssetDatabase.Refresh();
            AudioClip duolingoClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Lecture/Audio/duolingo_correct.wav");
            if (duolingoClip == null)
            {
                sb.AppendLine("Error: Could not load duolingo clip at Assets/Lecture/Audio/duolingo_correct.wav");
                System.IO.File.WriteAllText("C:/Github/ASL/update_sounds_log.txt", sb.ToString());
                Debug.LogError("[UpdateQuizSounds] Failed to load audio clip!");
                return;
            }
            sb.AppendLine($"Successfully loaded duolingo clip: {duolingoClip.name}");

            QuizManager[] quizManagers = GameObject.FindObjectsOfType<QuizManager>(true);
            sb.AppendLine($"Found {quizManagers.Length} QuizManager components in the scene.");
            int count = 0;

            foreach (var qm in quizManagers)
            {
                if (qm == null || qm.gameObject == null) continue;
                
                // Skip prefab assets or objects not in any scene
                if (EditorUtility.IsPersistent(qm.gameObject) || qm.gameObject.scene.name == null)
                {
                    sb.AppendLine($"Skipping prefab asset or stage object: {qm.name}");
                    continue;
                }

                sb.AppendLine($"Updating QuizManager: {qm.name} (Path: {GetGameObjectPath(qm.gameObject)})");
                qm.correctClip = duolingoClip;
                
                EditorUtility.SetDirty(qm);
                EditorSceneManager.MarkSceneDirty(qm.gameObject.scene);
                count++;
            }

            if (count > 0)
            {
                EditorSceneManager.SaveOpenScenes();
                sb.AppendLine($"Successfully saved and updated {count} QuizManager correctClip references.");
            }
            else
            {
                sb.AppendLine("No QuizManager instances were updated.");
            }
        }
        catch (System.Exception ex)
        {
            sb.AppendLine($"Error: {ex.Message}\n{ex.StackTrace}");
        }

        System.IO.File.WriteAllText("C:/Github/ASL/update_sounds_log.txt", sb.ToString());
        Debug.Log("Finished UpdateQuizSounds. Log saved to update_sounds_log.txt");
    }
}
