using UnityEngine;

public class GestureTrigger : MonoBehaviour
{
    public string gestureID;

    private bool isDetected = false;

    public void Trigger()
    {
        if (!isDetected)
        {
            isDetected = true;
            GestureHub.Publish(gestureID, true);
        }
    }

    public void TriggerEnded()
    {
        if (isDetected)
        {
            isDetected = false;
            GestureHub.Publish(gestureID, false);
        }
    }
}