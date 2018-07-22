﻿using System;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;
using UnityEngine.UI;

namespace PrefabTemplate.Templates.Assignments {
  public class SpriteAssignment : Assignment {
    private readonly SimpleTextureImportSettings textureSettings;
    private ImageResource resource;

    public Sprite sprite {
      get {
        return this.resource.sprite;
      }
    }

    public SpriteAssignment(ChangeableImageSprite changeable, ImageResource resource, SimpleTextureImportSettings textureSettings) : base(changeable) {
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

      ChangeableImageSprite changeable = this.changeable as ChangeableImageSprite;

      foreach (Image img in changeable.images) {
        img.sprite = this.sprite;
      }

      this.resource.RenameAsset(this.textureSettings.name);
      this.resource.ApplyTextureImportSettings(this.textureSettings);
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