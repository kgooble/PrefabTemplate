using System;
using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  [Serializable]
  public class ChangeableImageSprite : StandaloneSprite {
    public Image[] images;

    public override string Name {
      get {
        if (this.images.Length == 0 || this.images[0] == null) {
          return "Unknown";
        }

        return this.images[0].name;
      }
    }

    public override bool PrefabRequired {
      get {
        return true;
      }
    }

    public override void Apply(Sprite sprite) {
      foreach (Image img in this.images) {
        img.sprite = sprite;
      }
    }
  }
}
