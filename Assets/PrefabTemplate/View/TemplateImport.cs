using System.Collections.Generic;
using PrefabTemplate.Loader;
using UnityEngine;

namespace PrefabTemplate.View {
  public class TemplateImport {
    public static TemplateImport Instance { get; private set; }

    public List<ImageResource> Images { get; set; }

    public TemplateImport(List<ImageResource> images) {
      Instance = this;
      this.Images = images;
    }

    public ImageResource FindResource(Sprite sprite) {
      foreach (ImageResource resource in this.Images) {
        if (resource.sprite.GetInstanceID() == sprite.GetInstanceID()) {
          return resource;
        }
      }

      return null;
    }
  }
}