using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class RecordingPrompter : MonoBehaviour
{
    public TMP_Text numberText;
    private int currentNumber = 11;

    void Start()
    {
        RefreshTextDisplay();
    }



    

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (currentNumber < 20)
            {
                currentNumber++;
                RefreshTextDisplay();
            }
            else
            {
                Debug.Log("Finished recording sequence (reached 20).");
            }
        }
    }

    private void RefreshTextDisplay()
    {
        if (numberText != null)
        {
            numberText.text = "Number " + currentNumber.ToString();
            Debug.Log("Prompter changed to: Number " + currentNumber.ToString());
        }
    }
}
