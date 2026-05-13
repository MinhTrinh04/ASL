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

    [Header("Default Topic")]
    [Tooltip("Topic sẽ được activate khi game khởi động (thường là 0 = Alphabets)")]
    public int defaultTopicIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Kích hoạt topic mặc định ngay khi game bắt đầu
        // Đây là nguồn duy nhất kích hoạt gesture group lúc startup — không có race condition
        ApplyTopicChange(defaultTopicIndex);
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

        // Bước 1: Kích hoạt gesture group TRƯỚC
        // Đảm bảo gesture đúng đã active trước khi MovePlayerToSpawn() chạy
        if (gestureTopicController != null)
            gestureTopicController.EnableTopicByIndex(newTopicIndex);

        // Bước 2: Toggle các classroom
        if (classrooms != null && classrooms.Count > 0)
        {
            for (int i = 0; i < classrooms.Count; i++)
            {
                if (classrooms[i] == null) continue;

                bool isTarget = (i == newTopicIndex);
                classrooms[i].gameObject.SetActive(isTarget);

                if (isTarget)
                {
                    // KHÔNG set classrooms[i].topicIndex — nó là bất biến, set trong Inspector
                    classrooms[i].EnterLectureMode();
                }
            }
        }

        return true;
    }
}
