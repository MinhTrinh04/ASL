using UnityEngine;
using UnityEngine.XR.Hands.Samples.GestureSample;

public class GestureTrigger : MonoBehaviour
{
    public string gestureID;

    private void Start()
    {
        StaticHandGesture[] gestures = GetComponents<StaticHandGesture>();
        foreach (var gesture in gestures)
        {
            gesture.gesturePerformed.AddListener(Trigger);
            gesture.gestureEnded.AddListener(TriggerEnded);
        }
    }

    public void Trigger()
    {
        GestureHub.Publish(gestureID, true);
    }

    public void TriggerEnded()
    {
        GestureHub.Publish(gestureID, false);
    }
}