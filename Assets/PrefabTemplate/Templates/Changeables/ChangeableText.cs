using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableText : ChangeableString {
    public Text[] texts;

    public override void Apply(string stringValue) {
      foreach (Text txt in this.texts) {
        txt.text = stringValue;
      }
    }
  }
}
