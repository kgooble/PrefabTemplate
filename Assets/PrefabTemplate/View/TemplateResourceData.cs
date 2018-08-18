using System.Collections.Generic;
using PrefabTemplate.Loader;

namespace PrefabTemplate.View {
  public class TemplateResourceData {
    public TemplateResourceData(List<ImageResource> images, Dictionary<string, string> stringReplacements) {
      this.Images = images;
      this.StringReplacements = stringReplacements;
    }

    public List<ImageResource> Images { get; private set; }

    public Dictionary<string, string> StringReplacements { get; private set; }
  }
}