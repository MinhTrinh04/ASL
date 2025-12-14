using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text questionTextUI;
    public Image questionImageUI;
    public TMP_Text feedbackTextUI;
    public TMP_Text scoreTextUI;

    [Header("Cấu hình bài thi")]
    public List<QuizData> questionList; // Kéo các file câu hỏi vào đây
    public float delayNextQuestion = 2.0f;

    // Biến nội bộ
    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool isExamActive = false; // Biến này để bật/tắt chế độ thi

    void Start()
    {
        // Có thể gọi hàm này khi bấm nút "Bắt đầu thi"
        StartExam();
    }

    public void StartExam()
    {
        currentQuestionIndex = 0;
        score = 0;
        isExamActive = true;
        LoadQuestion(0);
        UpdateScoreUI();
    }

    void LoadQuestion(int index)
    {
        if (index >= questionList.Count)
        {
            EndExam();
            return;
        }

        QuizData data = questionList[index];

        // 1. Hiển thị Text
        questionTextUI.text = data.questionText;

        // 2. Hiển thị Ảnh (Nếu có thì hiện, không thì ẩn)
        if (data.questionImage != null)
        {
            questionImageUI.gameObject.SetActive(true);
            questionImageUI.sprite = data.questionImage;
            questionImageUI.preserveAspect = true;
        }
        else
        {
            questionImageUI.gameObject.SetActive(false);
        }

        feedbackTextUI.text = "Đang chờ trả lời...";
        feedbackTextUI.color = Color.yellow;
    }

    // --- HÀM NHẬN TÍN HIỆU TỪ TAY ---
    public void SubmitAnswer(string gestureID)
    {
        // Nếu chưa bắt đầu thi hoặc đã hết câu hỏi thì lờ đi
        if (!isExamActive || currentQuestionIndex >= questionList.Count) return;

        // Kiểm tra đáp án
        string correctAnswer = questionList[currentQuestionIndex].correctGestureID;

        if (gestureID == correctAnswer)
        {
            StartCoroutine(HandleCorrectAnswer());
        }
    }

    IEnumerator HandleCorrectAnswer()
    {
        isExamActive = false; // Tạm dừng để không nhận thêm input khi đang chuyển câu

        feedbackTextUI.text = "CHÍNH XÁC!";
        feedbackTextUI.color = Color.green;
        score++;
        UpdateScoreUI();

        yield return new WaitForSeconds(delayNextQuestion);

        // Chuyển câu tiếp
        currentQuestionIndex++;
        isExamActive = true;
        LoadQuestion(currentQuestionIndex);
    }

    void EndExam()
    {
        isExamActive = false;
        questionTextUI.text = "KẾT THÚC BÀI THI";
        questionImageUI.gameObject.SetActive(false);
        feedbackTextUI.text = $"Tổng điểm: {score}/{questionList.Count}";
    }

    void UpdateScoreUI()
    {
        if (scoreTextUI != null)
            scoreTextUI.text = $"Score: {score}/{questionList.Count}";
    }
}