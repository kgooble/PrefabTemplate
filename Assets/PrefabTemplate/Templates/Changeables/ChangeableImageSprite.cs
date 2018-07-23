using System;
using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;
using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  [Serializable]
  public class ChangeableImageSprite : StandaloneSprite {
    public Image[] images;

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
