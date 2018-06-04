using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class ChangeableColor : Changeable {
    public Color defaultColor;

    public abstract void Apply(Color color);

    public override Assignment CreateAssignment(List<ImageResource> resources) {
      return new ColorAssignment(this, this.defaultColor);
    }
  }
}
