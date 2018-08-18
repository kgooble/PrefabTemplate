using System;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Assignments {
  public class ImageSpriteAssignment : Assignment {
    private readonly SimpleTextureImportSettings textureSettings;
    private ImageResource resource;

    public Sprite sprite {
      get {
        if (this.resource == null) {
          return null;
        }

        return this.resource.sprite;
      }
    }

    public ImageSpriteAssignment(StandaloneSprite changeable, ImageResource resource, SimpleTextureImportSettings textureSettings) : base(changeable) {
      this.resource = resource;
      this.textureSettings = textureSettings;
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

      StandaloneSprite changeable = this.changeable as StandaloneSprite;

      changeable.Apply(this.sprite);

      this.resource.RenameAsset(this.textureSettings.name);
      this.resource.ApplyTextureImportSettings(this.textureSettings);

      if (changeable.PrefabRequired) {
        this.template.MarkRequired();
      }
    }

    public void UpdateResource(ImageResource resource) {
      if (resource == null) {
        Debug.LogError("Cannot set as sprite assignment. No such image resource was imported.");
        return;
      }

      if (resource == this.resource) {
        return;
      }

      this.resource.DecrementUsages();
      this.resource = resource;
      this.resource.IncrementUsages();
    }
  }
}