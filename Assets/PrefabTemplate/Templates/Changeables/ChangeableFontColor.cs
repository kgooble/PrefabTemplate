using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableFontColor : ChangeableColor {
    public Text[] texts;

    public override bool PrefabRequired {
      get {
        return true;
      }
    }

    public override string Name {
      get {
        if (this.texts.Length == 0 || this.texts[0] == null) {
          return "Unknown";
        }

        return this.texts[0].name;
      }
    }

    public override void Apply(Color color) {
      foreach (Text txt in this.texts) {
        txt.color = color;
      }
    }
  }
}