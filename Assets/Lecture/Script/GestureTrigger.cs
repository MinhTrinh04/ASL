using UnityEngine;

public class GestureTrigger : MonoBehaviour
{
    public string gestureID;

    // Call this from StaticHandGesture.gesturePerformed (via UnityEvent)
    public void Trigger()
    {
        GestureHub.Publish(gestureID, true);
    }

    // Call this from StaticHandGesture.gestureEnded (via UnityEvent)
    public void TriggerEnded()
    {
        GestureHub.Publish(gestureID, false);
    }
}