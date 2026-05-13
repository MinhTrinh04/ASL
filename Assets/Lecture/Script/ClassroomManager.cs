using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using System.Collections.Generic;

public class ClassroomManager : MonoBehaviour
{
    [Header("Topic Identity")]
    [Tooltip("Global index của topic này — khớp với ProgressManager.classrooms[]. Set 1 lần trong Inspector, không thay đổi runtime.\n(0=Alphabets, 1=Numbers, 2=Greetings)")]
    public int topicIndex = 0;

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

    [Header("Quiz Boards (index từ 0, nội bộ của topic này)")]
    public List<GameObject> quizBoards;

    private bool isQuizMode = false;

    void Start()
    {
        // Chỉ setup phase mặc định — gesture do ProgressManager quản lý
        // KHÔNG gọi gestureTopicController ở đây để tránh race condition
        if (lecturePhase) lecturePhase.SetActive(true);
        if (quizPhase) quizPhase.SetActive(false);
        if (examEntranceUI) examEntranceUI.SetActive(true);
    }

    // ── Lecture Mode ─────────────────────────────────────────────────────────
    public void EnterLectureMode()
    {
        isQuizMode = false;

        if (lecturePhase) lecturePhase.SetActive(true);
        if (quizPhase) quizPhase.SetActive(false);
        if (examEntranceUI) examEntranceUI.SetActive(true);

        if (kyleController && kyleController.kyleAnim)
            kyleController.kyleAnim.SetTrigger("wave");

        MovePlayerToSpawn();
    }

    // ── Quiz Mode ─────────────────────────────────────────────────────────────
    public void EnterQuizMode()
    {
        isQuizMode = true;

        if (lecturePhase) lecturePhase.SetActive(false);
        if (examEntranceUI) examEntranceUI.SetActive(false);

        // Bật Phase_Quiz TRƯỚC khi gọi StartExam
        if (quizPhase) quizPhase.SetActive(true);

        // Bật board[0] và tự gọi StartExam
        // Mỗi ClassroomManager chỉ quản lý boards của riêng nó — luôn dùng index 0
        if (quizBoards != null && quizBoards.Count > 0 && quizBoards[0] != null)
        {
            quizBoards[0].SetActive(true);
            QuizManager qm = quizBoards[0].GetComponent<QuizManager>();
            if (qm != null) qm.StartExam();
        }
        else
        {
            Debug.LogWarning($"[ClassroomManager] {gameObject.name}: quizBoards rỗng hoặc null!");
        }

        MovePlayerToSpawn();
    }

    // ── Teleport ──────────────────────────────────────────────────────────────
    void MovePlayerToSpawn()
    {
        if (teleportProvider == null)
        {
            Debug.LogWarning($"[ClassroomManager] {gameObject.name}: Chưa gắn TeleportProvider!");
            return;
        }

        // Dùng topicIndex bất biến để lấy spawn point toàn cục
        Transform targetSpawn = null;
        if (gestureTopicController != null)
            targetSpawn = gestureTopicController.GetSpawnPointByIndex(topicIndex);

        if (targetSpawn == null) targetSpawn = globalSpawnPoint;

        if (targetSpawn == null)
        {
            Debug.LogWarning($"[ClassroomManager] {gameObject.name}: Không tìm thấy Spawn Point!");
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = targetSpawn.position,
            destinationRotation = targetSpawn.rotation,
            matchOrientation    = MatchOrientation.TargetUpAndForward
        };

        teleportProvider.QueueTeleportRequest(request);
    }
}