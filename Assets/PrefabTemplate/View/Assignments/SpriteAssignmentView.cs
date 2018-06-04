﻿using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.Utility;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.View.Assignments {
  public class SpriteAssignmentView : AssignmentView {
    private readonly SpriteAssignment assignment;

    public SpriteAssignmentView(SpriteAssignment assignment) {
      this.assignment = assignment;
    }

    public override string Name {
      get {
        return this.assignment.changeable.Name;
      }
    }

    public override void OnGUI() {
      #if UNITY_EDITOR
      EditorTools.FieldTypeLabel("Sprite");
      EditorTools.FieldNameLabel(this.Name);
      this.assignment.sprite = EditorGUILayout.ObjectField(this.assignment.sprite, typeof(Sprite), allowSceneObjects: true) as Sprite;
      #endif
    }
  }
}