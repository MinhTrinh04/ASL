using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DynamicGoodbye : MonoBehaviour
{
    [Header("Settings")]
    public float waveSpeed = 0.5f;

    [SerializeField]
    Image m_Background;

    [Header("Debug State")]
    [SerializeField] private bool isOpenPoseActive = false;
    [SerializeField] private bool isClosedPoseActive = false;
    [SerializeField] private bool isGestureActive = false;

    private float _timer = 0f;
    private bool _isWaitingForClose = false;

    [Header("Dynamic Gesture Event")]
    public UnityEvent DynamicGestureDetected; 
    public UnityEvent DynamicGestureEnded;  

    [SerializeField]
    Image m_Highlight;

    Color m_BackgroundDefaultColor;
    Color m_BackgroundHighlightColor = new Color(0f, 0.627451f, 1f);
    void Awake()
    {
        m_BackgroundDefaultColor = m_Background.color;
        if (m_Highlight)
        {
            m_Highlight.enabled = false;
            m_Highlight.gameObject.SetActive(true);
        }
    }

    public void SetOpenPose(bool active)
    {
        isOpenPoseActive = active;

        if (active && !isGestureActive)
        {
            _isWaitingForClose = true;
            _timer = 0f;
        }
    }

    public void SetClosedPose(bool active)
    {
        isClosedPoseActive = active;

        if (active && _isWaitingForClose && !isGestureActive)
        {
            FireGoodbye();
        }

        else if (!active && isGestureActive)
        {
            EndGoodbye();
        }
    }

    void Update()
    {
        if (_isWaitingForClose)
        {
            _timer += Time.deltaTime;

            if (_timer > waveSpeed)
            {
                _isWaitingForClose = false;
            }
        }
    }

    void FireGoodbye()
    {
        Debug.Log("<color=yellow>GOODBYE DETECTED! (Wave) 👋</color>");

        isGestureActive = true;
        _isWaitingForClose = false;
        _timer = 0f;

        if (m_Highlight)
        {
            m_Highlight.enabled = true;
        }

        DynamicGestureDetected?.Invoke();
        m_Background.color = m_BackgroundHighlightColor;
    }

    void EndGoodbye()
    {
        isGestureActive = false;

        if (m_Highlight)
        {
            m_Highlight.enabled = false;
        }

        DynamicGestureEnded?.Invoke();
        m_Background.color = m_BackgroundDefaultColor;
    }
}