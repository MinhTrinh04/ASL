using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCLobbyInstructorController : MonoBehaviour
{
    [Header("References")]
    public Animator kyleAnim;
    public TMP_Text dialogueText;
    public TMP_Text pageIndicatorText;
    public Button backButton;
    public Button nextButton;
    public TMP_Text nextButtonText;

    [Header("Sequential Slides")]
    [TextArea(3, 10)]
    public string[] dialogueSlides = new string[]
    {
        "Welcome to ASL Learning VR! I'm Kyle, your virtual instructor.",
        "In this lobby, feel free to look at the physical hand models set up on the desks in front of you and try to follow them to practice basic signs.",
        "You will also find a custom learning dashboard menu attached to your left wrist. Our program is divided into three key courses: Alphabets, Numbers, and Greetings.",
        "Please select a classroom from your wrist menu to enter it and begin your learning process! I hope you enjoy the lessons! Happy learning!"
    };

    private int currentSlideIndex = 0;

    private void Start()
    {
        currentSlideIndex = 0;
        UpdateDialogueState();
    }

    public void NextSlide()
    {
        if (dialogueSlides == null || dialogueSlides.Length == 0) return;

        if (currentSlideIndex == dialogueSlides.Length - 1)
        {
            // Wrap back to slide 1
            currentSlideIndex = 0;
        }
        else
        {
            currentSlideIndex++;
        }

        UpdateDialogueState();
    }

    public void PrevSlide()
    {
        if (dialogueSlides == null || dialogueSlides.Length == 0) return;

        if (currentSlideIndex > 0)
        {
            currentSlideIndex--;
        }

        UpdateDialogueState();
    }

    private void UpdateDialogueState()
    {
        if (dialogueSlides == null || dialogueSlides.Length == 0) return;

        // Clamp index just in case
        currentSlideIndex = Mathf.Clamp(currentSlideIndex, 0, dialogueSlides.Length - 1);

        // 1. Update text content
        if (dialogueText)
        {
            dialogueText.text = dialogueSlides[currentSlideIndex];
        }

        // 2. Update page indicator
        if (pageIndicatorText)
        {
            pageIndicatorText.text = $"{currentSlideIndex + 1} / {dialogueSlides.Length}";
        }

        // 3. Configure buttons state
        if (backButton)
        {
            // Hide or make non-interactable on the first slide
            backButton.gameObject.SetActive(currentSlideIndex > 0);
        }

        if (nextButtonText)
        {
            if (currentSlideIndex == dialogueSlides.Length - 1)
            {
                nextButtonText.text = "Got it!";
            }
            else
            {
                nextButtonText.text = ">";
            }
        }

        // 4. Handle animations based on the active slide
        // Slides 1 (0) and 4 (3) play "wave", Slides 2 (1) and 3 (2) play "think"
        string animTrigger = (currentSlideIndex == 0 || currentSlideIndex == 3) ? "wave" : "think";
        TriggerAnimation(animTrigger);
    }

    private void TriggerAnimation(string trigger)
    {
        if (kyleAnim)
        {
            kyleAnim.ResetTrigger("think");
            kyleAnim.ResetTrigger("wave");
            kyleAnim.SetTrigger(trigger);
        }
    }
}
