using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NPCKyleController : MonoBehaviour
{
    public Animator kyleAnim;
    public TMP_Text practiceTextUI;
    
    [Header("Data")]
    public List<PracticeData> allPracticeData;
    
    [Header("UI Buttons")]
    public GameObject btnPractice;
    public GameObject btnStartExam;
    public GameObject btnPracticeAgain;

    private List<PracticeData> currentSessionList = new List<PracticeData>();
    private int currentQuestionIndex = 0;
    private int currentSpellingIndex = 0;
    private bool isPracticeActive = false;

    private void Update()
    {
        // Debug keys removed to avoid conflicts with New Input System.
        // Use XR Hands in VR or the Scene View to test gestures.
    }

    private void OnEnable()
    {
        GestureHub.OnGestureDetected += OnGestureInput;
    }

    private void OnDisable()
    {
        GestureHub.OnGestureDetected -= OnGestureInput;
    }
    private void Start()
    {
        if(btnPractice) 
        {
            btnPractice.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(StartPractice);
            btnPractice.SetActive(true);
        }

        if(btnPracticeAgain) 
        {
            btnPracticeAgain.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(StartPractice);
            btnPracticeAgain.SetActive(false);
        }

        if(btnStartExam) 
        {
            ClassroomManager mgr = GetComponentInParent<ClassroomManager>();
            if (mgr != null) btnStartExam.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(mgr.EnterQuizMode);
            btnStartExam.SetActive(false);
        }

        if(kyleAnim) kyleAnim.SetTrigger("wave");
        
        // Initial greeting for better UX
        if (practiceTextUI) 
            practiceTextUI.text = "<size=80%>Hi! I'm Kyle. Are you ready to practice your ASL skills?</size>";
    }

    public void StartPractice()
    {
        // Hide "Practice" or "Practice Again" buttons
        if(btnPractice) btnPractice.SetActive(false);
        if(btnPracticeAgain) btnPracticeAgain.SetActive(false);
        if(btnStartExam) btnStartExam.SetActive(false);

        GenerateRandomSession();
        
        currentQuestionIndex = 0;
        isPracticeActive = true;
        
        if (kyleAnim)
        {
            kyleAnim.ResetTrigger("think");
            kyleAnim.ResetTrigger("correct");
            kyleAnim.ResetTrigger("wave");
            kyleAnim.SetTrigger("think");
        }
        LoadPracticeStep();
    }

    private void GenerateRandomSession()
    {
        currentSessionList.Clear();
        
        // Filter into lists
        var spellings = allPracticeData.Where(d => d.targetWord.Length > 1).ToList();
        var letters = allPracticeData.Where(d => d.targetWord.Length == 1).ToList();
        
        // Shuffle
        ShuffleList(spellings);
        ShuffleList(letters);
        
        // Take exactly 2 spellings and 2 or 3 letters (let's say 3 letters for a total of 5 questions)
        var selectedSpellings = spellings.Take(2).ToList();
        var selectedLetters = letters.Take(3).ToList();
        
        currentSessionList.AddRange(selectedSpellings);
        currentSessionList.AddRange(selectedLetters);
        
        // Shuffle the final session list
        ShuffleList(currentSessionList);
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void LoadPracticeStep()
    {
        if (currentQuestionIndex >= currentSessionList.Count)
        {
            practiceTextUI.text = "<size=80%>Impressive! You've mastered these. Ready for the exam or want more practice?</size>";
            isPracticeActive = false;
            
            // Restore wave trigger to ensure Kyle returns to his default state for subsequent sessions
            if(kyleAnim) kyleAnim.SetTrigger("wave");
            
            // Show end state buttons
            if(btnPracticeAgain) btnPracticeAgain.SetActive(true);
            if(btnStartExam) btnStartExam.SetActive(true);
            
            return;
        }
        currentSpellingIndex = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        string word = currentSessionList[currentQuestionIndex].targetWord;
        
        // Dynamic title based on length for better UX
        string title = (word.Length == 1) ? "Can you show me the letter:" : "Can you spell the word:";
        
        // Vibrant color palette
        string colorCorrect = "#00FF88"; // Vibrant Green
        string colorTitle = "#CCCCCC";   // Secondary Grey
        
        // Highlighting logic
        string progress = word.Substring(0, currentSpellingIndex);
        string remaining = word.Substring(currentSpellingIndex);
        
        string highlighted = $"<color={colorCorrect}>{progress}</color>{remaining}";
        
        // Structured Layout: Title (small, grey) + Word (large, bold, highlighted)
        practiceTextUI.text = $"<size=70%><color={colorTitle}>{title}</color></size>\n" +
                              $"<size=120%><b>{highlighted}</b></size>";
    }

    public void OnGestureInput(string gestureID)
    {
        if (!isPracticeActive) return;

        string target = currentSessionList[currentQuestionIndex].gestureSequence[currentSpellingIndex];

        // Use equivalence grouping for M, N, T to improve user experience
        if (GestureHub.AreEquivalent(gestureID, target))
        {
            currentSpellingIndex++;
            UpdateUI();

            if (currentSpellingIndex >= currentSessionList[currentQuestionIndex].gestureSequence.Count)
            {
                StartCoroutine(CorrectSequence());
            }
        }
    }

    IEnumerator CorrectSequence()
    {
        isPracticeActive = false;

        // Random encouraging success messages
        string[] successMessages = { "Perfect!", "Well done!", "You got it!", "Excellent!" };
        string randomSuccess = successMessages[Random.Range(0, successMessages.Length)];
        
        practiceTextUI.text = $"<color=#00FF88>{randomSuccess}</color>";
        if(kyleAnim) kyleAnim.SetTrigger("correct");
 
        // Small delay to let the trigger settle
        yield return new WaitForSeconds(0.1f);
        
        // Wait until the transition to "Correct" (index 0) is complete
        while (kyleAnim && kyleAnim.IsInTransition(0))
            yield return null;
            
        // Now capture the actual duration of the Correct animation clip
        float animDuration = 2f; // Fallback
        if (kyleAnim)
        {
            var stateInfo = kyleAnim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Correct"))
            {
                animDuration = stateInfo.length;
            }
        }
        
        yield return new WaitForSeconds(animDuration);

        currentQuestionIndex++;
        isPracticeActive = true;
        
        // Only return to "Thinking" state if we have more questions to ask.
        // This prevents a conflict with the "wave" trigger at the end of the session.
        if (currentQuestionIndex < currentSessionList.Count)
        {
            if (kyleAnim) kyleAnim.SetTrigger("think");
        }
        
        LoadPracticeStep();
    }
}