using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class ChangeableString : Changeable {
    public string defaultString;

    public override Assignment CreateAssignment(List<ImageResource> resources) {
      return new StringAssignment(this, this.defaultString);
    }

    public abstract void Apply(string stringValue);
  }
}
