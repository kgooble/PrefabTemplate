﻿using System.Collections.Generic;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.Loader {
  public class ImageResource {
    public readonly Sprite sprite;
    private readonly string path;

    public ImageResource(Sprite sprite, string path) {
      this.sprite = sprite;
      this.path = path;
      this.Usages = 0;
    }

    public int Usages { get; private set; }

    public int Width {
      get {
        return this.sprite.texture.width;
      }
    }

    public int Height {
      get {
        return this.sprite.texture.height;
      }
    }

    public void IncrementUsages() {
      this.Usages++;
    }

    public void ApplyTextureImportSettings(SimpleTextureImportSettings textureSettings) {
      #if UNITY_EDITOR
      string newPath = this.path.Substring(0, this.path.LastIndexOf("/")) + "/" + textureSettings.name + ".png";
      AssetDatabase.RenameAsset(this.path, textureSettings.name);
      TextureImporter importer = AssetImporter.GetAtPath(newPath) as TextureImporter;
      importer.alphaIsTransparency = textureSettings.alphaIsTransparency;
      importer.maxTextureSize = textureSettings.maxTextureSize;
      importer.mipmapEnabled = textureSettings.mipmapEnabled;
      importer.wrapMode = textureSettings.wrapMode;
      importer.SaveAndReimport();
      #endif
    }
  }

  public class ImageResourceComparer : IComparer<ImageResource> {
    public int Compare(ImageResource x, ImageResource y) {
      int usageComparison = x.Usages.CompareTo(y.Usages);

      if (usageComparison == 0) {
        return x.sprite.name.CompareTo(y.sprite.name);
      }

      return usageComparison;
    }
  }
}