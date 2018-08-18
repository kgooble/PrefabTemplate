using System.Collections.Generic;
using PrefabTemplate.Loader;
using UnityEngine;

namespace PrefabTemplate.View {
  public class TemplateResourceData {
    public TemplateResourceData(List<ImageResource> images, Dictionary<string, string> stringReplacements) {
      this.Images = images;
      this.StringReplacements = stringReplacements;
    }

    public List<ImageResource> Images { get; private set; }

    public Dictionary<string, string> StringReplacements { get; private set; }

    public string FormatString(string initialValue, string[] parameterKeys) {
      List<string> parameterValues = new List<string>();

      foreach (string key in parameterKeys) {
        string value;
        if (this.StringReplacements.TryGetValue(key, out value)) {
          parameterValues.Add(value);
        } else {
          Debug.LogWarning("For string " + initialValue + ", could not find parameter with key: " + key);
        }
      }

      return string.Format(initialValue, parameterValues.ToArray());
    }
  }
}