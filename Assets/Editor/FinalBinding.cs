using UnityEditor;
using UnityEngine;

public class FinalBinding : EditorWindow
{
    [MenuItem("Tools/Finalize Classroom Binding")]
    public static void Bind()
    {
        GameObject managerObj = GameObject.Find("[System_GestureManager]");
        if (managerObj == null) return;
        
        GestureTopicController ctrl = managerObj.GetComponent<GestureTopicController>();
        
        ClassroomManager[] cManagers = GameObject.FindObjectsOfType<ClassroomManager>(true);
        foreach (var m in cManagers)
        {
            m.gestureTopicController = ctrl;
            // Set topicName based on parent as a guess if not already set
            if (string.IsNullOrEmpty(m.topicName) || m.topicName == "Alphabets")
            {
                m.topicName = m.gameObject.name;
            }
            EditorUtility.SetDirty(m);
        }
        Debug.Log("Classroom Manager bindings finalized!");
    }
}