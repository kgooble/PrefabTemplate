using System;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;

namespace PrefabTemplate.Templates.Assignments {
  public abstract class Assignment {
    public Changeable changeable;

    protected Assignment(Changeable changeable) {
      this.changeable = changeable;
    }

    public abstract Type AssignmentType { get; }

    public abstract void Apply();

    public void Cleanup() {
      GameObject.DestroyImmediate(this.changeable, true);
      this.changeable = null;
    }
  }
}