#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace PrefabTemplate.Utility {
  public static class EditorTools {
    public static void FieldTypeLabel(string label) {
      GUIStyle style = new GUIStyle();
      style.normal.textColor = Color.black;
      style.fontStyle = FontStyle.Bold;
      EditorGUILayout.LabelField(label, style, GUILayout.Width(50));
    }

    public static void FieldNameLabel(string label) {
      EditorGUILayout.LabelField(label, GUILayout.Width(150));
    }
  }
}
#endif