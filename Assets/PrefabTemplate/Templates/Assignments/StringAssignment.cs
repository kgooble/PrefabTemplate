using System;
using PrefabTemplate.Templates.Changeables;

namespace PrefabTemplate.Templates.Assignments {
  public class StringAssignment : Assignment {
    public string stringValue { get; set; }

    public StringAssignment(ChangeableString changeable, string stringValue) : base(changeable) {
      this.stringValue = stringValue;
    }

    public override Type AssignmentType {
      get {
        return typeof(string);
      }
    }

    public override void Apply() {
      if (!this.changeable) {
        return;
      }

      ChangeableString changeable = this.changeable as ChangeableString;
      changeable.Apply(this.stringValue);
      this.template.MarkRequired();
    }
  }
}
