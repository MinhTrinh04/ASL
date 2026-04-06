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

    [Header("Aesthetic Palette")]
    private readonly string COLOR_BLUE = "#5E97FF";
    private readonly string COLOR_BEIGE = "#E9C46A";
    private readonly string COLOR_RED = "#E76F51";

    // Internal state
    private int currentQuestionIndex = 0;
    private float score = 0;
    private bool isExamActive = false;
    private List<string> currentInputBuffer = new List<string>();
    private int currentQuestionMistakes = 0;

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
        if (index < 0) return;
        if (index >= questionList.Count)
        {
            EndExam();
            return;
        }

        QuizData data = questionList[index];
        currentInputBuffer.Clear();
        currentQuestionMistakes = 0;
        feedbackTextUI.text = "";

        AutoAdvanceGapFill(data);

        if (data.questionType == QuestionType.Ordering)
        {
            UpdateSpellingDisplay(data);
        }
        else if (data.questionType == QuestionType.Matching)
        {
            string letter = (data.correctGestureIDs != null && data.correctGestureIDs.Length > 0) ? data.correctGestureIDs[0] : "?";
            questionTextUI.text = $"<align=center><color={COLOR_BEIGE}>Identify the correct hand sign for</color>\n" +
                                 $"<size=200%><color={COLOR_BLUE}><b>{letter}</b></color></size></align>";
        }
        else if (data.questionType == QuestionType.AudioFillInTheGap && !string.IsNullOrEmpty(data.sentenceTemplate))
        {
            // Display ____ in the template with brand colors
            string formattedTemplate = data.sentenceTemplate.Replace("{0}", $"<color={COLOR_BLUE}>____</color>");
            questionTextUI.text = $"<align=center><color={COLOR_BEIGE}>{formattedTemplate}</color></align>";
        }
        else
        {
            questionTextUI.text = $"<align=center><color={COLOR_BEIGE}>{data.questionText}</color></align>";
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
        QuizData currentData = questionList[currentQuestionIndex];
        
        AutoAdvanceGapFill(currentData);
        
        // Scoring: 1.0 point per question, divided by gaps
        float pointPerPart = 1.0f / GetScoreWeight(currentData);
        
        // Deduction based on mistakes
        if (currentQuestionMistakes == 1) pointPerPart *= 0.7f;
        else if (currentQuestionMistakes == 2) pointPerPart *= 0.4f;
        
        score += pointPerPart;
        UpdateScoreUI();

        // Update display for Ordering questions
        if (currentData.questionType == QuestionType.Ordering)
        {
            UpdateSpellingDisplay(currentData);
        }

        if (audioSource != null && correctClip != null)
            audioSource.PlayOneShot(correctClip);

        feedbackTextUI.text = "Correct!";
        feedbackTextUI.color = new Color(0.368f, 0.592f, 1.0f); // COLOR_BLUE

        if (currentInputBuffer.Count == questionList[currentQuestionIndex].correctGestureIDs.Length)
        {
            StartCoroutine(HandleQuestionComplete());
        }
    }

    void HandleWrongInput()
    {
        currentQuestionMistakes++;

        if (audioSource != null && wrongClip != null)
            audioSource.PlayOneShot(wrongClip);

        if (currentQuestionMistakes >= 3)
        {
            feedbackTextUI.text = $"<color={COLOR_RED}>Too many mistakes! Moving to next question.</color>";
            Invoke("LoadNextQuestion", 2.0f);
        }
        else
        {
            feedbackTextUI.text = $"<color={COLOR_RED}>Incorrect! ({currentQuestionMistakes}/3). Try again.</color>";
        }
    }

    void LoadNextQuestion()
    {
        currentQuestionIndex++;
        LoadQuestion(currentQuestionIndex);
    }

    public void HandleDelete()
    {
        if (currentInputBuffer.Count > 0)
        {
            currentInputBuffer.RemoveAt(currentInputBuffer.Count - 1);
            
            // Update display for Ordering questions
            QuizData currentData = questionList[currentQuestionIndex];
            if (currentData.questionType == QuestionType.Ordering)
            {
                UpdateSpellingDisplay(currentData);
            }

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
        
        int totalPossible = questionList.Count;
        
        feedbackTextUI.text = $"Total Score: {score:F1}/{totalPossible}";

        if (score == totalPossible && finishClip != null && audioSource != null)
            audioSource.PlayOneShot(finishClip);

        StartCoroutine(WaitAndFinish());
    }

    void UpdateScoreUI()
    {
        int totalPossible = questionList.Count;

        if (scoreTextUI != null)
            scoreTextUI.text = $"Score: <color={COLOR_BLUE}>{score:F1}</color>/<color={COLOR_RED}>{totalPossible}</color>";
    }

    IEnumerator WaitAndFinish()
    {
        yield return new WaitForSeconds(autoReturnDelay);
        
        // Return visibility to secondary objects
        ToggleSecondaryObjects(true);
        
        onExamFinished?.Invoke();
    }

    void UpdateSpellingDisplay(QuizData data)
    {
        if (data == null || data.correctGestureIDs == null) return;

        string fullWord = string.Join("", data.correctGestureIDs);
        string title = string.IsNullOrEmpty(data.sentenceTemplate) ? 
            $"How do you <color={COLOR_BLUE}>spell</color> this <color={COLOR_RED}>word</color>?" :
            $"<color={COLOR_BEIGE}>Fill in the missing letters:</color>";
            
        string displayedText = $"{title}\n\n<size=150%>";
        
        int completed = currentInputBuffer.Count;

        // If we have a template like "A _ P _ E", use it for display
        if (!string.IsNullOrEmpty(data.sentenceTemplate))
        {
            // Remove spaces for logic
            string temp = data.sentenceTemplate.Replace(" ", "");
            for (int i = 0; i < fullWord.Length; i++)
            {
                if (i < completed)
                {
                    displayedText += $"<color={COLOR_BLUE}><b>{fullWord[i]}</b></color>";
                }
                else
                {
                    char c = (i < temp.Length) ? temp[i] : '_';
                    if (c == '_')
                        displayedText += $"<color={COLOR_BEIGE}>_</color>"; // Brand Beige for current/future gaps
                    else
                        displayedText += $"<color={COLOR_BLUE}><b>{c}</b></color>"; // Static letters from template are BLUE from start
                }
                if (i < fullWord.Length - 1) displayedText += " ";
            }
        }
        else
        {
            // Standard spelling display
            for (int i = 0; i < fullWord.Length; i++)
            {
                if (i < completed)
                    displayedText += $"<color={COLOR_BLUE}><b>{fullWord[i]}</b></color>";
                else if (i == completed)
                    displayedText += $"<color={COLOR_BEIGE}>{fullWord[i]}</color>";
                else
                    displayedText += $"<color=#FFFFFF55>{fullWord[i]}</color>";
                
                if (i < fullWord.Length - 1) displayedText += " ";
            }
        }
        displayedText += "</size>";
        
        questionTextUI.text = $"<align=center>{displayedText}</align>";
    }

    void AutoAdvanceGapFill(QuizData data)
    {
        if (data.questionType != QuestionType.Ordering || string.IsNullOrEmpty(data.sentenceTemplate)) return;

        string temp = data.sentenceTemplate.Replace(" ", "");
        string fullWord = string.Join("", data.correctGestureIDs);

        while (currentInputBuffer.Count < temp.Length && currentInputBuffer.Count < fullWord.Length && temp[currentInputBuffer.Count] != '_')
        {
            currentInputBuffer.Add(fullWord[currentInputBuffer.Count].ToString());
        }
    }

    int GetScoreWeight(QuizData data)
    {
        if (data.questionType != QuestionType.Ordering) return 1;
        if (data.correctGestureIDs == null) return 1;
        if (string.IsNullOrEmpty(data.sentenceTemplate)) return data.correctGestureIDs.Length;

        string temp = data.sentenceTemplate.Replace(" ", "");
        int count = 0;
        foreach (char c in temp)
        {
            if (c == '_') count++;
        }
        return count == 0 ? 1 : count;
    }
}