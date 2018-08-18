using System;
using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  [Serializable]
  public class StandaloneSprite : Changeable {
    [Header("Asset Requirements")]
    public Vector2 minSize;
    public Vector2 maxSize;
    public string nameContains;

    [Header("Import Settings")]
    public SimpleTextureImportSettings textureSettings;

    public virtual bool PrefabRequired {
      get {
        return false;
      }
    }

    public override string Name {
      get {
        return this.nameContains;
      }
    }

    public bool Fits(string name, int width, int height) {
      bool widthFits = this.minSize.x <= width && width <= this.maxSize.x;
      bool heightFits = this.minSize.y <= height && height <= this.maxSize.y;
      bool nameFits = string.IsNullOrEmpty(this.nameContains) || name.ToLower().Contains(this.nameContains.ToLower());
      return widthFits && heightFits && nameFits;
    }

    public virtual void Apply(Sprite sprite) {
    }

    public override Assignment CreateAssignment(List<ImageResource> resources) {
      ImageResource finalResource = null;

      foreach (ImageResource resource in resources) {
        if (this.Fits(resource.Name, resource.Width, resource.Height)) {
          finalResource = resource;
          resource.IncrementUsages();
          break;
        }
      }

      return new ImageSpriteAssignment(this, finalResource, this.textureSettings);
    }
  }
}
