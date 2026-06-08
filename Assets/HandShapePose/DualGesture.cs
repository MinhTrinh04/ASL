using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class DualGesture : MonoBehaviour
{
    [Header("Settings")]
    public string gestureName = "Default";

    [Header("UI Feedback")]
    [SerializeField]
    private Image m_Background;

    [SerializeField]
    private Image m_Highlight;

    [Header("Trigger Poses (IDs from GestureHub)")]
    [Tooltip("Danh sách các ID cử chỉ tĩnh của tay trái để tự động kích hoạt qua GestureHub.")]
    public List<string> leftHandPoseIDs = new List<string>();

    [Tooltip("Danh sách các ID cử chỉ tĩnh của tay phải để tự động kích hoạt qua GestureHub.")]
    public List<string> rightHandPoseIDs = new List<string>();

    [Header("Dual Gesture Event")]
    public UnityEvent OnDualGesturePerformed;
    public UnityEvent OnDualGestureEnded;

    [Header("Hands State")]
    public bool isLeftHandReady = false;
    public bool isRightHandReady = false;

    private bool _wasActive = false;
    private Color m_BackgroundDefaultColor;
    private Color m_BackgroundHighlightColor = new Color(0f, 0.627451f, 1f);

    void OnEnable()
    {
        GestureHub.OnGestureDetected += HandleGlobalDetected;
        GestureHub.OnGestureEnded += HandleGlobalEnded;
    }

    void OnDisable()
    {
        GestureHub.OnGestureDetected -= HandleGlobalDetected;
        GestureHub.OnGestureEnded -= HandleGlobalEnded;
    }

    void Awake()
    {
        if (m_Background == null)
            m_Background = GetComponent<Image>();

        if (m_Background != null)
        {
            m_BackgroundDefaultColor = m_Background.color;
        }

        if (m_Highlight == null)
        {
            Transform highlightTransform = transform.Find("HighlightOutline");
            if (highlightTransform != null)
            {
                m_Highlight = highlightTransform.GetComponent<Image>();
            }
        }

        if (m_Highlight != null)
        {
            m_Highlight.enabled = false;
            m_Highlight.gameObject.SetActive(true);
        }
    }

    private void HandleGlobalDetected(string id)
    {
        bool changed = false;
        if (leftHandPoseIDs.Contains(id))
        {
            isLeftHandReady = true;
            changed = true;
        }
        if (rightHandPoseIDs.Contains(id))
        {
            isRightHandReady = true;
            changed = true;
        }

        if (changed)
        {
            CheckDualState();
        }
    }

    private void HandleGlobalEnded(string id)
    {
        bool changed = false;
        if (leftHandPoseIDs.Contains(id))
        {
            isLeftHandReady = false;
            changed = true;
        }
        if (rightHandPoseIDs.Contains(id))
        {
            isRightHandReady = false;
            changed = true;
        }

        if (changed)
        {
            CheckDualState();
        }
    }

    [System.Obsolete("Use GestureHub auto-detection instead by filling in Left/Right Hand Pose IDs")]
    public void SetLeftHand(bool active)
    {
        isLeftHandReady = active;
        CheckDualState();
    }

    [System.Obsolete("Use GestureHub auto-detection instead by filling in Left/Right Hand Pose IDs")]
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

            GestureHub.Publish(gestureName, true);
            OnDualGesturePerformed?.Invoke();
            _wasActive = true;
        }
        else if (!areBothActive && _wasActive)
        {
            UpdateUI(false);

            GestureHub.Publish(gestureName, false);
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

        if (m_Highlight != null)
        {
            m_Highlight.enabled = isActive;
        }
    }
}