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