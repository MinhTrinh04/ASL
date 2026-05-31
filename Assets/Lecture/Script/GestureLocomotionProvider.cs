using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Gestures;

public class GestureLocomotionProvider : MonoBehaviour
{
    [Header("Hand Tracking References")]
    [Tooltip("The XRHandTrackingEvents component for the left hand.")]
    public XRHandTrackingEvents leftHandTrackingEvents;

    [Tooltip("The XRHandTrackingEvents component for the right hand.")]
    public XRHandTrackingEvents rightHandTrackingEvents;

    [Tooltip("The Left Hand transform to determine pointing forward direction.")]
    public Transform leftHandTransform;

    [Tooltip("The Right Hand transform to determine pointing forward direction.")]
    public Transform rightHandTransform;

    [Header("Locomotion Settings")]
    [Tooltip("The pre-existing '1' hand shape ScriptableObject.")]
    public ScriptableObject pointingShapeAsset;

    [Tooltip("Locomotion movement speed in meters per second.")]
    public float moveSpeed = 1.5f;

    [Tooltip("If true, locks the vertical (Y) axis so the player glides along the ground.")]
    public bool lockYAxis = true;

    [Tooltip("The CharacterController attached to the XR Origin for smooth locomotion.")]
    public CharacterController characterController;

    private XRHandShape m_PointingShape;
    private XRHandPose m_PointingPose;
    private bool m_LeftHandPointing = false;
    private bool m_RightHandPointing = false;
    private Vector3 m_LeftHandDirection = Vector3.forward;
    private Vector3 m_RightHandDirection = Vector3.forward;

    private void Awake()
    {
        if (pointingShapeAsset != null)
        {
            m_PointingShape = pointingShapeAsset as XRHandShape;
            m_PointingPose = pointingShapeAsset as XRHandPose;
        }

        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    private void OnEnable()
    {
        if (leftHandTrackingEvents != null)
        {
            leftHandTrackingEvents.jointsUpdated.AddListener(OnLeftJointsUpdated);
        }

        if (rightHandTrackingEvents != null)
        {
            rightHandTrackingEvents.jointsUpdated.AddListener(OnRightJointsUpdated);
        }
    }

    private void OnDisable()
    {
        if (leftHandTrackingEvents != null)
        {
            leftHandTrackingEvents.jointsUpdated.RemoveListener(OnLeftJointsUpdated);
        }

        if (rightHandTrackingEvents != null)
        {
            rightHandTrackingEvents.jointsUpdated.RemoveListener(OnRightJointsUpdated);
        }

        // Reset tracking states to avoid drift on disable
        m_LeftHandPointing = false;
        m_RightHandPointing = false;
    }

    private void OnLeftJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
    {
        if (!isActiveAndEnabled || leftHandTrackingEvents == null)
        {
            m_LeftHandPointing = false;
            return;
        }

        bool isShapeMatch = m_PointingShape != null && m_PointingShape.CheckConditions(eventArgs);
        bool isPoseMatch = m_PointingPose != null && m_PointingPose.CheckConditions(eventArgs);

        m_LeftHandPointing = leftHandTrackingEvents.handIsTracked && (isShapeMatch || isPoseMatch);

        if (m_LeftHandPointing)
        {
            var tipJoint = eventArgs.hand.GetJoint(XRHandJointID.IndexTip);
            var baseJoint = eventArgs.hand.GetJoint(XRHandJointID.IndexProximal);
            if (tipJoint.TryGetPose(out Pose tipPose) && baseJoint.TryGetPose(out Pose basePose))
            {
                Vector3 localDir = (tipPose.position - basePose.position).normalized;
                m_LeftHandDirection = transform.TransformDirection(localDir);
            }
            else if (leftHandTransform != null)
            {
                m_LeftHandDirection = leftHandTransform.forward;
            }
        }
    }

    private void OnRightJointsUpdated(XRHandJointsUpdatedEventArgs eventArgs)
    {
        if (!isActiveAndEnabled || rightHandTrackingEvents == null)
        {
            m_RightHandPointing = false;
            return;
        }

        bool isShapeMatch = m_PointingShape != null && m_PointingShape.CheckConditions(eventArgs);
        bool isPoseMatch = m_PointingPose != null && m_PointingPose.CheckConditions(eventArgs);

        m_RightHandPointing = rightHandTrackingEvents.handIsTracked && (isShapeMatch || isPoseMatch);

        if (m_RightHandPointing)
        {
            var tipJoint = eventArgs.hand.GetJoint(XRHandJointID.IndexTip);
            var baseJoint = eventArgs.hand.GetJoint(XRHandJointID.IndexProximal);
            if (tipJoint.TryGetPose(out Pose tipPose) && baseJoint.TryGetPose(out Pose basePose))
            {
                Vector3 localDir = (tipPose.position - basePose.position).normalized;
                m_RightHandDirection = transform.TransformDirection(localDir);
            }
            else if (rightHandTransform != null)
            {
                m_RightHandDirection = rightHandTransform.forward;
            }
        }
    }

    private void Update()
    {
        // Safe check if hands are no longer tracked, cancel pointing
        if (leftHandTrackingEvents != null && !leftHandTrackingEvents.handIsTracked)
        {
            m_LeftHandPointing = false;
        }
        if (rightHandTrackingEvents != null && !rightHandTrackingEvents.handIsTracked)
        {
            m_RightHandPointing = false;
        }

        Vector3 moveDirection = Vector3.zero;

        // Add Left Hand pointing direction
        if (m_LeftHandPointing)
        {
            moveDirection += m_LeftHandDirection;
        }

        // Add Right Hand pointing direction
        if (m_RightHandPointing)
        {
            moveDirection += m_RightHandDirection;
        }

        // Apply movement if any hand is actively pointing
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
                // Fallback to direct transform manipulation if CharacterController is missing
                transform.position += deltaMove;
            }
        }
    }
}
