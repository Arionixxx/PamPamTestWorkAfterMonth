using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Code_Figures
{
  public class InstantiatingFiguresScript : MonoBehaviour
  {
    [SerializeField] float _distance;
    public GameObject _coubeFromCubesFigure;
    public GameObject _pyramidFromCubesFigure;
    public GameObject _coubeFromSpheresFigure;
    public GameObject _pyramidFromSpheresFigure;

    [SerializeField] Transform parentTransform;
    private Figure _figure = new Figure();


  
  }
}
