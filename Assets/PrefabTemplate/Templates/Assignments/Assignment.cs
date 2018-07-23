using System;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;

namespace PrefabTemplate.Templates.Assignments {
  public abstract class Assignment {
    public Changeable changeable;
    public PrefabTemplate template;

    protected Assignment(Changeable changeable) {
      this.changeable = changeable;
    }

    public abstract Type AssignmentType { get; }

    public abstract void Apply();

    public void Cleanup() {
      GameObject.DestroyImmediate(this.changeable, true);
      this.changeable = null;
    }

    public void SetTemplate(PrefabTemplate template) {
      this.template = template;
    }
  }
}