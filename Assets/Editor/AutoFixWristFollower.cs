using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class AutoFixWristFollower
{
    static AutoFixWristFollower()
    {
        EditorApplication.delayCall += RunFix;
    }

    static void RunFix()
    {
        // Find L_Wrist even if inactive
        Transform wristTransform = null;
        Transform[] allTransforms = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform t in allTransforms)
        {
            if (t.name == "L_Wrist" && t.gameObject.scene.isLoaded) // ensure it's in the scene
            {
                wristTransform = t;
                break;
            }
        }

        GameObject dashboard = GameObject.Find("WristDashboardCanvas");
        GameObject watch = GameObject.Find("WatchToggleCanvas");
        
        if (dashboard == null && watch == null) return;
        
        // Find XR Origin to parent them so they don't get inherited scales
        GameObject root = GameObject.Find("XR Origin");
        
        if (dashboard != null)
        {
            dashboard.transform.SetParent(root != null ? root.transform : null, false);
            dashboard.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            
            WristFollower fw = dashboard.GetComponent<WristFollower>();
            if (fw == null) fw = dashboard.AddComponent<WristFollower>();
            
            if (wristTransform != null)
            {
                fw.targetWrist = wristTransform;
                fw.positionOffset = new Vector3(0, 0.15f, 0); // Offset up from wrist
                fw.rotationOffset = new Vector3(45, 0, 0);    // Tilt for readability
            }
        }

        if (watch != null)
        {
            watch.transform.SetParent(root != null ? root.transform : null, false);
            watch.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            
            WristFollower fw = watch.GetComponent<WristFollower>();
            if (fw == null) fw = watch.AddComponent<WristFollower>();
            
            if (wristTransform != null)
            {
                fw.targetWrist = wristTransform;
                fw.positionOffset = new Vector3(0, 0.03f, 0); // Closer to skin for physical button
                fw.rotationOffset = new Vector3(90, 0, 0);    // Face outward
            }
        }
        
        Debug.Log("===> TỰ ĐỘNG CÀI ĐẶT THÀNH CÔNG: Đã gỡ UI ra khỏi nhóm tay và gắn Widget bám theo Xương tay (L_Wrist)!");
    }
}
