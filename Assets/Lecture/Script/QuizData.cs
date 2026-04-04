using UnityEngine;

public enum QuestionType
{
    Matching,          // Chọn ảnh
    Ordering,          // Đánh vần chuỗi (Spelling)
    AudioFillInTheGap  // Nghe và điền vào chỗ trống
}

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Quiz System/Question")]
public class QuizData : ScriptableObject
{
    [Header("Câu hỏi")]
    public QuestionType questionType;
    [TextArea] public string questionText;
    public string sentenceTemplate; // VD: "I love {0}"
    public Sprite questionImage;
    public AudioClip questionAudio;
    public string topic = "Alphabets";

    [Header("Đáp án")]
    public string[] correctGestureIDs; // Mảng các ID Gesture (VD: ["A"], ["C", "A", "T"])
}