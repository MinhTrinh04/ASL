using UnityEngine;
using System.Collections.Generic;

public class LessonManager : MonoBehaviour
{
    public List<GameObject> lessonPrefabs; // Danh sách các bài học (Prefab)
    public Transform spawnPoint;           // Vị trí xuất hiện bài học

    private int currentIndex = 0;
    private GameObject currentActiveLesson;

    void Start()
    {
        StartLesson(0); // Bắt đầu bài đầu tiên
    }

    void StartLesson(int index)
    {
        if (index >= lessonPrefabs.Count)
        {
            Debug.Log("Đã học xong tất cả! Chúc mừng tốt nghiệp!");
            return;
        }

        // Tạo bài học mới từ Prefab
        currentActiveLesson = Instantiate(lessonPrefabs[index], spawnPoint.position, spawnPoint.rotation);

        // Lắng nghe sự kiện "Xong bài" của bài học đó
        GestureLesson lessonScript = currentActiveLesson.GetComponent<GestureLesson>();
        if (lessonScript != null)
        {
            lessonScript.OnLessonFinished.AddListener(OnCurrentLessonFinished);
        }
    }

    // Hàm này sẽ được gọi tự động khi bài học báo cáo "Xong rồi"
    void OnCurrentLessonFinished()
    {
        currentIndex++;
        // Đợi 2 giây rồi hiện bài tiếp theo
        Invoke("StartNext", 2.0f);
    }

    void StartNext()
    {
        StartLesson(currentIndex);
    }
}