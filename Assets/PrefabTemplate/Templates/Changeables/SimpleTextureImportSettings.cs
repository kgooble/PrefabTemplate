using System;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  [Serializable]
  public class SimpleTextureImportSettings : System.Object {
    public string name;
    public int maxTextureSize = 2048;
    public bool alphaIsTransparency = true;
    public bool mipmapEnabled = false;
    public TextureWrapMode wrapMode = TextureWrapMode.Clamp;
  }
}
