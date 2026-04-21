using UnityEngine;
using UnityEditor;

public class FixUITransform : EditorWindow
{
    [MenuItem("Tools/ASL/Fix UI Transform On Hand")]
    public static void FixTransform()
    {
        // 1. TÌM ROOT LEFT HAND
        // The correct left hand is the top-level XR tracker, usually named "Left Hand" (with a space)
        GameObject leftHandRoot = GameObject.Find("Left Hand");
        
        if (leftHandRoot == null)
        {
            Debug.LogError("Không tìm thấy 'Left Hand' (có dấu cách) trong Scene! Bạn hãy đổi tên gốc tay trái về đúng 'Left Hand' nhé.");
            return;
        }

        // 2. KHẮC PHỤC WRIST DASHBOARD
        GameObject dashboard = GameObject.Find("WristDashboardCanvas");
        if (dashboard != null)
        {
            dashboard.transform.SetParent(leftHandRoot.transform, false);
            dashboard.transform.localPosition = new Vector3(0, 0.1f, 0); // Đẩy nhẹ lên trên cổ tay
            dashboard.transform.localEulerAngles = new Vector3(45, 0, 0); // Ngửa ra một chút để đọc
            dashboard.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            Debug.Log("Đã Fix WristDashboardCanvas!");
        }

        // 3. KHẮC PHỤC WATCH TOGGLE (Menu Button)
        GameObject watch = GameObject.Find("WatchToggleCanvas");
        if (watch != null)
        {
            watch.transform.SetParent(leftHandRoot.transform, false);
            watch.transform.localPosition = new Vector3(0, 0.05f, 0); // Gắn sát vào cổ tay hơn
            watch.transform.localEulerAngles = new Vector3(90, 0, 0); // Ngửa lên trên
            watch.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            Debug.Log("Đã Fix WatchToggleCanvas!");
        }

        Debug.Log("Sửa Tọa Độ Thành Công! Cả 2 bảng UI giờ đã dính thẳng vào Gốc 'Left Hand' (không phải L_Wrist).");
    }
}
