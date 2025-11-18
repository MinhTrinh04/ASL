using UnityEngine;
using UnityEngine.Events;

public class DynamicHelloGesture : MonoBehaviour
{
    [Header("1. Cấu hình tham chiếu")]
    public Transform headTransform; // Kéo Main Camera vào đây
    public Transform handTransform; // Kéo đối tượng tay phải vào đây

    [Header("2. Thông số tinh chỉnh")]
    [Tooltip("Khoảng cách tối đa từ tay đến đầu để BẮT ĐẦU (mét)")]
    public float startDistance = 0.25f; // 25cm (gần trán)

    [Tooltip("Khoảng cách tối thiểu tay phải đi ra xa để KẾT THÚC (mét)")]
    public float endDistance = 0.45f;   // 45cm (đưa tay ra xa)

    [Tooltip("Thời gian tối đa để thực hiện động tác (giây)")]
    public float gestureTimeout = 1.5f; // Nếu quá 1.5s mà chưa đưa tay ra thì hủy

    [Header("3. Trạng thái (Chỉ để xem, không sửa)")]
    [SerializeField] private bool isPoseCorrect = false; // Biến này sẽ được bật/tắt bởi Static Gesture
    [SerializeField] private bool isMotionStarted = false;
    private float timer = 0f;

    [Header("4. Sự kiện Output")]
    public UnityEvent OnHelloDetected; // Kéo hàm xử lý vào đây (ví dụ: Show UI, Play Sound)

    void Update()
    {
        if (headTransform == null || handTransform == null) return;

        // Tính khoảng cách hiện tại giữa Tay và Đầu
        float currentDist = Vector3.Distance(handTransform.position, headTransform.position);

        // --- GIAI ĐOẠN 1: CHUẨN BỊ (START) ---
        // Điều kiện: Dáng tay đúng (B-Hand) VÀ Tay đang ở gần đầu
        if (isPoseCorrect && currentDist <= startDistance)
        {
            if (!isMotionStarted)
            {
                isMotionStarted = true;
                timer = 0f; // Bắt đầu đếm giờ
                Debug.Log("Hello: Bắt đầu! (Tay ở trán)");
            }
        }

        // --- GIAI ĐOẠN 2: CHUYỂN ĐỘNG (MOTION) ---
        if (isMotionStarted)
        {
            timer += Time.deltaTime;

            // Nếu tay đã đưa ra xa đủ khoảng cách yêu cầu
            if (currentDist >= endDistance)
            {
                FireHello(); // => THÀNH CÔNG!
            }

            // Nếu quá thời gian cho phép hoặc người chơi sai dáng tay
            if (timer > gestureTimeout || !isPoseCorrect)
            {
                ResetGesture(); // => HỦY BỎ
            }
        }
    }

    // Hàm kích hoạt sự kiện thành công
    void FireHello()
    {
        Debug.Log("<color=green>HELLO DETECTED! Xin chào! 👋</color>");
        OnHelloDetected?.Invoke();
        ResetGesture();
    }

    // Hàm reset trạng thái
    void ResetGesture()
    {
        isMotionStarted = false;
        timer = 0f;
    }

    // --- HÀM KẾT NỐI VỚI STATIC GESTURE ---
    // Bạn sẽ gọi hàm này từ Unity Editor Events
    public void SetPoseActive(bool isActive)
    {
        isPoseCorrect = isActive;
        if (!isActive)
        {
            // Nếu người chơi buông tay (không còn giữ dáng tay B), hủy gesture ngay lập tức
            ResetGesture();
        }
    }
}