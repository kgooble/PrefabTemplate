using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.Loader {
  public class ImageResourceLoader : AssetCollector<ImageResource> {
    public ImageResourceLoader(string assetsDirectory, string finalDirectory) :
      base(
        assetsDirectory,
        finalDirectory,
        "*.png",
        (originalPath, absolutePath, relativePath) => {
          File.Copy(originalPath, absolutePath);

          Sprite sprite = null;

          #if UNITY_EDITOR
          AssetDatabase.ImportAsset(relativePath);
          sprite = AssetDatabase.LoadAssetAtPath<Sprite>(relativePath);
          #endif

          return new ImageResource(sprite, relativePath);
        }) {
    }
  }
}
