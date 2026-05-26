using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WristDashboardUI : MonoBehaviour
{
    [System.Serializable]
    public struct TopicUIElements
    {
        public Button selectionButton;
        public TMP_Text topicNameText;
        public TMP_Text scoreText;
        public Image lockImage;
        public Color unlockedColor;
        public Color lockedColor;
        public Color masteredColor; // >= 80%
    }

    [Header("Target Menu")]
    public GameObject targetMenu; // The entire container to show/hide
    public List<TopicUIElements> topicSlots;

    private void Start()
    {
        // Khởi tạo trạng thái ẩn khi bắt đầu
        if (targetMenu != null) targetMenu.SetActive(false);
    }

    public void ToggleDashboard()
    {
        if (targetMenu != null)
        {
            bool nextState = !targetMenu.activeSelf;
            targetMenu.SetActive(nextState);
            
            if (nextState) 
            {
                RefreshUI();
                Debug.Log("[WristDashboardUI] Dashboard opened and refreshed.");
                
                // Optimize performance: Disable LayoutGroup after initial arrangement
                var layout = targetMenu.GetComponent<VerticalLayoutGroup>();
                if (layout != null)
                {
                    layout.enabled = true;
                    Canvas.ForceUpdateCanvases();
                    layout.enabled = false;
                }
            }
        }
    }

    public void RefreshUI()
    {
        if (ProgressManager.Instance == null) return;

        for (int i = 0; i < topicSlots.Count; i++)
        {
            UpdateSlot(i, topicSlots[i]);
        }
    }

    private void UpdateSlot(int index, TopicUIElements slot)
    {
        bool unlocked = ProgressManager.Instance.IsTopicUnlocked(index);
        float score = ProgressManager.Instance.GetHighestScore(index);

        // 1. Text
        if (slot.scoreText != null)
        {
            slot.scoreText.text = unlocked ? (score > 0 ? $"{score:F0}%" : "---") : "Locked";
        }

        // 2. Interactivity
        if (slot.selectionButton != null)
        {
            slot.selectionButton.interactable = unlocked;
            
            // Re-bind click event
            slot.selectionButton.onClick.RemoveAllListeners();
            slot.selectionButton.onClick.AddListener(() => OnTopicSelected(index));
            
            // 3. Coloring
            Color targetColor = slot.lockedColor;
            if (unlocked)
            {
                targetColor = (score >= ProgressManager.Instance.passingGrade) ? slot.masteredColor : slot.unlockedColor;
            }
            
            ColorBlock cb = slot.selectionButton.colors;
            cb.normalColor = targetColor;
            slot.selectionButton.colors = cb;
        }

        // 4. Lock Icon
        if (slot.lockImage != null)
        {
            slot.lockImage.gameObject.SetActive(!unlocked);
        }
    }

    public void OnTopicSelected(int index)
    {
        if (ProgressManager.Instance != null)
        {
            if (ProgressManager.Instance.ApplyTopicChange(index))
            {
                // Close dashboard on success
                if (targetMenu != null) targetMenu.SetActive(false);
            }
        }
    }

    public void OnLobbySelected()
    {
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.EnterLobby();
            if (targetMenu != null) targetMenu.SetActive(false);
        }
    }
}
