using UnityEditor;
using UnityEngine;

public class ValidationCheck : EditorWindow
{
    [MenuItem("Tools/Validation Check")]
    public static void Check()
    {
        GameObject managerObj = GameObject.Find("[System_GestureManager]");
        if (managerObj == null) { Debug.LogError("Manager not found!"); return; }
        
        GestureTopicController ctrl = managerObj.GetComponent<GestureTopicController>();
        ClassroomManager[] cManagers = GameObject.FindObjectsOfType<ClassroomManager>(true);
        
        foreach (var m in cManagers)
        {
            if (m.gestureTopicController != ctrl)
            {
                m.gestureTopicController = ctrl;
                EditorUtility.SetDirty(m);
                Debug.Log($"Fixed binding for: {m.gameObject.name}");
            }
        }
        Debug.Log("Validation Check Complete!");
    }
}