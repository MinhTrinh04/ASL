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
        if (ctrl == null) return;
        
        ClassroomManager[] cManagers = GameObject.FindObjectsOfType<ClassroomManager>(true);
        foreach (var m in cManagers)
        {
            m.gestureTopicController = ctrl;
            
            // Tìm index dựa trên tên GameObject (ví dụ: "Alphabets")
            for (int i = 0; i < ctrl.topics.Count; i++)
            {
                if (ctrl.topics[i].topicName.Equals(m.gameObject.name, System.StringComparison.OrdinalIgnoreCase))
                {
                    m.currentTopicIndex = i;
                    break;
                }
            }
            EditorUtility.SetDirty(m);
        }
        Debug.Log("Classroom Manager bindings finalized!");
    }
}