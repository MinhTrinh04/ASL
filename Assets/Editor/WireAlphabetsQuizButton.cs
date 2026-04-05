using UnityEditor;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public static class WireAlphabetsQuizButton
{
    [MenuItem("Tools/Fix/Wire Alphabets Quiz Button")]
    public static void WireButton()
    {
        // Find Alphabets root
        GameObject alphabets = GameObject.Find("Alphabets");
        if (alphabets == null)
        {
            Debug.LogError("[WireAlphabets] Could not find 'Alphabets' root.");
            return;
        }

        ClassroomManager mgr = alphabets.GetComponent<ClassroomManager>();
        if (mgr == null)
        {
            Debug.LogError("[WireAlphabets] 'Alphabets' has no ClassroomManager.");
            return;
        }

        // Find the exact Btn_StartQuiz under Alphabets/Phase_Lecture
        Transform btnTransform = alphabets.transform.Find("Phase_Lecture/Buttons_Container/Btn_StartQuiz");
        if (btnTransform == null)
        {
            Debug.LogError("[WireAlphabets] Could not find Btn_StartQuiz under Alphabets/Phase_Lecture/Buttons_Container.");
            return;
        }

        Button btn = btnTransform.GetComponent<Button>();
        if (btn == null)
        {
            Debug.LogError("[WireAlphabets] No Button component on Btn_StartQuiz.");
            return;
        }

        // Remove old listeners and add EnterQuizMode
        Undo.RecordObject(btn, "Wire Alphabets Quiz Button");
        btn.onClick.RemoveAllListeners();
        UnityEventTools.AddPersistentListener(btn.onClick, mgr.EnterQuizMode);
        EditorUtility.SetDirty(btn);
        Debug.Log("[WireAlphabets] Btn_StartQuiz.onClick → ClassroomManager.EnterQuizMode DONE.");

        // Find QuizManager on Quiz Board
        Transform quizBoardTransform = alphabets.transform.Find("Phase_Quiz/Quiz Board");
        if (quizBoardTransform == null)
        {
            Debug.LogWarning("[WireAlphabets] Could not find Phase_Quiz/Quiz Board.");
        }
        else
        {
            QuizManager qm = quizBoardTransform.GetComponent<QuizManager>();
            if (qm == null)
            {
                Debug.LogWarning("[WireAlphabets] No QuizManager on Quiz Board.");
            }
            else
            {
                Undo.RecordObject(qm, "Wire Alphabets onExamFinished");
                UnityEventTools.AddPersistentListener(qm.onExamFinished, mgr.EnterLectureMode);
                EditorUtility.SetDirty(qm);
                Debug.Log("[WireAlphabets] QuizManager.onExamFinished → ClassroomManager.EnterLectureMode DONE.");
            }
        }

        // Save the scene
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(alphabets.scene);
        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
        Debug.Log("[WireAlphabets] Scene saved.");
    }
}
