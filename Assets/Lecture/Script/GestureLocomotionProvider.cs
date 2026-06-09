using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;

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
    [Tooltip("Transform của tay trái làm hướng đi về phía trước dự phòng.")]
    public Transform leftHandTransform;

    [Tooltip("Transform của tay phải làm hướng đi về phía trước dự phòng.")]
    public Transform rightHandTransform;

    [Header("Tracking Events (Tự động tìm kiếm nếu bỏ trống)")]
    public XRHandTrackingEvents leftHandTrackingEvents;
    public XRHandTrackingEvents rightHandTrackingEvents;

    private bool m_LeftHandPointing = false;
    private bool m_RightHandPointing = false;

    private void Start()
    {
        // Tự động tìm kiếm các bộ tracker trên tay nếu chưa được gán
        if (leftHandTrackingEvents == null || rightHandTrackingEvents == null)
        {
            var trackers = FindObjectsOfType<XRHandTrackingEvents>(true);
            foreach (var tracker in trackers)
            {
                if (tracker.name.Contains("Left"))
                    leftHandTrackingEvents = tracker;
                else if (tracker.name.Contains("Right"))
                    rightHandTrackingEvents = tracker;
            }
        }
    }

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

    private List<XRHandSubsystem> m_SubsystemsReuse = new List<XRHandSubsystem>();

    private XRHandSubsystem GetHandSubsystem()
    {
        SubsystemManager.GetSubsystems(m_SubsystemsReuse);
        for (var i = 0; i < m_SubsystemsReuse.Count; ++i)
        {
            var subsystem = m_SubsystemsReuse[i];
            if (subsystem.running)
                return subsystem;
        }
        return null;
    }

    private Vector3 GetHandDirection(XRHandTrackingEvents tracker, Transform fallbackTransform)
    {
        if (tracker != null && tracker.handIsTracked)
        {
            var subsystem = GetHandSubsystem();
            if (subsystem != null)
            {
                var hand = tracker.handedness == Handedness.Left ? subsystem.leftHand : subsystem.rightHand;
                var wristJoint = hand.GetJoint(XRHandJointID.Wrist);
                var indexTipJoint = hand.GetJoint(XRHandJointID.IndexTip);

                if (wristJoint.TryGetPose(out var wristPose) && indexTipJoint.TryGetPose(out var tipPose))
                {
                    // Hướng đi từ cổ tay đến đầu ngón trỏ chính là hướng chỉ tay thực tế của người dùng
                    Vector3 dir = (tipPose.position - wristPose.position).normalized;
                    // Chuyển hướng từ tracking space sang world space dựa vào transform của XR Origin
                    Vector3 worldDir = transform.TransformDirection(dir).normalized;
                    return worldDir;
                }
            }
        }

        // Fallback về hướng Transform của GameObject tay nếu không lấy được khớp xương
        return fallbackTransform != null ? fallbackTransform.forward : Vector3.forward;
    }

    private void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Chỉ di chuyển khi CẢ HAI tay đều chỉ ngón trỏ về phía trước!
        if (m_LeftHandPointing && m_RightHandPointing)
        {
            Vector3 leftDir = GetHandDirection(leftHandTrackingEvents, leftHandTransform);
            Vector3 rightDir = GetHandDirection(rightHandTrackingEvents, rightHandTransform);
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
