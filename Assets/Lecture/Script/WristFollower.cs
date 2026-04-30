using UnityEngine;

public class WristFollower : MonoBehaviour
{
    [Header("Tracking Target")]
    public Transform targetWrist;

    [Header("Positioning")]
    [Tooltip("Dịch chuyển về phía cùi chỏ (thường là trục Z âm) và lên trên (trục Y dương)")]
    public Vector3 localPositionOffset = new Vector3(0, 0.07f, -0.08f); 
    
    [Header("Orientation")]
    [Tooltip("Xoay để mặt Dashboard hướng lên trên cẳng tay. (90, 0, 0) giúp nó nằm ngang song song mặt tay.")]
    public Vector3 localRotationOffset = new Vector3(90, 0, 0); 

    [Header("Settings")]
    public float lerpSpeed = 25f;

    void OnEnable()
    {
        // Khi bật lên, dịch chuyển ngay lập tức để tránh hiệu ứng trượt từ xa
        if (targetWrist != null)
        {
            transform.position = targetWrist.position + targetWrist.rotation * localPositionOffset;
            transform.rotation = targetWrist.rotation * Quaternion.Euler(localRotationOffset);
        }
    }

    void LateUpdate()
    {
        if (targetWrist != null)
        {
            Vector3 targetPos = targetWrist.position + targetWrist.rotation * localPositionOffset;
            Quaternion targetRot = targetWrist.rotation * Quaternion.Euler(localRotationOffset);

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * lerpSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * lerpSpeed);
        }
    }
}
