using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class WristDashboardUI : MonoBehaviour
{
    [Header("VR Input")]
    [Tooltip("Kéo hành động bấm nút trên Controller vào đây (Ví dụ: Left Hand / Primary Button)")]
    public InputActionReference toggleDashboardAction;

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

    [Header("UI Structure")]
    public GameObject dashboardPanel; // The actual content to show/hide
    public List<TopicUIElements> topicSlots;

    private void OnEnable()
    {
        RefreshUI();
        if (toggleDashboardAction != null)
        {
            toggleDashboardAction.action.Enable();
            toggleDashboardAction.action.performed += OnTogglePressed;
        }
    }

    private void OnDisable()
    {
        if (toggleDashboardAction != null)
        {
            toggleDashboardAction.action.performed -= OnTogglePressed;
        }
    }

    private void OnTogglePressed(InputAction.CallbackContext context)
    {
        ToggleDashboard();
    }

    public void ToggleDashboard()
    {
        if (dashboardPanel != null)
        {
            bool isActive = !dashboardPanel.activeSelf;
            dashboardPanel.SetActive(isActive);
            if (isActive) RefreshUI();
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
                if (dashboardPanel != null) dashboardPanel.SetActive(false);
            }
        }
    }
}
