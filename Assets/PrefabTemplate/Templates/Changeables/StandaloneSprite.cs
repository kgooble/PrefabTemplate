using System;
using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  [Serializable]
  public class StandaloneSprite : Changeable {
    public Vector2 minSize;
    public Vector2 maxSize;
    public SimpleTextureImportSettings textureSettings;

    public bool Fits(int width, int height) {
      return this.minSize.x <= width && width <= this.maxSize.x && this.minSize.y <= height && height <= this.maxSize.y;
    }

    public virtual void Apply(Sprite sprite) {
    }

    public override Assignment CreateAssignment(List<ImageResource> resources) {
      ImageResource finalResource = null;

      foreach (ImageResource resource in resources) {
        if (this.Fits(resource.Width, resource.Height)) {
          finalResource = resource;
          resource.IncrementUsages();
          break;
        }
      }

      return new ImageSpriteAssignment(this, finalResource, this.textureSettings);
    }
  }
}
