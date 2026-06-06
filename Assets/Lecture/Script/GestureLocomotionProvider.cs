using UnityEngine;

public class GestureLocomotionProvider : MonoBehaviour
{
    [Header("Locomotion Settings")]
    [Tooltip("Tốc độ di chuyển mượt (mét/giây).")]
    public float moveSpeed = 1.5f;

    [Tooltip("Nếu true, khóa trục Y để người chơi di chuyển dọc theo mặt đất.")]
    public bool lockYAxis = true;

    [Tooltip("CharacterController gắn trên XR Origin để thực hiện di chuyển.")]
    public CharacterController characterController;

    [Header("Gesture IDs")]
    public string leftPointingGestureID = "Pointing_Left";
    public string rightPointingGestureID = "Pointing_Right";

    [Header("Hand Direction References")]
    [Tooltip("Transform của tay trái để xác định hướng đi về phía trước.")]
    public Transform leftHandTransform;

    [Tooltip("Transform của tay phải để xác định hướng đi về phía trước.")]
    public Transform rightHandTransform;

    private bool m_LeftHandPointing = false;
    private bool m_RightHandPointing = false;

    private void OnEnable()
    {
        GestureHub.OnGestureDetected += OnGestureDetected;
        GestureHub.OnGestureEnded += OnGestureEnded;
    }

    private void OnDisable()
    {
        GestureHub.OnGestureDetected -= OnGestureDetected;
        GestureHub.OnGestureEnded -= OnGestureEnded;
        m_LeftHandPointing = false;
        m_RightHandPointing = false;
    }

    private void OnGestureDetected(string gestureID)
    {
        if (gestureID == leftPointingGestureID)
        {
            m_LeftHandPointing = true;
        }
        else if (gestureID == rightPointingGestureID)
        {
            m_RightHandPointing = true;
        }
    }

    private void OnGestureEnded(string gestureID)
    {
        if (gestureID == leftPointingGestureID)
        {
            m_LeftHandPointing = false;
        }
        else if (gestureID == rightPointingGestureID)
        {
            m_RightHandPointing = false;
        }
    }

    private void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Chỉ di chuyển khi CẢ HAI tay đều chỉ ngón trỏ về phía trước!
        if (m_LeftHandPointing && m_RightHandPointing)
        {
            Vector3 leftDir = leftHandTransform != null ? leftHandTransform.forward : Vector3.forward;
            Vector3 rightDir = rightHandTransform != null ? rightHandTransform.forward : Vector3.forward;
            moveDirection = (leftDir + rightDir).normalized;
        }

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            if (lockYAxis)
            {
                moveDirection.y = 0f;
            }
            moveDirection.Normalize();

            Vector3 deltaMove = moveDirection * moveSpeed * Time.deltaTime;

            if (characterController != null && characterController.enabled)
            {
                characterController.Move(deltaMove);
            }
            else
            {
                transform.position += deltaMove;
            }
        }
    }
}
