﻿using System.Collections.Generic;
using PrefabTemplate.Loader;
using PrefabTemplate.Templates.Assignments;
using PrefabTemplate.View;
using UnityEngine;

namespace PrefabTemplate.Templates.Changeables {
  public abstract class Changeable : MonoBehaviour {
    public abstract string Name { get; }

    public abstract Assignment CreateAssignment(TemplateResourceData resources);
  }
}