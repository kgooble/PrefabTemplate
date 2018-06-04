using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates;
using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace PrefabTemplate.View {
  public class TemplateWindow : EditorWindow {
    private string importDirectory;
    private string prefabTemplateDirectory;
    private string outputDirectory;
    private List<TemplateView> templateViews;

    // Add menu named "My Window" to the Window menu
    [MenuItem("PrefabTemplate/Show Window")]
    static void Init()
    {
      // Get existing open window or if none, make a new one:
      TemplateWindow window = (TemplateWindow)EditorWindow.GetWindow(typeof(TemplateWindow));
      window.Show();
    }

    private void OnGUI() {
      this.importDirectory = this.GetPath(this.importDirectory, "Import Directory:", "Select Folder", "Select a folder to import from.");
      this.prefabTemplateDirectory = this.GetPath(this.prefabTemplateDirectory, "Prefab Templates:", "Select Folder", "Select a prefab template folder.");
      this.outputDirectory = this.GetPath(this.outputDirectory, "Output Directory:", "Select Folder", "Select an output directory.");

      if (GUILayout.Button("Begin Import", GUILayout.Width(100))) {
        ImageResourceLoader imageLoader = new ImageResourceLoader(this.importDirectory, this.outputDirectory + "/Images");
        PrefabTemplateLoader prefabTemplateLoader = new PrefabTemplateLoader(this.prefabTemplateDirectory, this.outputDirectory + "/Prefabs");

        List<ImageResource> images = imageLoader.Get();
        List<Templates.PrefabTemplate> templates = prefabTemplateLoader.Get();
        ImageResourceComparer comparer = new ImageResourceComparer();

        this.templateViews = new List<TemplateView>();
        foreach (Templates.PrefabTemplate template in templates) {
          List<Assignment> assignments = new List<Assignment>();

          foreach (Changeable changeable in template.changeables) {
            Assignment assignment = changeable.CreateAssignment(images);
            images.Sort(comparer);
            assignments.Add(assignment);
          }

          TemplateView templateView = new TemplateView(template, assignments);
          templateView.Initialize();
          this.templateViews.Add(templateView);
        }
      }

      if (this.templateViews != null) {
        foreach (TemplateView view in this.templateViews) {
          view.OnGUI();
        }

        if (GUILayout.Button("Export", GUILayout.Width(100))) {
          foreach (TemplateView view in this.templateViews) {
            Templates.PrefabTemplate template = view.template;

            foreach (Assignment assignment in view.assignments) {
              assignment.Apply();
              assignment.Cleanup();
            }

            template.Cleanup();
          }

          this.templateViews = null;
        }
      }
    }

    private string GetPath(string originalValue, string label, string buttonLabel, string pathLabel) {
      EditorGUILayout.BeginHorizontal();

      string path = EditorGUILayout.TextField(label, originalValue);
      bool import = GUILayout.Button(buttonLabel, GUILayout.Width(100));

      if (import) {
        path = EditorUtility.OpenFolderPanel(pathLabel, "", "");
      }

      EditorGUILayout.EndHorizontal();
      return path;
    }
  }
}
#endif
