using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class GestureLesson : MonoBehaviour
{
    [Header("UI References")]
    public Image progressRing;       // KÉO OBJECT "PROGRESS" (CON) VÀO ĐÂY
    public TMP_Text statusText;      // Kéo Text vào đây

    [Header("Settings")]
    public float requiredHoldTime = 1.5f;
    public float resetDelayTime = 1.5f;

    [Header("Colors")]
    public Color barColor = new Color(0, 1, 0, 1); // Màu xanh lá khi chạy

    [Header("Messages")]
    public string defaultMessage = "Perform gesture number 1";
    public string holdingMessage = "Holding... ";
    public string successMessage = "Success!";

    [Header("Events")]
    public UnityEvent OnLessonFinished;

    // Biến nội bộ
    private float currentHoldTime = 0f;
    private bool isGestureDetected = false;
    private bool isLessonCompleting = false;

    void Start()
    {
        ResetUI();
    }

    void Update()
    {
        // 1. Nếu đang chờ reset (đã xong bài) thì không làm gì
        if (isLessonCompleting) return;

        // 2. Logic tính toán thời gian giữ tay
        if (isGestureDetected)
        {
            currentHoldTime += Time.deltaTime;

            // Hiển thị đếm ngược cho ngầu
            float timeRemaining = Mathf.Max(0, requiredHoldTime - currentHoldTime);
            if (statusText != null)
                statusText.text = $"{holdingMessage} {timeRemaining:F1}s";
        }
        else
        {
            // Bỏ tay ra thì tụt nhanh
            currentHoldTime -= Time.deltaTime * 3;

            // Trả về text mặc định
            if (currentHoldTime <= 0 && statusText != null)
                statusText.text = defaultMessage;
        }

        // Kẹp giá trị trong khoảng 0 đến max
        currentHoldTime = Mathf.Clamp(currentHoldTime, 0, requiredHoldTime);

        // 3. Cập nhật thanh Bar
        UpdateUI();

        // 4. Kiểm tra hoàn thành
        if (currentHoldTime >= requiredHoldTime)
        {
            StartCoroutine(HandleLessonCompletion());
        }
    }

    // Giữ nguyên tên hàm để không bị lỗi Inspector
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
            // Tính phần trăm (0 đến 1)
            float ratio = currentHoldTime / requiredHoldTime;

            progressRing.fillAmount = ratio;
            progressRing.color = barColor; // Luôn giữ màu xanh lá
        }
    }

    IEnumerator HandleLessonCompletion()
    {
        isLessonCompleting = true;
        isGestureDetected = false;

        // Hiển thị trạng thái thành công
        if (progressRing != null) progressRing.fillAmount = 1f;
        if (statusText != null) statusText.text = successMessage;

        // Gọi sự kiện
        OnLessonFinished?.Invoke();

        // Chờ 1.5 giây
        yield return new WaitForSeconds(resetDelayTime);

        // Reset lại từ đầu
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
        if (progressRing != null)
        {
            progressRing.fillAmount = 0; // Ẩn thanh xanh lá đi (lộ ra nền xanh dương bên dưới)
        }
        if (statusText != null)
        {
            statusText.text = defaultMessage;
        }
    }
}