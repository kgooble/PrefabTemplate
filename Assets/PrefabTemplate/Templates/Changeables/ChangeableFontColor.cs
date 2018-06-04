using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableFontColor : ChangeableColor {
    public Text[] texts;

    public override void Apply(Color color) {
      foreach (Text txt in this.texts) {
        txt.color = color;
      }
    }
  }
}