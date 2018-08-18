using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableText : ChangeableString {
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

    public override void Apply(string stringValue) {
      foreach (Text txt in this.texts) {
        txt.text = stringValue;
      }
    }
  }
}
