using System.Collections.Generic;
using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class ChangeableParametrizedString : ChangeableString {
    public string[] parameterKeys;

    public override Assignment CreateAssignment(TemplateResourceData resources) {
      string initialValue = this.defaultString;
      List<string> parameterValues = new List<string>();

      foreach (string key in this.parameterKeys) {
        string value;
        if (resources.StringReplacements.TryGetValue(key, out value)) {
          parameterValues.Add(value);
        } else {
          Debug.LogWarning("For string " + this.defaultString + ", could not find parameter with key: " + key);
        }
      }

      initialValue = string.Format(initialValue, parameterValues.ToArray());
      return new StringAssignment(this, initialValue);
    }
  }
}