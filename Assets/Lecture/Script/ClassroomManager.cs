using UnityEngine;

public class ClassroomManager : MonoBehaviour
{
    [Header("Phase References")]
    public GameObject lecturePhase;   // Kéo object 'Phase_Lecture' vào đây
    public GameObject quizPhase;      // Kéo object 'Phase_Quiz' vào đây
    public GameObject examEntranceUI; // Kéo object 'UI_Exam_Entrance' vào đây

    // Trạng thái hiện tại
    private bool isQuizMode = false;

    void Start()
    {
        // Mặc định khi mới vào game thì bật chế độ HỌC
        EnterLectureMode();
    }

    public void EnterLectureMode()
    {
        isQuizMode = false;

        // Bật đồ dùng học tập
        if (lecturePhase) lecturePhase.SetActive(true);

        // Tắt đồ nghề thi cử
        if (quizPhase) quizPhase.SetActive(false);

        // Hiện lại cái cửa/bảng rủ rê đi thi
        if (examEntranceUI) examEntranceUI.SetActive(true);

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

        Debug.Log("Đã chuyển sang chế độ THI");
    }
}