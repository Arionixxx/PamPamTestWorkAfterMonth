using UnityEditor;
using UnityEngine;

namespace _Code_Figures
{
  [CustomEditor(typeof(Figure))]
  public class EditorFigure : Editor
  {
    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      Figure _figure = (Figure)target;


      if (GUILayout.Button("Sphere as a material"))
      {
        _figure.SphereAsAMaterial();
      }
      if (GUILayout.Button("Cube as a material"))
      {
        _figure.CubeAsAMaterial();
      }
      if (GUILayout.Button("Create cube"))
      {
        _figure.CreateCube();
      }
      if (GUILayout.Button("Sphere as a material"))
      {
        _figure.SphereAsAMaterial();
      }
    }
  }
}
