using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Quiz System/Question")]
public class QuizData : ScriptableObject
{
    [Header("Đề bài")]
    [TextArea] public string questionText; // VD: "1 + 1 = ?"
    public Sprite questionImage;           // VD: Ảnh quả táo (Để null nếu chỉ dùng text)

    [Header("Đáp án")]
    public string correctGestureID;        // VD: "2" (Phải khớp với ID bạn cài trong Gesture)
}