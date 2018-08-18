using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class ChangeableString : Changeable {
    public string defaultString;

    public override Assignment CreateAssignment(TemplateResourceData resources) {
      return new StringAssignment(this, this.defaultString);
    }

    public abstract void Apply(string stringValue);
  }
}
