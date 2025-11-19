using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // Cần thêm thư viện này để xử lý Image

public class DualGesture : MonoBehaviour
{
    [Header("Settings")]
    public string gestureName = "Default";

    [Header("UI Feedback")]
    [SerializeField]
    [Tooltip("Ảnh nền icon")]
    Image m_Background;

    [SerializeField]
    [Tooltip("Viền sáng highlight")]
    Image m_Highlight;

    Color m_BackgroundDefaultColor;
    Color m_BackgroundHighlightColor = new Color(0f, 0.627451f, 1f);

    [Header("Hands State")]
    public bool isLeftHandReady = false;
    public bool isRightHandReady = false;

    [Header("Dual Gesture Event")]
    public UnityEvent OnDualGesturePerformed;
    public UnityEvent OnDualGestureEnded;

    private bool _wasActive = false;

    void Awake()
    {
        if (m_Background != null)
        {
            m_BackgroundDefaultColor = m_Background.color;
        }

        if (m_Highlight != null)
        {
            m_Highlight.enabled = false;
            m_Highlight.gameObject.SetActive(true);
        }
    }

    public void SetLeftHand(bool active)
    {
        isLeftHandReady = active;
        CheckDualState();
    }

    public void SetRightHand(bool active)
    {
        isRightHandReady = active;
        CheckDualState();
    }

    private void CheckDualState()
    {
        bool areBothActive = isLeftHandReady && isRightHandReady;

        if (areBothActive && !_wasActive)
        {
            Debug.Log($"<color=yellow>{gestureName} DETECTED!</color>");

            UpdateUI(true);

            OnDualGesturePerformed?.Invoke();
            _wasActive = true;
        }
        else if (!areBothActive && _wasActive)
        {
            UpdateUI(false);

            OnDualGestureEnded?.Invoke();
            _wasActive = false;
        }
    }

    private void UpdateUI(bool isActive)
    {
        if (m_Background != null)
        {
            m_Background.color = isActive ? m_BackgroundHighlightColor : m_BackgroundDefaultColor;
        }

        if (m_Highlight)
        {
            m_Highlight.enabled = true;
        }
    }
}