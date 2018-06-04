using System.Collections.Generic;
using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View.Assignments;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.View {
  public class TemplateView {
    public readonly Templates.PrefabTemplate template;
    public readonly List<Assignment> assignments;

    private bool foldedOut = true;
    private List<AssignmentView> assignmentViews;

    public TemplateView(Templates.PrefabTemplate template, List<Assignment> assignments) {
      this.template = template;
      this.assignments = assignments;
    }

    public void Initialize() {
      this.assignmentViews = new List<AssignmentView>();
      foreach (Assignment assignment in this.assignments) {
        this.assignmentViews.Add(AssignmentViewMappings.Get(assignment));
      }
    }

    public void OnGUI() {
      #if UNITY_EDITOR
      EditorGUILayout.BeginVertical();
      this.foldedOut = EditorGUILayout.Foldout(this.foldedOut, this.template.name);

      if (this.foldedOut) {
        foreach (AssignmentView view in this.assignmentViews) {
          EditorGUILayout.BeginHorizontal();
          view.OnGUI();
          EditorGUILayout.EndHorizontal();
        }
      }

      EditorGUILayout.EndVertical();
      #endif
    }
  }
}
