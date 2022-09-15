using UnityEngine;

[CreateAssetMenu(fileName = "Figure Settings", menuName = "ScriptableObjects/Figure Settings", order = 1)]
public class FigureSettings : ScriptableObject
{
    public int _row = 5;
    public int _column = 5;
}