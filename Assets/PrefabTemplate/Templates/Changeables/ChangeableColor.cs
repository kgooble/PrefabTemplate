using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class ChangeableColor : Changeable {
    public Color defaultColor;

    public abstract void Apply(Color color);

    public override Assignment CreateAssignment(TemplateResourceData resources) {
      return new ColorAssignment(this, this.defaultColor);
    }
  }
}
