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

    [Header("Lobby Orchestration")]
    [Tooltip("Kéo transform SpawnPoint_Lobby vào đây")]
    public Transform lobbySpawnPoint;
    [Tooltip("Kéo object [System_GestureManager]/Pose Canvas/Gestures_Lobby vào đây")]
    public GameObject lobbyGestureGroup;
    [Tooltip("Kéo TeleportationProvider trong scene vào đây")]
    public UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider teleportProvider;

    [Header("Default Topic")]
    [Tooltip("Nếu set -1, người chơi sẽ bắt đầu ở Lobby.")]
    public int defaultTopicIndex = -1;

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
        if (defaultTopicIndex == -1)
        {
            EnterLobby();
        }
        else
        {
            ApplyTopicChange(defaultTopicIndex);
        }
    }

    public void EnterLobby()
    {
        // Tắt tất cả các classroom
        if (classrooms != null)
        {
            for (int i = 0; i < classrooms.Count; i++)
            {
                if (classrooms[i] != null) classrooms[i].gameObject.SetActive(false);
            }
        }

        // Tắt tất cả các topic gesture của phòng học
        if (gestureTopicController != null)
        {
            for (int i = 0; i < gestureTopicController.topics.Count; i++)
            {
                if (gestureTopicController.topics[i].gestureGroupObject != null)
                {
                    gestureTopicController.topics[i].gestureGroupObject.SetActive(false);
                }
            }
        }

        // Bật tất cả Lobby Gestures khi về sảnh chính
        if (lobbyGestureGroup != null)
        {
            lobbyGestureGroup.SetActive(true);
            for (int i = 0; i < lobbyGestureGroup.transform.childCount; i++)
            {
                Transform child = lobbyGestureGroup.transform.GetChild(i);
                child.gameObject.SetActive(true);
            }
        }

        // Teleport player tới spawn point của Lobby
        if (teleportProvider != null && lobbySpawnPoint != null)
        {
            var request = new UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportRequest()
            {
                destinationPosition = lobbySpawnPoint.position,
                destinationRotation = lobbySpawnPoint.rotation,
                matchOrientation = UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.MatchOrientation.TargetUpAndForward
            };
            teleportProvider.QueueTeleportRequest(request);
        }
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

        // Tắt các lobby gestures khác khi chuyển sang phòng học, giữ lại Pointing_Left và Pointing_Right để di chuyển
        // Bật lại lobbyGestureGroup vì EnableTopicByIndex vừa tắt nó do Gestures_Lobby ở index 3.
        if (lobbyGestureGroup != null)
        {
            lobbyGestureGroup.SetActive(true);
            for (int i = 0; i < lobbyGestureGroup.transform.childCount; i++)
            {
                Transform child = lobbyGestureGroup.transform.GetChild(i);
                if (child.name != "Pointing_Left" && child.name != "Pointing_Right")
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
        }

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
