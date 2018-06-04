using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableShadowColor : ChangeableColor {
    public Shadow[] shadows;

    public override void Apply(Color color) {
      foreach (Shadow shadow in this.shadows) {
        shadow.effectColor = color;
      }
    }
  }
}
