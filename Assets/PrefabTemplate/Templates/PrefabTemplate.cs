using PrefabTemplate.Templates.Changeables;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.Templates {
  public class PrefabTemplate : MonoBehaviour {
    public Changeable[] changeables;

    public void Cleanup() {
      DestroyImmediate(this, true);
    }
  }

  #if UNITY_EDITOR
  [CustomEditor(typeof(PrefabTemplate))]
  public class PrefabTemplateEditor : Editor
  {
    SerializedProperty changeables;

    private void OnEnable()
    {
      changeables = serializedObject.FindProperty("changeables");
    }

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
