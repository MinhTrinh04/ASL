using UnityEngine;
using UnityEngine.Events;

public class DynamicGoodbye : MonoBehaviour
{
    [Header("Settings")]
    public float waveSpeed = 0.5f;

    [Header("Debug State")]
    [SerializeField] private bool isOpenPoseActive = false;
    [SerializeField] private bool isClosedPoseActive = false;

    private float _timer = 0f;
    private bool _isWaitingForClose = false;

    [Header("Output Event")]
    public UnityEvent OnGoodbyeDetected;

    // Hàm nối với Pose MỞ (Goodbye_Open)
    public void SetOpenPose(bool active)
    {
        isOpenPoseActive = active;

        if (active)
        {
            // Khi tay mở ra, bắt đầu đếm giờ chờ tay đóng lại
            _isWaitingForClose = true;
            _timer = 0f;
            Debug.Log("Wave Phase 1: Hand Open");
        }
    }

    // Hàm nối với Pose ĐÓNG (Goodbye_Closed)
    public void SetClosedPose(bool active)
    {
        isClosedPoseActive = active;

        // Logic kiểm tra: Đang chờ đóng + Tay thực sự đóng -> Kích hoạt
        if (active && _isWaitingForClose)
        {
            FireGoodbye();
        }
    }

    void Update()
    {
        // Nếu đang chờ gập ngón tay
        if (_isWaitingForClose)
        {
            _timer += Time.deltaTime;

            // Nếu quá thời gian mà chưa gập tay -> Hủy bỏ (Reset)
            if (_timer > waveSpeed)
            {
                _isWaitingForClose = false;
                // Debug.Log("Wave Timeout - Too slow");
            }
        }
    }

    void FireGoodbye()
    {
        Debug.Log("<color=yellow>GOODBYE DETECTED! (Wave) 👋</color>");
        OnGoodbyeDetected?.Invoke();

        // Reset ngay để người chơi có thể vẫy tiếp cái nữa (Open -> Close -> Open -> Close)
        _isWaitingForClose = false;
        _timer = 0f;
    }
}