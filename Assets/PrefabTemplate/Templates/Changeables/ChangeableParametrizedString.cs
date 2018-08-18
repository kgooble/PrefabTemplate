using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class ChangeableParametrizedString : ChangeableString {
    public string[] parameterKeys;

    public override Assignment CreateAssignment(TemplateResourceData resources) {
      return new StringAssignment(this, resources.FormatString(this.defaultString, this.parameterKeys));
    }
  }
}