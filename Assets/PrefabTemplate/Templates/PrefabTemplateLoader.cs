using System.IO;
using PrefabTemplate.Loader;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.Templates {
  public class PrefabTemplateLoader : AssetCollector<PrefabTemplate> {
    public PrefabTemplateLoader(string assetsDirectory, string finalDirectory) :
      base(
        assetsDirectory,
        finalDirectory,
        "*.prefab",
        (originalPath, absolutePath, relativePath) => {
          #if UNITY_EDITOR
          string originalRelativePath = originalPath.Substring(originalPath.IndexOf("Assets"), originalPath.Length - originalPath.IndexOf("Assets"));
          GameObject existingObject = AssetDatabase.LoadAssetAtPath<GameObject>(originalRelativePath);

          if (existingObject) {
            GameObject newObject = PrefabUtility.CreatePrefab(relativePath, existingObject);
            return newObject.GetComponent<PrefabTemplate>();
          }

          File.Copy(originalPath, absolutePath);
          AssetDatabase.ImportAsset(relativePath);
          return AssetDatabase.LoadAssetAtPath<GameObject>(relativePath).GetComponent<PrefabTemplate>();
          #else
          return null;
          #endif
        })
    {
    }
  }
}
