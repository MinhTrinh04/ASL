using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class HandPoseTransfer : EditorWindow
{
    // Biến tĩnh để lưu dữ liệu ngay cả khi tắt Play Mode
    private static Dictionary<string, Quaternion> savedPoseRotations = new Dictionary<string, Quaternion>();
    private static bool hasData = false;

    public GameObject sourceHand; // Tay nguồn (Play Mode)
    public GameObject targetHand; // Tay đích (Edit Mode)

    [MenuItem("Tools/Hand Pose Transfer (Ultimate)")]
    static void Init()
    {
        HandPoseTransfer window = (HandPoseTransfer)EditorWindow.GetWindow(typeof(HandPoseTransfer));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("BƯỚC 1: COPY (Lúc đang Play)", EditorStyles.boldLabel);
        sourceHand = (GameObject)EditorGUILayout.ObjectField("Tay Nguồn (R_Wrist)", sourceHand, typeof(GameObject), true);

        if (GUILayout.Button("1. COPY POSE"))
        {
            if (sourceHand == null) { Debug.LogError("Chưa chọn tay nguồn!"); return; }
            CopyPose(sourceHand.transform);
        }

        GUILayout.Space(20);
        GUILayout.Label("BƯỚC 2: PASTE (Lúc đã Stop)", EditorStyles.boldLabel);
        if (hasData)
        {
            GUILayout.Label($"Đang lưu {savedPoseRotations.Count} khớp xương trong bộ nhớ.", EditorStyles.helpBox);
        }
        else
        {
            GUILayout.Label("Chưa có dữ liệu pose.", EditorStyles.helpBox);
        }

        targetHand = (GameObject)EditorGUILayout.ObjectField("Tay Đích (R_Wrist)", targetHand, typeof(GameObject), true);

        if (GUILayout.Button("2. PASTE POSE"))
        {
            if (targetHand == null) { Debug.LogError("Chưa chọn tay đích!"); return; }
            if (!hasData) { Debug.LogError("Chưa có dữ liệu để paste!"); return; }

            PastePose(targetHand.transform);
        }
    }

    // Hàm Copy đệ quy
    void CopyPose(Transform root)
    {
        savedPoseRotations.Clear();
        StoreTransformsRecursively(root);
        hasData = true;
        Debug.Log($"<color=yellow>Đã copy {savedPoseRotations.Count} khớp xương! Giờ hãy tắt Play Mode.</color>");
    }

    void StoreTransformsRecursively(Transform t)
    {
        // Lưu localRotation dựa theo tên xương
        if (!savedPoseRotations.ContainsKey(t.name))
        {
            savedPoseRotations.Add(t.name, t.localRotation);
        }

        foreach (Transform child in t)
        {
            StoreTransformsRecursively(child);
        }
    }

    // Hàm Paste đệ quy
    void PastePose(Transform root)
    {
        Undo.RegisterFullObjectHierarchyUndo(root.gameObject, "Paste Hand Pose");
        ApplyTransformsRecursively(root);
        Debug.Log("<color=green>Đã dán dáng tay thành công! Hãy lưu Prefab ngay.</color>");
    }

    void ApplyTransformsRecursively(Transform t)
    {
        // Tìm xem xương này có trong dữ liệu đã lưu không
        if (savedPoseRotations.ContainsKey(t.name))
        {
            t.localRotation = savedPoseRotations[t.name];
            // Đánh dấu vật thể đã bị thay đổi để Unity lưu lại
            EditorUtility.SetDirty(t);
        }

        foreach (Transform child in t)
        {
            ApplyTransformsRecursively(child);
        }
    }
}