using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GestureLesson : MonoBehaviour
{
    [Header("UI References")]
    public Image progressRing;       // Vòng tròn xoay
    public TextMeshProUGUI statusText; // Chữ hướng dẫn
    public GameObject successEffect;   // Hạt pháo hoa (Particle System)

    [Header("Settings")]
    public float requiredHoldTime = 1.5f; // Thời gian cần giữ (giây)
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.gray;

    [Header("Events")]
    public UnityEvent OnLessonFinished; // Sự kiện bắn ra khi xong bài

    // Biến nội bộ
    private bool isHoldingPose = false;
    private float currentTimer = 0f;
    private bool isCompleted = false;

    void Start()
    {
        // Reset trạng thái ban đầu
        if (progressRing)
        {
            progressRing.fillAmount = 0;
            progressRing.color = inactiveColor;
        }
        if (successEffect) successEffect.SetActive(false);
    }

    // Hàm này sẽ được gọi từ Static Hand Gesture
    public void SetHoldingState(bool state)
    {
        if (isCompleted) return;
        isHoldingPose = state;

        if (state)
        {
            if (statusText) statusText.text = "Giữ nguyên...";
            if (progressRing) progressRing.color = activeColor;
        }
        else
        {
            if (statusText) statusText.text = "Hãy làm theo mẫu";
            if (progressRing) progressRing.color = inactiveColor;
        }
    }

    void Update()
    {
        if (isCompleted) return;

        // Logic tăng/giảm thanh tiến độ
        if (isHoldingPose)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            // Nếu buông tay thì tụt thanh từ từ (để đỡ bị mất hứng)
            currentTimer -= Time.deltaTime * 2;
        }

        // Kẹp giá trị từ 0 đến max
        currentTimer = Mathf.Clamp(currentTimer, 0f, requiredHoldTime);

        // Cập nhật UI
        if (progressRing)
        {
            progressRing.fillAmount = currentTimer / requiredHoldTime;
        }

        // Kiểm tra chiến thắng
        if (currentTimer >= requiredHoldTime)
        {
            CompleteLesson();
        }
    }

    void CompleteLesson()
    {
        isCompleted = true;
        if (statusText) statusText.text = "Tuyệt vời!";
        if (successEffect) successEffect.SetActive(true);

        Debug.Log("Bài học hoàn thành!");

        // Gọi Event để Game Manager biết đường chuyển bài
        OnLessonFinished.Invoke();

        // Tự hủy hoặc ẩn đi sau 2 giây
        Destroy(gameObject, 2.0f);
    }
}