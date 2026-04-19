using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIRefinery : MonoBehaviour
{
    [ContextMenu("Refine Alphabet UI")]
    public void RefineUI()
    {
        GameObject alphabets = GameObject.Find("Alphabets");
        if (alphabets == null) return;

        TextMeshProUGUI[] texts = alphabets.GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (var text in texts)
        {
            // Only targets texts that are part of a button or named like one
            if (text.GetComponentInParent<Button>() != null || text.name.Contains("Text"))
            {
                text.enableWordWrapping = false;
                text.overflowMode = TextOverflowModes.Ellipsis; // Optional: ensure no overflow junk
                Debug.Log($"Refined text wrapping on: {text.gameObject.name} at {text.transform.parent.name}");
            }
        }
    }
}
