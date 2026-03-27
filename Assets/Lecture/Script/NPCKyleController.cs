using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class NPCKyleController : MonoBehaviour
{
    public Animator kyleAnim;
    public TMP_Text practiceTextUI;
    public List<PracticeData> practiceList;

    private int currentQuestionIndex = 0;
    private int currentSpellingIndex = 0;
    private bool isPracticeActive = false;

    // Hàm gọi khi người dùng nhấn nút "Start Practice" (tạo riêng, không dùng nút Start Exam)
    public void StartPractice()
    {
        currentQuestionIndex = 0;
        isPracticeActive = true;
        kyleAnim.SetTrigger("think");
        LoadPracticeStep();
    }

    void LoadPracticeStep()
    {
        if (currentQuestionIndex >= practiceList.Count)
        {
            practiceTextUI.text = "Great job!";
            isPracticeActive = false;
            return;
        }
        currentSpellingIndex = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        string word = practiceList[currentQuestionIndex].targetWord;
        // Highlight màu xanh cho các chữ cái đã làm đúng
        string highlighted = $"<color=green>{word.Substring(0, currentSpellingIndex)}</color>{word.Substring(currentSpellingIndex)}";
        practiceTextUI.text = highlighted;
    }

    // Nhận dữ liệu từ hệ thống nhận diện cử chỉ
    public void OnGestureInput(string gestureID)
    {
        if (!isPracticeActive) return;

        string target = practiceList[currentQuestionIndex].gestureSequence[currentSpellingIndex];

        if (gestureID == target)
        {
            currentSpellingIndex++;
            UpdateUI();

            // Nếu xong 1 từ
            if (currentSpellingIndex >= practiceList[currentQuestionIndex].gestureSequence.Count)
            {
                StartCoroutine(CorrectSequence());
            }
        }
    }

    IEnumerator CorrectSequence()
    {
        isPracticeActive = false;
        practiceTextUI.text = "<color=green>CORRECT!</color>";
        kyleAnim.SetTrigger("correct");

        yield return new WaitForSeconds(2f);

        currentQuestionIndex++;
        isPracticeActive = true;
        kyleAnim.SetTrigger("think");
        LoadPracticeStep();
    }
}