using UnityEngine;

[CreateAssetMenu(fileName = "Figure Settings", menuName = "ScriptableObjects/Figure Settings", order = 1)]
public class FigureSettings : ScriptableObject
{
  //for cube
    public int length = 5;
    public int width = 5;
    public int height = 5;

  //for pyramid
    public int pyramidLevelsCount = 3;

  //for bullets
    public float bulletSpeed = 30;
    public float bulletDamageForce = 30;
    public float bulletExplosionRadius = 1;
}