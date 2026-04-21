using UnityEngine;

[ExecuteInEditMode]
public class SetupHelper : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("SetupHelper Awake fired! Executing Setup...");
        ProgressSystemSetup.Setup();
        
        // Use delay to destroy self to avoid destroying during Awake which isn't allowed in edit mode sometimes
        UnityEditor.EditorApplication.delayCall += () =>
        {
            if (this != null && this.gameObject != null)
                DestroyImmediate(this.gameObject);
        };
    }
}
