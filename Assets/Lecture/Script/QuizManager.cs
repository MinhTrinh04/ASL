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
    public GameObject playAudioButton; // Nút audio play

    [Header("Exam Config")]
    public int topicIndex = 0; 
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


    [Header("Audio Feedback")]
    public AudioSource audioSource;
    public AudioClip correctClip;
    public AudioClip wrongClip;
    public AudioClip finishClip;
    public AudioClip quizBGMLoop;

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
    private int            hiddenMistakes         = 0;
    private string         lastWrongGesture       = "";
    private float          lastCorrectInputTime   = 0f;
    private float          lastWrongInputTime     = 0f;
    private float          questionStartTime      = 0f;
    private float          invincibilityEndTime   = -1f;

    private AudioSource    bgmAudioSource;

    private AudioSource GetBgmAudioSource()
    {
        if (bgmAudioSource == null)
        {
            AudioSource[] sources = GetComponents<AudioSource>();
            if (sources.Length >= 2)
            {
                foreach (var src in sources)
                {
                    if (src != audioSource)
                    {
                        bgmAudioSource = src;
                        break;
                    }
                }
            }
            if (bgmAudioSource == null)
            {
                bgmAudioSource = gameObject.AddComponent<AudioSource>();
                Debug.Log($"[QuizManager] Added bgmAudioSource dynamically on '{gameObject.name}'");
            }
            else
            {
                Debug.Log($"[QuizManager] Reused existing AudioSource for BGM on '{gameObject.name}'");
            }

            bgmAudioSource.playOnAwake = false;
            bgmAudioSource.loop = true;
            bgmAudioSource.enabled = true;

            // Sync settings
            if (audioSource != null)
            {
                bgmAudioSource.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
                bgmAudioSource.spatialBlend = audioSource.spatialBlend;
                bgmAudioSource.minDistance = audioSource.minDistance;
                bgmAudioSource.maxDistance = audioSource.maxDistance;
                bgmAudioSource.rolloffMode = audioSource.rolloffMode;
            }
        }
        return bgmAudioSource;
    }

    private GameObject GetPlayAudioButton()
    {
        if (playAudioButton == null)
        {
            Transform canvasTrans = transform.Find("AudioCanvas");
            if (canvasTrans != null)
            {
                playAudioButton = canvasTrans.gameObject;
                Debug.Log($"[QuizManager] Found playAudioButton (AudioCanvas) on '{gameObject.name}'");
            }
            else
            {
                Debug.LogWarning($"[QuizManager] AudioCanvas NOT found on '{gameObject.name}'!");
            }
        }
        return playAudioButton;
    }

    // ── Helpers ───────────────────────────────────────────────────────────────
    bool IsInvincible() => Time.time < invincibilityEndTime;

    void PlayAudioIfAvailable(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────
    void Awake()
    {
        Debug.Log($"[QuizManager] Awake called on '{gameObject.name}'");
        // Tự động đồng bộ topicIndex từ ClassroomManager cha
        // Đảm bảo score được lưu vào đúng key mà không cần set thủ công trong Inspector
        ClassroomManager parentMgr = GetComponentInParent<ClassroomManager>(true);
        if (parentMgr != null)
        {
            topicIndex = parentMgr.topicIndex;
        }

        // Force full volume for SFX/pronunciations
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.volume = 1.0f;
        }

        // Setup background music AudioSource
        GetBgmAudioSource();

        // Auto-locate AudioCanvas and hide initially
        GameObject audioBtn = GetPlayAudioButton();
        if (audioBtn != null)
        {
            audioBtn.SetActive(false);
        }
    }

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
        Debug.Log($"[QuizManager] StartExam called on '{gameObject.name}'");
        ShuffleQuestions();
        currentQuestionIndex = 0;
        score                = 0;
        isExamActive         = true;

        if (examCanvas != null) examCanvas.SetActive(true);

        // Start BGM loop if available on bgmAudioSource
        AudioSource bgm = GetBgmAudioSource();
        if (bgm != null && quizBGMLoop != null)
        {
            bgm.clip = quizBGMLoop;
            bgm.loop = true;
            bgm.volume = 0.15f; // Increased default background music volume to 15% (clearly audible)
            bgm.Play();
            Debug.Log($"[QuizManager] Started playing BGM: '{quizBGMLoop.name}' on '{gameObject.name}'");
        }
        else
        {
            Debug.LogWarning($"[QuizManager] Cannot play BGM. bgm: {bgm != null}, clip: {quizBGMLoop != null}");
        }

        LoadQuestion(0);
        UpdateScoreUI();
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
        hiddenMistakes          = 0;
        lastWrongGesture        = "";
        lastCorrectInputTime    = 0f;
        lastWrongInputTime      = 0f;
        questionStartTime       = Time.time;
        invincibilityEndTime    = -1f;  // clear invincibility from previous question

        feedbackTextUI.text = "";

        AutoAdvanceGapFill(data);

        // ── Display question text ─────────────────────────────────────────────
        if (data.questionType == QuestionType.Ordering || data.questionType == QuestionType.AudioFillInTheGap)
        {
            UpdateSpellingDisplay(data);
        }
        else if (data.questionType == QuestionType.Matching)
        {
            string letter = (data.correctGestureIDs != null && data.correctGestureIDs.Length > 0)
                ? data.correctGestureIDs[0] : "?";
                        questionTextUI.text =
                $"\n\n<align=center><color={COLOR_BEIGE}>Identify the correct hand sign for</color>\n" +
                $"<size=180%><color={COLOR_BLUE}><b>{letter}</b></color></size></align>";
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

        GameObject audioBtn = GetPlayAudioButton();
        if (audioBtn != null)
        {
            bool isAudioQuestion = (data.questionType == QuestionType.AudioFillInTheGap && data.questionAudio != null);
            audioBtn.SetActive(isAudioQuestion);
            Debug.Log($"[QuizManager] LoadQuestion: isAudioQuestion = {isAudioQuestion} for '{data.name}'");
        }

        feedbackTextUI.text  = "Waiting for input...";
        feedbackTextUI.color = Color.white;
    }

    // ── Input handling ────────────────────────────────────────────────────────
    public void SubmitAnswer(string gestureID)
    {
        if (!isExamActive || currentQuestionIndex >= questionList.Count) return;

        // Block input for the first second of a new question
        if (Time.time - questionStartTime < 1.0f) return;

        // Ignore empty or neutral gestures
        if (string.IsNullOrEmpty(gestureID) || gestureID.Equals("Idle", StringComparison.OrdinalIgnoreCase) || gestureID.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        QuizData currentData   = questionList[currentQuestionIndex];
        string[] correctAnswers = currentData.correctGestureIDs;

        int nextIndex = currentInputBuffer.Count;
        if (nextIndex < correctAnswers.Length)
        {
            Debug.Log($"[Quiz] Comparing Input: '{gestureID}' with Expected: '{correctAnswers[nextIndex]}'");
            
            if (GestureHub.AreEquivalent(gestureID, correctAnswers[nextIndex]))
            {
                // ── Feature 2: inter-character cooldown ONLY for correct inputs ──
                if (Time.time - lastCorrectInputTime < interCharCooldown) 
                {
                    Debug.Log("[Quiz] Correct input ignored due to interCharCooldown.");
                    return;
                }

                HandleCorrectPart(gestureID);
                lastWrongGesture = ""; // Reset on correct
            }
            else
            {
                // Throttle wrong inputs to prevent rapid-fire mistakes during hand transition
                if (Time.time - lastWrongInputTime < 0.5f) return;

                // Pass the expected letter so HandleWrongInput can check no-penalty list
                HandleWrongInput(correctAnswers[nextIndex], gestureID);
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
        lastCorrectInputTime = Time.time;
        currentInputBuffer.Add(gestureID);
        hiddenMistakes = 0; // Reset hidden mistakes on successful input segment

        QuizData currentData = questionList[currentQuestionIndex];
        AutoAdvanceGapFill(currentData);

        // Scoring: 1.0 point per question, divided by gaps
        float pointPerPart = 1.0f / GetScoreWeight(currentData);

        // Deduct based on counted mistakes (no-penalty & invincibility mistakes don't count)
        if (currentQuestionMistakes == 1)      pointPerPart *= 0.7f;
        else if (currentQuestionMistakes >= 2) pointPerPart *= 0.4f;

        score += pointPerPart;
        UpdateScoreUI();

        if (currentData.questionType == QuestionType.Ordering || currentData.questionType == QuestionType.AudioFillInTheGap)
            UpdateSpellingDisplay(currentData);

        feedbackTextUI.text  = "Correct!";
        feedbackTextUI.color = new Color(0.368f, 0.592f, 1.0f); // COLOR_BLUE

        if (currentInputBuffer.Count == questionList[currentQuestionIndex].correctGestureIDs.Length)
        {
            PlayAudioIfAvailable(correctClip);
            StartCoroutine(HandleQuestionComplete());
        }
    }

    // ── Wrong input — Feature 1 (no-penalty) + Hidden Mistakes ────────────────
    void HandleWrongInput(string expected, string gestureID)
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

        // Prevent continuous penalty for holding the exact same wrong gesture
        if (gestureID == lastWrongGesture) return;
        lastWrongGesture = gestureID;

        // ── Normal mistake path with hidden mistakes ───────────────────────────
        
        // ── Feature 3: Invincibility window ───────────────────────────────────
        if (IsInvincible())
        {
            // Grace period active — apply cooldown but don't increment counter
            lastWrongInputTime = Time.time;
            int attemptsLeftInv = 3 - currentQuestionMistakes;
            feedbackTextUI.text  = $"<color={COLOR_RED}>Try again! ({attemptsLeftInv} attempts left)</color>";
            feedbackTextUI.color = Color.white;
            return;
        }

        lastWrongInputTime = Time.time;
        hiddenMistakes++;

        if (hiddenMistakes >= 3)
        {
            PlayAudioIfAvailable(wrongClip);
            // 3 hidden mistakes count as 1 actual penalty
            currentQuestionMistakes++;
            hiddenMistakes = 0; // Reset for the next penalty cycle

            if (currentQuestionMistakes >= 3)
            {
                feedbackTextUI.text  = $"<color={COLOR_RED}>Too many mistakes! Moving to next question.</color>";
                feedbackTextUI.color = Color.white;
                Invoke(nameof(LoadNextQuestion), 2.0f);
            }
            else
            {
                if (currentQuestionMistakes == 1)
                {
                    // First real mistake → grant invincibility window silently
                    invincibilityEndTime = Time.time + invincibilityDuration;
                }
                int attemptsLeft = 3 - currentQuestionMistakes;
                feedbackTextUI.text  = $"<color={COLOR_RED}>Try again! ({attemptsLeft} attempts left)</color>";
                feedbackTextUI.color = Color.white;
            }
        }
        else
        {
            // Hidden mistake: No text change, user silently retries (audio still plays)
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
            if (currentData.questionType == QuestionType.Ordering || currentData.questionType == QuestionType.AudioFillInTheGap)
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

        // Stop BGM loop on bgmAudioSource
        AudioSource bgm = GetBgmAudioSource();
        if (bgm != null)
        {
            bgm.Stop();
        }

        GameObject audioBtn = GetPlayAudioButton();
        if (audioBtn != null)
        {
            audioBtn.SetActive(false);
        }

        int totalPossible = questionList.Count;
        float percentage = (totalPossible > 0) ? (score / totalPossible) * 100f : 0f;

        feedbackTextUI.text  = $"Total Score: {score:F1}/{totalPossible} ({percentage:F0}%)";
        feedbackTextUI.color = Color.white;

        // ── Report to ProgressManager ─────────────────────────────────────────
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.SaveTopicScore(topicIndex, percentage);

            if (percentage >= ProgressManager.Instance.passingGrade)
            {
                feedbackTextUI.text += "\n<color=#5E97FF>Topic Mastered! Next unlocked.</color>";
            }
        }

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

    private void ShuffleQuestions()
    {
        if (questionList == null || questionList.Count == 0) return;
        for (int i = 0; i < questionList.Count; i++)
        {
            QuizData temp = questionList[i];
            int randomIndex = UnityEngine.Random.Range(i, questionList.Count);
            questionList[i] = questionList[randomIndex];
            questionList[randomIndex] = temp;
        }
    }

    IEnumerator WaitAndFinish()
    {
        yield return new WaitForSeconds(autoReturnDelay);
        onExamFinished?.Invoke();
    }

    // ── Display helpers ───────────────────────────────────────────────────────
    void UpdateSpellingDisplay(QuizData data)
    {
        if (data == null || data.correctGestureIDs == null) return;

        bool isNumbers = data.topic != null && data.topic.Equals("Numbers", StringComparison.OrdinalIgnoreCase);
        string missingType = isNumbers ? "numbers" : "letters";
        
        string title = "";
        if (data.questionType == QuestionType.AudioFillInTheGap)
        {
            title = "<color=" + COLOR_BEIGE + ">Listen and spell the word:</color>";
        }
        else if (!string.IsNullOrEmpty(data.questionText))
        {
            title = $"<color={COLOR_BEIGE}><size=100%>{data.questionText}</size></color>";
        }
        else
        {
            title = string.IsNullOrEmpty(data.sentenceTemplate)
                ? $"<color={COLOR_BEIGE}>How do you spell this word?</color>"
                : $"<color={COLOR_BEIGE}>Fill in the missing {missingType}:</color>";
        }

        string displayedText = $"\n\n{title}\n\n<size=180%>";
        int    completed     = currentInputBuffer.Count;

        if (data.questionType == QuestionType.AudioFillInTheGap)
        {
            for (int i = 0; i < data.correctGestureIDs.Length; i++)
            {
                if (i < completed)
                {
                    displayedText += $"<color={COLOR_BLUE}><b>{data.correctGestureIDs[i]}</b></color>";
                }
                else
                {
                    displayedText += $"<color={COLOR_BEIGE}>_</color>";
                }

                if (i < data.correctGestureIDs.Length - 1) displayedText += " ";
            }
        }
        else if (!string.IsNullOrEmpty(data.sentenceTemplate))
        {
            string template = data.sentenceTemplate;
            int bufferPointer = 0; // Maps to index in currentInputBuffer/IDs

            for (int i = 0; i < template.Length; i++)
            {
                char c = template[i];
                if (c == ' ')
                {
                    displayedText += " ";
                    continue;
                }

                if (c != '_')
                {
                    // Static character from template
                    if (!isNumbers && bufferPointer < completed && bufferPointer < data.correctGestureIDs.Length)
                    {
                        // Alphabet mode (Full Sequence): Highlighting the static char if completed
                        displayedText += $"<color={COLOR_BLUE}><b>{data.correctGestureIDs[bufferPointer]}</b></color>";
                        bufferPointer++;
                    }
                    else
                    {
                        // Numbers mode (Gap Only) or uncompleted Alphabet static char
                        displayedText += $"<color={COLOR_BLUE}><b>{c}</b></color>";
                        if (!isNumbers) bufferPointer++;
                    }
                }
                else
                {
                    // Interactive gap
                    if (bufferPointer < completed && bufferPointer < data.correctGestureIDs.Length)
                    {
                        // FIX: Show the TARGET gesture from data (fixes Banana E/N bug)
                        displayedText += $"<color={COLOR_BLUE}><b>{data.correctGestureIDs[bufferPointer]}</b></color>";
                    }
                    else
                    {
                        displayedText += $"<color={COLOR_BEIGE}>_</color>";
                    }
                    bufferPointer++;
                }
            }
        }
        else
        {
            // Standard spelling (no template)
            for (int i = 0; i < data.correctGestureIDs.Length; i++)
            {
                if (i < completed)
                    displayedText += $"<color={COLOR_BLUE}><b>{data.correctGestureIDs[i]}</b></color>";
                else if (i == completed)
                    displayedText += $"<color={COLOR_BEIGE}>{data.correctGestureIDs[i]}</color>";
                else
                    displayedText += $"<color=#FFFFFF55>{data.correctGestureIDs[i]}</color>";

                if (i < data.correctGestureIDs.Length - 1) displayedText += " ";
            }
        }

        displayedText += "</size>";
        questionTextUI.text = $"<align=center>{displayedText}</align>";
    }

    void AutoAdvanceGapFill(QuizData data)
    {
        if (data.questionType == QuestionType.AudioFillInTheGap) return;
        if ((data.questionType != QuestionType.Ordering && data.questionType != QuestionType.AudioFillInTheGap) || string.IsNullOrEmpty(data.sentenceTemplate)) return;

        bool isNumbers = data.topic != null && data.topic.Equals("Numbers", StringComparison.OrdinalIgnoreCase);
        if (isNumbers) return; // Numbers mode is Gap-Only, no auto-advance needed.

        // Alphabets mode: Full-Sequence auto-advance
        string temp = data.sentenceTemplate.Replace(" ", "");
        while (currentInputBuffer.Count < temp.Length && 
               currentInputBuffer.Count < data.correctGestureIDs.Length && 
               temp[currentInputBuffer.Count] != '_')
        {
            currentInputBuffer.Add(data.correctGestureIDs[currentInputBuffer.Count]);
        }
    }

    int GetScoreWeight(QuizData data)
    {
        if (data.questionType == QuestionType.AudioFillInTheGap) return data.correctGestureIDs.Length;
        if (data.questionType != QuestionType.Ordering && data.questionType != QuestionType.AudioFillInTheGap) return 1;
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

    public void ReplayQuestionAudio()
    {
        if (currentQuestionIndex < questionList.Count)
        {
            QuizData currentData = questionList[currentQuestionIndex];
            if (currentData != null && currentData.questionAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(currentData.questionAudio);
                Debug.Log($"[QuizManager] Replaying audio: {currentData.name}");
            }
            else
            {
                Debug.LogWarning("[QuizManager] Cannot replay: missing clip or source.");
            }
        }
    }
}