using System;
using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;
using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Changeables {
  [Serializable]
  public class ChangeableImageSprite : Changeable {
    public Image[] images;
    public Vector2 minSize;
    public Vector2 maxSize;
    public SimpleTextureImportSettings textureSettings;

    public bool Fits(int width, int height) {
      return this.minSize.x <= width && width <= this.maxSize.x && this.minSize.y <= height && height <= this.maxSize.y;
    }

    public override Assignment CreateAssignment(List<ImageResource> resources) {
      Sprite sprite = null;

      foreach (ImageResource resource in resources) {
        if (this.Fits(resource.Width, resource.Height)) {
          sprite = resource.sprite;
          resource.ApplyTextureImportSettings(this.textureSettings);
          resource.IncrementUsages();
          break;
        }
      }

      return new SpriteAssignment(this, sprite);
    }
  }
}
