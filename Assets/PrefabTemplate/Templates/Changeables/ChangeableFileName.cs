#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

#endif

namespace PrefabTemplate.Templates.Changeables {
  public class ChangeableFileName : ChangeableParametrizedString {
    public string originalFileName;

    public override bool PrefabRequired {
      get {
        return false;
      }
    }

    public override string Name {
      get {
        return this.defaultString;
      }
    }

    public override void Apply(string stringValue) {
#if UNITY_EDITOR
      string message = AssetDatabase.RenameAsset(this.originalFileName, stringValue);

      if (!string.IsNullOrEmpty(message)) {
        Debug.LogError("Asset rename error: " + message + " for " + this.originalFileName);
      }

      this.originalFileName = stringValue;
#endif
    }
  }
}