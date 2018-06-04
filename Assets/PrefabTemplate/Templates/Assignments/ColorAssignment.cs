using System;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;

namespace PrefabTemplate.Templates.Assignments {
  public class ColorAssignment : Assignment{
    public Color color { get; set; }

    public ColorAssignment(ChangeableColor changeable, Color color) : base(changeable) {
      this.color = color;
    }

    public override Type AssignmentType {
      get {
        return typeof(Color);
      }
    }

    public override void Apply() {
      if (!this.changeable) {
        return;
      }

      ChangeableColor changeable = this.changeable as ChangeableColor;
      changeable.Apply(this.color);
    }
  }
}
