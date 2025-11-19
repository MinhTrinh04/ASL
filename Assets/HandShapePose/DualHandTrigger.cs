using UnityEngine;
using UnityEngine.Events;

public class DualHandTrigger : MonoBehaviour
{
    [Header("Tr?ng thái 2 tay")]
    public bool isLeftHandReady = false;
    public bool isRightHandReady = false;

    [Header("S? ki?n chung")]
    public UnityEvent OnDualGesturePerformed; // Kích ho?t khi c? 2 tay ??u ?úng
    public UnityEvent OnDualGestureEnded;     // Kích ho?t khi 1 trong 2 tay sai

    private bool _wasActive = false;

    // Hàm này n?i v?i Static Gesture bên trái
    public void SetLeftHand(bool active)
    {
        isLeftHandReady = active;
        CheckDualState();
    }

    // Hàm này n?i v?i Static Gesture bên ph?i
    public void SetRightHand(bool active)
    {
        isRightHandReady = active;
        CheckDualState();
    }

    private void CheckDualState()
    {
        // Logic C?ng AND: C? trái VÀ ph?i ??u ph?i True
        bool areBothActive = isLeftHandReady && isRightHandReady;

        if (areBothActive && !_wasActive)
        {
            Debug.Log("<color=cyan>WHAT'S UP DETECTED! (2 Hands)</color>");
            OnDualGesturePerformed?.Invoke();
            _wasActive = true;
        }
        else if (!areBothActive && _wasActive)
        {
            // Ch? c?n 1 tay buông ra là h?y
            Debug.Log("Gesture Ended");
            OnDualGestureEnded?.Invoke();
            _wasActive = false;
        }
    }
}