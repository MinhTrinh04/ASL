using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class PopulateAlphabetsQuizFinal : MonoBehaviour
{
    [MenuItem("Tools/Quiz/Populate Alphabets Quiz Final")]
    public static void Populate()
    {
        // Find the specific Quiz Board under Alphabets
        GameObject alphabets = GameObject.Find("Alphabets");
        if (alphabets == null) { Debug.LogError("No Alphabets root found!"); return; }

        QuizManager qm = alphabets.GetComponentInChildren<QuizManager>(true);

        if (qm == null)
        {
            Debug.LogError("QuizManager not found in Alphabets!");
            return;
        }

        Undo.RecordObject(qm, "Populate Quiz List");

        List<QuizData> finalBatch = new List<QuizData>();

        // 1. Matching A, B, C
        finalBatch.Add(AssetDatabase.LoadAssetAtPath<QuizData>("Assets/Lecture/QuizData/Alphabets/Match_A.asset"));
        finalBatch.Add(AssetDatabase.LoadAssetAtPath<QuizData>("Assets/Lecture/QuizData/Alphabets/Match_B.asset"));
        finalBatch.Add(AssetDatabase.LoadAssetAtPath<QuizData>("Assets/Lecture/QuizData/Alphabets/Match_C.asset"));

        // 2. 7 New Spelling
        string[] newSpellings = { "FISH", "BALL", "CAKE", "KING", "JAVA", "LION", "MAPS" };
        foreach (var word in newSpellings)
            finalBatch.Add(AssetDatabase.LoadAssetAtPath<QuizData>($"Assets/Lecture/QuizData/Alphabets/Spell_{word}.asset"));

        // 3. 5 Gap Fill
        string[] gapAssets = { "Gap_APPLE", "Gap_BANANA", "Gap_FISH_Full", "Gap_KIWI", "Gap_LION" };
        foreach (var gap in gapAssets)
            finalBatch.Add(AssetDatabase.LoadAssetAtPath<QuizData>($"Assets/Lecture/QuizData/Alphabets/{gap}.asset"));

        // Filter nulls
        finalBatch.RemoveAll(item => item == null);

        qm.GetType().GetField("questionList").SetValue(qm, finalBatch.ToArray());
        
        EditorUtility.SetDirty(qm);
        Debug.Log($"Populated Alphabets Quiz Board with {finalBatch.Count} questions.");
    }
}
