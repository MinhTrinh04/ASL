using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class ClassroomManager : MonoBehaviour
{
    [Header("Phase References")]
    public GameObject lecturePhase;   // Kéo object 'Phase_Lecture' vào đây
    public GameObject quizPhase;      // Kéo object 'Phase_Quiz' vào đây
    public GameObject examEntranceUI; // Kéo object 'UI_Exam_Entrance' vào đây

    [Header("Teleport Settings")]
    public TeleportationProvider teleportProvider;
    public Transform globalSpawnPoint;

    [Header("Gesture Management")]
    public GestureTopicController gestureTopicController;
    public NPCKyleController kyleController;
    public int currentTopicIndex = 0;

    private bool isQuizMode = false;

    void Start()
    {
        // Mặc định khi mới vào game thì bật chế độ HỌC
        EnterLectureMode();
    }

    public void EnterLectureMode()
    {
        isQuizMode = false;
        
        // Ensure correct gestures are active
        if (gestureTopicController) gestureTopicController.EnableTopicByIndex(currentTopicIndex);

        // Bật đồ dùng học tập
        if (lecturePhase) lecturePhase.SetActive(true);

        // Tắt đồ nghề thi cử
        if (quizPhase) quizPhase.SetActive(false);

        // Hiện lại cái cửa/bảng rủ rê đi thi
        if (examEntranceUI) examEntranceUI.SetActive(true);
        
        // Nhờ Kyle vẫy tay chào
        if (kyleController && kyleController.kyleAnim)
        {
            kyleController.kyleAnim.SetTrigger("wave");
        }

        MovePlayerToSpawn();

        Debug.Log("Đã chuyển sang chế độ HỌC");
    }

    public void EnterQuizMode()
    {
        isQuizMode = true;

        // Tắt đồ dùng học tập cho đỡ rối
        if (lecturePhase) lecturePhase.SetActive(false);

        // Bật bảng thi và logic thi
        if (quizPhase) quizPhase.SetActive(true);

        // Ẩn cái cửa rủ thi đi (đang thi rồi mà)
        if (examEntranceUI) examEntranceUI.SetActive(false);
        MovePlayerToSpawn();

        Debug.Log("Đã chuyển sang chế độ THI");
    }

    void MovePlayerToSpawn()
    {
        if (teleportProvider == null)
        {
            Debug.LogWarning("Chưa gắn TeleportProvider!");
            return;
        }

        // Ưu tiên lấy Spawn Point theo topic index
        Transform targetSpawn = null;
        if (gestureTopicController != null)
        {
            targetSpawn = gestureTopicController.GetSpawnPointByIndex(currentTopicIndex);
        }

        // Fallback về global nếu không có topic spawn
        if (targetSpawn == null) targetSpawn = globalSpawnPoint;

        if (targetSpawn == null)
        {
            Debug.LogWarning("Không tìm thấy Spawn Point nào để dịch chuyển!");
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = targetSpawn.position,
            destinationRotation = targetSpawn.rotation,
            matchOrientation = MatchOrientation.TargetUpAndForward
        };

        teleportProvider.QueueTeleportRequest(request);
    }
}