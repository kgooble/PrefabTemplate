using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.Utility;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.View.Assignments {
  public class StringAssignmentView : AssignmentView {
    private readonly StringAssignment assignment;

    public StringAssignmentView(StringAssignment assignment) {
      this.assignment = assignment;
    }

    public override string Name {
      get {
        return this.assignment.changeable.name;
      }
    }

    public override void OnGUI() {
      #if UNITY_EDITOR
      EditorTools.FieldTypeLabel("String");
      EditorTools.FieldNameLabel(this.Name);

      this.assignment.stringValue = EditorGUILayout.TextField(this.assignment.stringValue);
      #endif
    }
  }
}
