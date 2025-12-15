using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text questionTextUI;
    public Image questionImageUI;
    public TMP_Text feedbackTextUI;
    public TMP_Text scoreTextUI;

    [Header("Exam Config")]
    public Color feedbackColor = new Color(0, 1, 0, 1); // Màu xanh lá khi chạy
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

        feedbackTextUI.text = "Waiting for gesture...";
        feedbackTextUI.color = feedbackColor;
    }

    public void SubmitAnswer(string gestureID)
    {
        if (!isExamActive || currentQuestionIndex >= questionList.Count) return;

        string correctAnswer = questionList[currentQuestionIndex].correctGestureID;

        if (gestureID == correctAnswer)
        {
            StartCoroutine(HandleCorrectAnswer());
        }
    }

    IEnumerator HandleCorrectAnswer()
    {
        isExamActive = false;

        feedbackTextUI.text = "CORRECT!";
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
        questionTextUI.text = "TEST COMPLETED";
        questionImageUI.gameObject.SetActive(false);
        feedbackTextUI.text = $"Total Score: {score}/{questionList.Count}";
    }

    void UpdateScoreUI()
    {
        if (scoreTextUI != null)
            scoreTextUI.text = $"Score: {score}/{questionList.Count}";
    }
}