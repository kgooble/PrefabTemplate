using System.Collections.Generic;
using PrefabTemplate.Loader;
using UnityEngine;

namespace PrefabTemplate.View {
  public class TemplateImport {
    public static TemplateImport Instance { get; private set; }

    public TemplateResourceData ResourceData { get; private set; }

    public List<Templates.PrefabTemplate> Templates { get; private set; }

    public TemplateImport(List<ImageResource> images, List<Templates.PrefabTemplate> templates, Dictionary<string, string> stringReplacements) {
      Instance = this;
      this.Templates = templates;
      this.ResourceData = new TemplateResourceData(images, stringReplacements);
    }

    public ImageResource FindResource(Sprite sprite) {
      foreach (ImageResource resource in this.ResourceData.Images) {
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