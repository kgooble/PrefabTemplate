﻿using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates;
using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.Templates.Changeables;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;

namespace PrefabTemplate.View {
  public class TemplateWindow : EditorWindow {
    public static string importDirectory;
    public static string prefabTemplateDirectory;
    public static string outputDirectory;
    public static UnityAction onComplete;
    public static Dictionary<string, string> stringReplacements;

    private List<TemplateView> templateViews;

    // [MenuItem("PrefabTemplate/Show Window")]
    private static void Init() {
      ShowWindow();
    }

    public static void ShowWindow() {
      TemplateWindow window = (TemplateWindow)EditorWindow.GetWindow(typeof(TemplateWindow));
      window.Show();
    }

    private void OnGUI() {
      importDirectory = this.GetPath(importDirectory, "Import Directory:", "Select Folder", "Select a folder to import from.");
      prefabTemplateDirectory = this.GetPath(prefabTemplateDirectory, "Prefab Templates:", "Select Folder", "Select a prefab template folder.");
      outputDirectory = this.GetPath(outputDirectory, "Output Directory:", "Select Folder", "Select an output directory.");

      if (GUILayout.Button("Begin Import", GUILayout.Width(100))) {
        ImageResourceLoader imageLoader = new ImageResourceLoader(importDirectory, outputDirectory + "/Images");
        PrefabTemplateLoader prefabTemplateLoader = new PrefabTemplateLoader(prefabTemplateDirectory, outputDirectory + "/Prefabs");
        TemplateImport import = new TemplateImport(imageLoader.Get(), prefabTemplateLoader.Get(), stringReplacements ?? new Dictionary<string, string>());

        ImageResourceComparer comparer = new ImageResourceComparer();

        this.templateViews = new List<TemplateView>();
        foreach (Templates.PrefabTemplate template in import.Templates) {
          List<Assignment> assignments = new List<Assignment>();

          foreach (Changeable changeable in template.changeables) {
            Assignment assignment = changeable.CreateAssignment(import.ResourceData);

            assignment.SetTemplate(template);

            // Sort after every assignment so that unassigned images come first
            import.ResourceData.Images.Sort(comparer);

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
            bool required = false;

            foreach (Assignment assignment in view.assignments) {
              required |= assignment.PrefabRequired;
              assignment.Apply();
              assignment.Cleanup();
            }

            if (required) {
              template.MarkRequired();
            }

            template.Cleanup();
          }

          foreach (ImageResource resource in TemplateImport.Instance.ResourceData.Images) {

            if (resource.Usages <= 0) {
              Debug.Log("Resource " + resource.sprite.name + " had 0 usages, <color=red>deleting</color>.");
              resource.DeleteAsset();
            }
          }

          this.templateViews = null;
          TemplateImport.Clear();

          if (onComplete != null) {
            onComplete();
            onComplete = null;
          }
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
