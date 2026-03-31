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

    public static bool AreEquivalent(string gestureA, string gestureB)
    {
        if (gestureA == gestureB) return true;

        // Group M, N, T, S, E as equivalent for easier gesture recognition (all are fist variants)
        string[] fistGroup = { "M", "N", "T", "S", "E" };
        bool aInGroup = System.Array.Exists(fistGroup, g => g.Equals(gestureA, StringComparison.OrdinalIgnoreCase));
        bool bInGroup = System.Array.Exists(fistGroup, g => g.Equals(gestureB, StringComparison.OrdinalIgnoreCase));

        if (aInGroup && bInGroup)
        {
            Debug.Log($"[GestureHub] Equivalence Match: {gestureA} counts as {gestureB}");
            return true;
        }

        return false;
    }
}