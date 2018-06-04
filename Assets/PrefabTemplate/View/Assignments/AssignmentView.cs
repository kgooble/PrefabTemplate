namespace PrefabTemplate.View.Assignments {
  public abstract class AssignmentView {
    public abstract string Name { get; }

    public abstract void OnGUI();
  }
}