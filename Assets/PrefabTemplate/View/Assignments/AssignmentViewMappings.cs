using System;
using PrefabTemplate.Templates.Assignments;
using UnityEngine;

namespace PrefabTemplate.View.Assignments {
  public static class AssignmentViewMappings {
    public static AssignmentView Get(Assignment assignment) {
      if (assignment.AssignmentType == typeof(Texture2D)) {
        return new SpriteAssignmentView(assignment as SpriteAssignment);
      }

      if (assignment.AssignmentType == typeof(Color)) {
        return new ColorAssignmentView(assignment as ColorAssignment);
      }

      if (assignment.AssignmentType == typeof(string)) {
        return new StringAssignmentView(assignment as StringAssignment);
      }

      throw new ArgumentException("Unexpected type " + assignment.AssignmentType);
    }
  }
}