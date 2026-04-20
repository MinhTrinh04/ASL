using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }

    [Header("Orchestration References")]
    [Tooltip("Kéo các ClassroomManager của từng Topic vào đây theo đúng thứ tự 0, 1, 2... (Ví dụ: 0=Alphabets, 1=Numbers, 2=Greetings)")]
    public System.Collections.Generic.List<ClassroomManager> classrooms;
    public GestureTopicController gestureTopicController;
    
    [Header("Settings")]
    public float passingGrade = 80f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void SaveTopicScore(int topicIndex, float percentage)
    {
        string key = $"Topic_{topicIndex}_Score";
        float currentBest = PlayerPrefs.GetFloat(key, 0f);
        
        if (percentage > currentBest)
        {
            PlayerPrefs.SetFloat(key, percentage);
            PlayerPrefs.Save();
            Debug.Log($"[ProgressManager] New Highscore for Topic {topicIndex}: {percentage:F1}%");
        }
    }

    public float GetHighestScore(int topicIndex)
    {
        return PlayerPrefs.GetFloat($"Topic_{topicIndex}_Score", 0f);
    }

    public bool IsTopicUnlocked(int topicIndex)
    {
        if (topicIndex == 0) return true;
        return GetHighestScore(topicIndex - 1) >= passingGrade;
    }

    public bool ApplyTopicChange(int newTopicIndex)
    {
        if (!IsTopicUnlocked(newTopicIndex))
        {
            Debug.LogWarning($"[ProgressManager] Topic {newTopicIndex} is locked!");
            return false;
        }

        if (classrooms != null && classrooms.Count > 0)
        {
            for (int i = 0; i < classrooms.Count; i++)
            {
                if (classrooms[i] != null)
                {
                    if (i == newTopicIndex)
                    {
                        classrooms[i].currentTopicIndex = newTopicIndex;
                        classrooms[i].EnterLectureMode();
                        // Kích hoạt toàn bộ object classroom này
                        classrooms[i].gameObject.SetActive(true); 
                    }
                    else
                    {
                        // Tắt các classroom khác để dọn dẹn scene
                        classrooms[i].gameObject.SetActive(false);
                    }
                }
            }
        }

        if (gestureTopicController != null)
        {
            gestureTopicController.EnableTopicByIndex(newTopicIndex);
        }

        Debug.Log($"[ProgressManager] Switched to Topic {newTopicIndex}");
        return true;
    }
}
