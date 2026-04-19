using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

    [FormerlySerializedAs("delayNextQuestion")]
    [Tooltip("Pause (seconds) the 'PERFECT!' screen is shown before loading the next question.")]
    public float interQuestionDelay = 2.0f;

    public float autoReturnDelay = 5.0f;

    [FormerlySerializedAs("inputCooldownTime")]
    [Tooltip("Cooldown between individual character gesture inputs within a word.")]
    public float interCharCooldown = 0.8f;

    [Header("No-Penalty Letters")]
    [Tooltip("Letters where wrong inputs are silently ignored — user just retries until correct, no mistake counted.")]
    public string[] noPenaltyGestures = new string[] { "J", "Z" };

    [Header("Mistake Tolerance")]
    [Tooltip("Seconds of 'invincibility' granted after the first real mistake on a question. Wrong inputs during this window do not count.")]
    public float invincibilityDuration = 2.5f;

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
    private readonly string COLOR_BLUE  = "#5E97FF";
    private readonly string COLOR_BEIGE = "#E9C46A";
    private readonly string COLOR_RED   = "#E76F51";

    // ── Internal state ────────────────────────────────────────────────────────
    private int            currentQuestionIndex   = 0;
    private float          score                  = 0;
    private bool           isExamActive           = false;
    private List<string>   currentInputBuffer     = new List<string>();
    private int            currentQuestionMistakes = 0;
    private float          lastInputTime          = 0f;
    private float          invincibilityEndTime   = -1f;

    // ── Helpers ───────────────────────────────────────────────────────────────
    bool IsInvincible() => Time.time < invincibilityEndTime;

    void PlayAudioIfAvailable(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────
    void OnEnable()
    {
        GestureHub.OnGestureDetected += SubmitAnswer;
    }

    void OnDisable()
    {
        GestureHub.OnGestureDetected -= SubmitAnswer;
    }

    // ── Exam flow ─────────────────────────────────────────────────────────────
    public void StartExam()
    {
        ToggleSecondaryObjects(false);

        currentQuestionIndex = 0;
        score                = 0;
        isExamActive         = true;

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

        // ── Reset per-question state ──────────────────────────────────────────
        currentInputBuffer.Clear();
        currentQuestionMistakes = 0;
        lastInputTime           = 0f;
        invincibilityEndTime    = -1f;  // clear invincibility from previous question

        feedbackTextUI.text = "";

        AutoAdvanceGapFill(data);

        // ── Display question text ─────────────────────────────────────────────
        if (data.questionType == QuestionType.Ordering)
        {
            UpdateSpellingDisplay(data);
        }
        else if (data.questionType == QuestionType.Matching)
        {
            string letter = (data.correctGestureIDs != null && data.correctGestureIDs.Length > 0)
                ? data.correctGestureIDs[0] : "?";
            questionTextUI.text =
                $"<align=center><color={COLOR_BEIGE}>Identify the correct hand sign for</color>\n" +
                $"<size=200%><color={COLOR_BLUE}><b>{letter}</b></color></size></align>";
        }
        else if (data.questionType == QuestionType.AudioFillInTheGap && !string.IsNullOrEmpty(data.sentenceTemplate))
        {
            string formattedTemplate = data.sentenceTemplate.Replace("{0}", $"<color={COLOR_BLUE}>____</color>");
            questionTextUI.text = $"<align=center><color={COLOR_BEIGE}>{formattedTemplate}</color></align>";
        }
        else
        {
            questionTextUI.text = $"<align=center><color={COLOR_BEIGE}>{data.questionText}</color></align>";
        }

        // ── Image ─────────────────────────────────────────────────────────────
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

        // ── Auto-play audio for AudioFillInTheGap ─────────────────────────────
        if (data.questionType == QuestionType.AudioFillInTheGap &&
            data.questionAudio != null && audioSource != null)
        {
            audioSource.PlayOneShot(data.questionAudio);
        }

        feedbackTextUI.text  = "Waiting for input...";
        feedbackTextUI.color = Color.white;
    }

    // ── Input handling ────────────────────────────────────────────────────────
    public void SubmitAnswer(string gestureID)
    {
        if (!isExamActive || currentQuestionIndex >= questionList.Count) return;

        // ── Feature 2: inter-character cooldown ───────────────────────────────
        if (Time.time - lastInputTime < interCharCooldown) return;

        QuizData currentData   = questionList[currentQuestionIndex];
        string[] correctAnswers = currentData.correctGestureIDs;

        int nextIndex = currentInputBuffer.Count;
        if (nextIndex < correctAnswers.Length)
        {
            if (GestureHub.AreEquivalent(gestureID, correctAnswers[nextIndex]))
            {
                HandleCorrectPart(gestureID);
            }
            else
            {
                // Pass the expected letter so HandleWrongInput can check no-penalty list
                HandleWrongInput(correctAnswers[nextIndex]);
            }
        }
    }

    public void SubmitMatchingAnswer(string gestureID)
    {
        SubmitAnswer(gestureID);
    }

    // ── Correct input ─────────────────────────────────────────────────────────
    void HandleCorrectPart(string gestureID)
    {
        lastInputTime = Time.time;
        currentInputBuffer.Add(gestureID);

        QuizData currentData = questionList[currentQuestionIndex];
        AutoAdvanceGapFill(currentData);

        // Scoring: 1.0 point per question, divided by gaps
        float pointPerPart = 1.0f / GetScoreWeight(currentData);

        // Deduct based on counted mistakes (no-penalty & invincibility mistakes don't count)
        if (currentQuestionMistakes == 1)      pointPerPart *= 0.7f;
        else if (currentQuestionMistakes >= 2) pointPerPart *= 0.4f;

        score += pointPerPart;
        UpdateScoreUI();

        if (currentData.questionType == QuestionType.Ordering)
            UpdateSpellingDisplay(currentData);

        PlayAudioIfAvailable(correctClip);

        feedbackTextUI.text  = "Correct!";
        feedbackTextUI.color = new Color(0.368f, 0.592f, 1.0f); // COLOR_BLUE

        if (currentInputBuffer.Count == questionList[currentQuestionIndex].correctGestureIDs.Length)
            StartCoroutine(HandleQuestionComplete());
    }

    // ── Wrong input — Feature 1 (no-penalty) + Feature 3 (invincibility) ──────
    void HandleWrongInput(string expected)
    {
        // ── Feature 1: No-penalty letters ─────────────────────────────────────
        bool isNoPenalty = System.Array.Exists(
            noPenaltyGestures,
            g => g.Equals(expected, StringComparison.OrdinalIgnoreCase));

        if (isNoPenalty)
        {
            // No mistake counted, no feedback text — user silently retries
            return;
        }

        // ── Feature 3: Invincibility window ───────────────────────────────────
        if (IsInvincible())
        {
            // Grace period active — apply cooldown but don't increment counter
            lastInputTime = Time.time;
            feedbackTextUI.text  = $"<color={COLOR_RED}>Incorrect! ({currentQuestionMistakes}/3)</color>";
            feedbackTextUI.color = Color.white;
            return;
        }

        // ── Normal mistake path ────────────────────────────────────────────────
        lastInputTime = Time.time;
        currentQuestionMistakes++;

        PlayAudioIfAvailable(wrongClip);

        if (currentQuestionMistakes == 1)
        {
            // First real mistake → grant invincibility window silently
            invincibilityEndTime = Time.time + invincibilityDuration;
            feedbackTextUI.text  = $"<color={COLOR_RED}>Incorrect! ({currentQuestionMistakes}/3)</color>";
            feedbackTextUI.color = Color.white;
        }
        else if (currentQuestionMistakes >= 3)
        {
            feedbackTextUI.text  = $"<color={COLOR_RED}>Too many mistakes! Moving to next question.</color>";
            feedbackTextUI.color = Color.white;
            Invoke(nameof(LoadNextQuestion), 2.0f);
        }
        else
        {
            feedbackTextUI.text  = $"<color={COLOR_RED}>Incorrect! ({currentQuestionMistakes}/3)</color>";
            feedbackTextUI.color = Color.white;
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

            QuizData currentData = questionList[currentQuestionIndex];
            if (currentData.questionType == QuestionType.Ordering)
                UpdateSpellingDisplay(currentData);

            feedbackTextUI.text  = "Deleted last sign.";
            feedbackTextUI.color = Color.yellow;
        }
    }

    // ── Question complete — Feature 2: uses interQuestionDelay ────────────────
    IEnumerator HandleQuestionComplete()
    {
        isExamActive = false;

        feedbackTextUI.text  = "PERFECT!";
        feedbackTextUI.color = new Color(0.368f, 0.592f, 1.0f);

        // ── Feature 2: inter-question delay (distinct from interCharCooldown) ─
        yield return new WaitForSeconds(interQuestionDelay);

        currentQuestionIndex++;
        isExamActive = true;
        LoadQuestion(currentQuestionIndex);
    }

    // ── End of exam ───────────────────────────────────────────────────────────
    void EndExam()
    {
        isExamActive = false;
        questionTextUI.text = "CONGRATULATIONS!";
        questionImageUI.gameObject.SetActive(false);

        int totalPossible = questionList.Count;
        feedbackTextUI.text  = $"Total Score: {score:F1}/{totalPossible}";
        feedbackTextUI.color = Color.white;

        if (score == totalPossible && finishClip != null && audioSource != null)
            audioSource.PlayOneShot(finishClip);

        StartCoroutine(WaitAndFinish());
    }

    void UpdateScoreUI()
    {
        int totalPossible = questionList.Count;
        if (scoreTextUI != null)
            scoreTextUI.text =
                $"Score: <color={COLOR_BLUE}>{score:F1}</color>/<color={COLOR_RED}>{totalPossible}</color>";
    }

    IEnumerator WaitAndFinish()
    {
        yield return new WaitForSeconds(autoReturnDelay);
        ToggleSecondaryObjects(true);
        onExamFinished?.Invoke();
    }

    // ── Display helpers ───────────────────────────────────────────────────────
    void UpdateSpellingDisplay(QuizData data)
    {
        if (data == null || data.correctGestureIDs == null) return;

        string fullWord = string.Join("", data.correctGestureIDs);
        string title    = string.IsNullOrEmpty(data.sentenceTemplate)
            ? $"How do you <color={COLOR_BLUE}>spell</color> this <color={COLOR_RED}>word</color>?"
            : $"<color={COLOR_BEIGE}>Fill in the missing letters:</color>";

        string displayedText = $"{title}\n\n<size=150%>";
        int    completed     = currentInputBuffer.Count;

        if (!string.IsNullOrEmpty(data.sentenceTemplate))
        {
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
                    displayedText += c == '_'
                        ? $"<color={COLOR_BEIGE}>_</color>"
                        : $"<color={COLOR_BLUE}><b>{c}</b></color>";
                }
                if (i < fullWord.Length - 1) displayedText += " ";
            }
        }
        else
        {
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

        string temp     = data.sentenceTemplate.Replace(" ", "");
        string fullWord = string.Join("", data.correctGestureIDs);

        while (currentInputBuffer.Count < temp.Length &&
               currentInputBuffer.Count < fullWord.Length &&
               temp[currentInputBuffer.Count] != '_')
        {
            currentInputBuffer.Add(fullWord[currentInputBuffer.Count].ToString());
        }
    }

    int GetScoreWeight(QuizData data)
    {
        if (data.questionType != QuestionType.Ordering) return 1;
        if (data.correctGestureIDs == null) return 1;
        if (string.IsNullOrEmpty(data.sentenceTemplate)) return data.correctGestureIDs.Length;

        string temp  = data.sentenceTemplate.Replace(" ", "");
        int    count = 0;
        foreach (char c in temp)
        {
            if (c == '_') count++;
        }
        return count == 0 ? 1 : count;
    }
}