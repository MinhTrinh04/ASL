using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
    [Header("Settings")]
    public bool lockYAxis = true;

    void Update()
    {
        if (Camera.main == null) return;

        Vector3 targetPosition = Camera.main.transform.position;

        if (lockYAxis)
        {
            targetPosition.y = transform.position.y;
        }

        transform.LookAt(targetPosition);

        //transform.Rotate(0, 180, 0);
    }
}