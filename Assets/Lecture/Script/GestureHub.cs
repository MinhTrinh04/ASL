using System;
using UnityEngine;

public class GestureHub : MonoBehaviour
{
    public static event Action<string> OnGestureDetected;
    public static event Action<string> OnGestureEnded;

    public static void Publish(string gestureID, bool isDetected = true)
    {
        if (isDetected)
        {
            Debug.Log($"[GestureHub] Detected: {gestureID}");
            OnGestureDetected?.Invoke(gestureID);
        }
        else
        {
            Debug.Log($"[GestureHub] Ended: {gestureID}");
            OnGestureEnded?.Invoke(gestureID);
        }
    }
}