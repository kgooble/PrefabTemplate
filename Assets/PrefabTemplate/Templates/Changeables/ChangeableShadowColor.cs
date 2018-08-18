using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableShadowColor : ChangeableColor {
    public Shadow[] shadows;

    public override bool PrefabRequired {
      get {
        return true;
      }
    }

    public override string Name {
      get {
        if (this.shadows.Length == 0 || this.shadows[0] == null) {
          return "Unknown";
        }

        return this.shadows[0].name;
      }
    }

    public override void Apply(Color color) {
      foreach (Shadow shadow in this.shadows) {
        shadow.effectColor = color;
      }
    }
  }
}
