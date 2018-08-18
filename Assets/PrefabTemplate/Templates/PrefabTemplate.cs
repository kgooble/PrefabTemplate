using PrefabTemplate.Templates.Changeables;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.Templates {
  public class PrefabTemplate : MonoBehaviour {
    public bool Required { get; private set; }

    public Changeable[] changeables;

    public void Cleanup() {
      #if UNITY_EDITOR
      if (!this.Required) {
        string path = AssetDatabase.GetAssetPath(this.gameObject.GetInstanceID());
        AssetDatabase.DeleteAsset(path);
        Debug.Log("Deleting asset at path, since it was not required: " + path);
      }
      #endif

      DestroyImmediate(this, true);
    }

    public void MarkRequired() {
      this.Required = true;
    }
  }

  #if UNITY_EDITOR
  [CustomEditor(typeof(PrefabTemplate))]
  public class PrefabTemplateEditor : Editor
  {
    public override void OnInspectorGUI()
    {
      serializedObject.Update();

      if (GUILayout.Button("Auto-Fill")) {
        PrefabTemplate obj = serializedObject.targetObject as PrefabTemplate;
        Changeable[] ch = obj.gameObject.GetComponentsInChildren<Changeable>(true);
        obj.changeables = ch;
      }

      base.OnInspectorGUI();
      serializedObject.ApplyModifiedProperties();
    }
  }
  #endif
}
