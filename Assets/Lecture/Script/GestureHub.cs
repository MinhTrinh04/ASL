using System;
using UnityEngine;

public class GestureHub : MonoBehaviour
{
    [Header("Global Settings")]
    public bool showVisualTrail = true;

    public static event Action<string> OnGestureDetected;
    public static event Action<string> OnGestureEnded;

    public static void Publish(string gestureID, bool isDetected = true)
    {
        if (isDetected)
        {
            if (int.TryParse(gestureID, out _))
            {
                Debug.Log($"<color=cyan>[GestureHub] Number Gesture '{gestureID}' Detected!</color>");
            }
            OnGestureDetected?.Invoke(gestureID);
        }
        else
        {
            OnGestureEnded?.Invoke(gestureID);
        }
    }

    public static bool AreEquivalent(string gestureA, string gestureB)
    {
        if (gestureA.Equals(gestureB, StringComparison.OrdinalIgnoreCase)) return true;

        // Group M, N, T, S, E as equivalent for easier gesture recognition (all are fist variants)
        string[] fistGroup = { "M", "N", "T", "S", "E" };
        bool aInGroup = System.Array.Exists(fistGroup, g => g.Equals(gestureA, StringComparison.OrdinalIgnoreCase));
        bool bInGroup = System.Array.Exists(fistGroup, g => g.Equals(gestureB, StringComparison.OrdinalIgnoreCase));

        if (aInGroup && bInGroup)
        {
            return true;
        }

        return false;
    }
}