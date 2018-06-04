using System;
using System.Collections.Generic;
using System.IO;
using PrefabTemplate.Utility;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PrefabTemplate.Loader {
  public class AssetCollector<T> {
    private const string DELIMITER = "/";

    private readonly string assetsDirectory;
    private readonly string finalDirectory;
    private readonly string extension;
    private readonly Func<string, string, string, T> fileConverter;

    public AssetCollector(string assetsDirectory, string finalDirectory, string extension, Func<string, string, string, T> fileConverter) {
      this.assetsDirectory = assetsDirectory;
      this.finalDirectory = finalDirectory;
      this.extension = extension;
      this.fileConverter = fileConverter;
    }

    public List<T> Get() {
      string[] imagePaths = Directory.GetFiles(this.assetsDirectory, this.extension, SearchOption.TopDirectoryOnly);

      this.CreateDirectoryIfNotExists();
      return this.CollectFiles(imagePaths);
    }

    private void CreateDirectoryIfNotExists() {
      #if UNITY_EDITOR
      if (!Directory.Exists(this.finalDirectory)) {
        Directory.CreateDirectory(this.finalDirectory);
        AssetDatabase.ImportAsset(this.finalDirectory.GetRelativePath("Assets"));
      }
      #endif
    }

    private List<T> CollectFiles(string[] imagePaths) {
      List<T> assets = new List<T>();

      foreach (string path in imagePaths) {
        string fileName = path.GetFileName();
        string newPath = this.finalDirectory + DELIMITER + fileName;
        string relativePath = newPath.GetRelativePath("Assets");

        T asset = this.fileConverter(path, newPath, relativePath);
        assets.Add(asset);
      }

      return assets;
    }
  }
}
