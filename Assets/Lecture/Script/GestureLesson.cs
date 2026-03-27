using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class GestureLesson : MonoBehaviour
{
    [Header("UI References")]
    public Image progressRing;
    public TMP_Text statusText;

    [Header("Settings")]
    public float requiredHoldTime = 1.5f;
    public float resetDelayTime = 1.5f;
    public string targetGestureID; // IF EMPTY, EXTRACT FROM defaultMessage

    [Header("Colors")]
    public Color barColor = new Color(0, 1, 0, 1);

    [Header("Messages")]
    public string defaultMessage = "Perform gesture number 1";
    public string holdingMessage = "Holding... ";
    public string successMessage = "Success!";

    [Header("Events")]
    public UnityEvent OnLessonFinished;

    private float currentHoldTime = 0f;
    private bool isGestureDetected = false;
    private bool isLessonCompleting = false;

    void Start()
    {
        if (string.IsNullOrEmpty(targetGestureID))
        {
            // Guess ID from "Perform gesture [ID]" or "Perform gesture number [ID]"
            targetGestureID = defaultMessage.Replace("Perform gesture number ", "").Replace("Perform gesture ", "").Trim();
        }
        ResetUI();
    }

    void OnEnable()
    {
        GestureHub.OnGestureDetected += HandleGestureDetected;
        GestureHub.OnGestureEnded += HandleGestureEnded;
    }

    void OnDisable()
    {
        GestureHub.OnGestureDetected -= HandleGestureDetected;
        GestureHub.OnGestureEnded -= HandleGestureEnded;
    }

    private void HandleGestureDetected(string id)
    {
        if (id == targetGestureID) SetGestureDetected(true);
    }

    private void HandleGestureEnded(string id)
    {
        if (id == targetGestureID) SetGestureDetected(false);
    }

    void Update()
    {
        if (isLessonCompleting) return;

        if (isGestureDetected)
        {
            currentHoldTime += Time.deltaTime;
            float timeRemaining = Mathf.Max(0, requiredHoldTime - currentHoldTime);
            if (statusText != null)
                statusText.text = $"{holdingMessage} {timeRemaining:F1}s";
        }
        else
        {
            currentHoldTime -= Time.deltaTime * 3;
            if (currentHoldTime <= 0 && statusText != null)
                statusText.text = defaultMessage;
        }

        currentHoldTime = Mathf.Clamp(currentHoldTime, 0, requiredHoldTime);
        UpdateUI();

        if (currentHoldTime >= requiredHoldTime)
        {
            StartCoroutine(HandleLessonCompletion());
        }
    }

    public void SetGestureDetected(bool detected)
    {
        if (!isLessonCompleting)
        {
            isGestureDetected = detected;
        }
    }

    void UpdateUI()
    {
        if (progressRing != null)
        {
            float ratio = currentHoldTime / requiredHoldTime;
            progressRing.fillAmount = ratio;
            progressRing.color = barColor;
        }
    }

    IEnumerator HandleLessonCompletion()
    {
        isLessonCompleting = true;
        isGestureDetected = false;

        if (progressRing != null) progressRing.fillAmount = 1f;
        if (statusText != null) statusText.text = successMessage;

        OnLessonFinished?.Invoke();

        yield return new WaitForSeconds(resetDelayTime);
        ResetLesson();
    }

    void ResetLesson()
    {
        currentHoldTime = 0f;
        isLessonCompleting = false;
        isGestureDetected = false;
        ResetUI();
    }

    void ResetUI()
    {
        if (progressRing != null) progressRing.fillAmount = 0;
        if (statusText != null) statusText.text = defaultMessage;
    }
}