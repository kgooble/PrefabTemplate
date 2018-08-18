using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class Changeable : MonoBehaviour {
    public abstract bool PrefabRequired { get; }

    public abstract string Name { get; }

    public abstract Assignment CreateAssignment(TemplateResourceData resources);
  }
}