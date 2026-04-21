using UnityEngine;

public class WristFollower : MonoBehaviour
{
    [Tooltip("Kéo thả L_Wrist vào đây")]
    public Transform targetWrist;

    public Vector3 positionOffset = new Vector3(0, 0.1f, 0); // Đẩy nhẹ lên trên cổ tay
    public Vector3 rotationOffset = new Vector3(45, 0, 0); // Ngửa ra để dễ nhìn

    void LateUpdate()
    {
        if (targetWrist != null)
        {
            // Bám chặt tọa độ và góc xoay của cổ tay, cộng thêm khoảng cách offset
            transform.position = targetWrist.position + targetWrist.rotation * positionOffset;
            transform.rotation = targetWrist.rotation * Quaternion.Euler(rotationOffset);
        }
    }
}
