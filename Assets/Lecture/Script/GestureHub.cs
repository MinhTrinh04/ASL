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
            OnGestureDetected?.Invoke(gestureID);
        }
        else
        {
            OnGestureEnded?.Invoke(gestureID);
        }
    }

    public static bool AreEquivalent(string gestureA, string gestureB)
    {
        if (gestureA == gestureB) return true;

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