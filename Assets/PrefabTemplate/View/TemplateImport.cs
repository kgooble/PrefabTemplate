using System.Collections.Generic;
using PrefabTemplate.Loader;
using UnityEngine;

namespace PrefabTemplate.View {
  public class TemplateImport {
    public static TemplateImport Instance { get; private set; }

    public List<ImageResource> Images { get; private set; }

    public List<Templates.PrefabTemplate> Templates { get; private set; }

    public TemplateImport(List<ImageResource> images, List<Templates.PrefabTemplate> templates) {
      Instance = this;
      this.Images = images;
      this.Templates = templates;
    }

    public ImageResource FindResource(Sprite sprite) {
      foreach (ImageResource resource in this.Images) {
        if (resource.sprite.GetInstanceID() == sprite.GetInstanceID()) {
          return resource;
        }
      }

      return null;
    }

    public static void Clear() {
      Instance = null;
    }
  }
}