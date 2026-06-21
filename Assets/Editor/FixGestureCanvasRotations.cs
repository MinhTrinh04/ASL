using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

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
}
