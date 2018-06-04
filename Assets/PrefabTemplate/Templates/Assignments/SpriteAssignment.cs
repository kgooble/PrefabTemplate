using System;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Assignments {
  public class SpriteAssignment : Assignment {
    public Sprite sprite { get; set; }

    public SpriteAssignment(ChangeableImageSprite changeable, Sprite sprite) : base(changeable) {
      this.sprite = sprite;
    }

    public override Type AssignmentType {
      get {
        return typeof(Texture2D);
      }
    }

    public override void Apply() {
      if (!this.changeable) {
        return;
      }

      ChangeableImageSprite changeable = this.changeable as ChangeableImageSprite;

      foreach (Image img in changeable.images) {
        img.sprite = this.sprite;
      }
    }
  }
}