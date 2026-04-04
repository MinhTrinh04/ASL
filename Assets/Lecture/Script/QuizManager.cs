using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

public class QuizManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text questionTextUI;
    public Image questionImageUI;
    public TMP_Text feedbackTextUI;
    public TMP_Text scoreTextUI;
    public GameObject examCanvas; // Màn hình thi

    [Header("Exam Config")]
    public List<QuizData> questionList;
    public float delayNextQuestion = 2.0f;
    public float autoReturnDelay = 5.0f;

    [Header("Scene Transition (Phase v2.0)")]
    public List<GameObject> objectsToHide; // Chứa PDF1, PDF2, PDF3, RobotKyle...

    [Header("Audio Feedback")]
    public AudioSource audioSource;
    public AudioClip correctClip;
    public AudioClip wrongClip;
    public AudioClip finishClip;

    [Header("Events")]
    public UnityEvent onExamFinished;

    // Internal state
    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool isExamActive = false;
    private List<string> currentInputBuffer = new List<string>();

    void OnEnable()
    {
        GestureHub.OnGestureDetected += SubmitAnswer;
        // StartExam logic is now triggered by button press
    }

    void OnDisable()
    {
        GestureHub.OnGestureDetected -= SubmitAnswer;
    }

    public void StartExam()
    {
        // 1. Hide unwanted objects (PDFs, Kyle etc)
        ToggleSecondaryObjects(false);

        // 2. Setup Quiz state
        currentQuestionIndex = 0;
        score = 0;
        isExamActive = true;
        
        if (examCanvas != null) examCanvas.SetActive(true);

        LoadQuestion(0);
        UpdateScoreUI();
    }

    void ToggleSecondaryObjects(bool show)
    {
        if (objectsToHide == null) return;
        foreach (var obj in objectsToHide)
        {
            if (obj != null) obj.SetActive(show);
        }
    }

    void LoadQuestion(int index)
    {
        if (index >= questionList.Count)
        {
            EndExam();
            return;
        }

        QuizData data = questionList[index];
        currentInputBuffer.Clear();

        // 1. Text display based on template
        if (data.questionType == QuestionType.AudioFillInTheGap && !string.IsNullOrEmpty(data.sentenceTemplate))
        {
            // Hiển thị ____ trong câu
            questionTextUI.text = string.Format(data.sentenceTemplate, "____");
        }
        else
        {
            questionTextUI.text = data.questionText;
        }

        // 2. Image display
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

        // 3. Play Audio automatically for Audio questions
        if (data.questionType == QuestionType.AudioFillInTheGap && data.questionAudio != null && audioSource != null)
        {
            audioSource.PlayOneShot(data.questionAudio);
        }

        feedbackTextUI.text = "Waiting for input...";
        feedbackTextUI.color = Color.white;
    }

    public void SubmitAnswer(string gestureID)
    {
        if (!isExamActive || currentQuestionIndex >= questionList.Count) return;

        QuizData currentData = questionList[currentQuestionIndex];
        string[] correctAnswers = currentData.correctGestureIDs;

        // Sequence recognition logic
        int nextIndex = currentInputBuffer.Count;
        if (nextIndex < correctAnswers.Length)
        {
            if (GestureHub.AreEquivalent(gestureID, correctAnswers[nextIndex]))
            {
                HandleCorrectPart(gestureID);
            }
            else
            {
                HandleWrongInput();
            }
        }
    }

    public void SubmitMatchingAnswer(string gestureID)
    {
        SubmitAnswer(gestureID);
    }

    void HandleCorrectPart(string gestureID)
    {
        currentInputBuffer.Add(gestureID);
        score++;
        UpdateScoreUI();

        if (audioSource != null && correctClip != null)
            audioSource.PlayOneShot(correctClip);

        feedbackTextUI.text = "Correct!";
        feedbackTextUI.color = Color.green;

        if (currentInputBuffer.Count == questionList[currentQuestionIndex].correctGestureIDs.Length)
        {
            StartCoroutine(HandleQuestionComplete());
        }
    }

    void HandleWrongInput()
    {
        if (audioSource != null && wrongClip != null)
            audioSource.PlayOneShot(wrongClip);

        feedbackTextUI.text = "Incorrect! Try again.";
        feedbackTextUI.color = Color.red;
    }

    public void HandleDelete()
    {
        if (currentInputBuffer.Count > 0)
        {
            currentInputBuffer.RemoveAt(currentInputBuffer.Count - 1);
            feedbackTextUI.text = "Deleted last sign.";
            feedbackTextUI.color = Color.yellow;
        }
    }

    IEnumerator HandleQuestionComplete()
    {
        isExamActive = false;
        feedbackTextUI.text = "PERFECT!";
        yield return new WaitForSeconds(delayNextQuestion);

        currentQuestionIndex++;
        isExamActive = true;
        LoadQuestion(currentQuestionIndex);
    }

    void EndExam()
    {
        isExamActive = false;
        questionTextUI.text = "CONGRATULATIONS!";
        questionImageUI.gameObject.SetActive(false);
        
        int totalPossible = 0;
        foreach(var q in questionList) totalPossible += q.correctGestureIDs.Length;
        
        feedbackTextUI.text = $"Total Score: {score}/{totalPossible}";

        if (score == totalPossible && finishClip != null && audioSource != null)
            audioSource.PlayOneShot(finishClip);

        StartCoroutine(WaitAndFinish());
    }

    void UpdateScoreUI()
    {
        int totalPossible = 0;
        foreach (var q in questionList) totalPossible += q.correctGestureIDs.Length;

        if (scoreTextUI != null)
            scoreTextUI.text = $"Score: {score}/{totalPossible}";
    }

    IEnumerator WaitAndFinish()
    {
        yield return new WaitForSeconds(autoReturnDelay);
        
        // Return visibility to secondary objects
        ToggleSecondaryObjects(true);
        
        onExamFinished?.Invoke();
    }
}