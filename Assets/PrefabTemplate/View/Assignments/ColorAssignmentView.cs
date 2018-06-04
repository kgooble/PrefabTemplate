using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.Utility;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.View.Assignments {
  public class ColorAssignmentView : AssignmentView {
    private readonly ColorAssignment assignment;

    public ColorAssignmentView(ColorAssignment assignment) {
      this.assignment = assignment;
    }

    public override string Name {
      get {
        return this.assignment.changeable.name;
      }
    }

    public override void OnGUI() {
      #if UNITY_EDITOR
      EditorTools.FieldTypeLabel("Color");
      EditorTools.FieldNameLabel(this.Name);

      this.assignment.color = EditorGUILayout.ColorField(this.assignment.color);
      #endif
    }
  }
}
