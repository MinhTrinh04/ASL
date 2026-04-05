using UnityEditor;
using UnityEngine;

public static class RepositionAlphabetsQuiz
{
    [MenuItem("Tools/Fix/Reposition Alphabets Quiz")]
    public static void Reposition()
    {
        GameObject alphabets = GameObject.Find("Alphabets");
        if (alphabets == null)
        {
            Debug.LogError("[Reposition] 'Alphabets' not found.");
            return;
        }

        Transform phaseQuiz = alphabets.transform.Find("Phase_Quiz");
        if (phaseQuiz == null)
        {
            Debug.LogError("[Reposition] 'Phase_Quiz' not found under Alphabets.");
            return;
        }

        Transform quizBoard = phaseQuiz.Find("Quiz Board");
        if (quizBoard == null)
        {
            Debug.LogError("[Reposition] 'Quiz Board' not found under Phase_Quiz.");
            return;
        }

        Undo.RecordObjects(new Object[] { phaseQuiz, quizBoard }, "Reposition Alphabets Quiz");

        // Target: Player standing in front of board1 (1)
        // board1 (1) world pos: (-2.84, 0.81, -6.03)
        // Alphabets world pos: (-2.01, 2.19, -5.86)
        
        // Phase_Quiz local position (Teleport target for player)
        phaseQuiz.localPosition = new Vector3(-0.83f, -1.19f, 1.36f);
        
        // Quiz Board local position (relative to Phase_Quiz)
        quizBoard.localPosition = new Vector3(0f, 0.8f, -1.52f);
        quizBoard.localRotation = Quaternion.Euler(0, 0, 0);

        Debug.Log($"[Reposition] Phase_Quiz moved to {phaseQuiz.localPosition}");
        Debug.Log($"[Reposition] Quiz Board moved to {quizBoard.localPosition}");

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(alphabets.scene);
        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
        Debug.Log("[Reposition] Scene saved.");
    }
}
