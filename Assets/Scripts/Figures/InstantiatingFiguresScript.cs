using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Figures
{
  public class InstantiatingFiguresScript : MonoBehaviour
  {
    [SerializeField] float _distance;
    public GameObject _coubeFromCubesFigure;
    public GameObject _pyramidFromCubesFigure;
    public GameObject _coubeFromSpheresFigure;
    public GameObject _pyramidFromSpheresFigure;


    private void Start()
    {
      GenerateFigures();
    }
    public void GenerateFigures()
    {
      Instantiate(_coubeFromCubesFigure, new Vector3(transform.position.x + _distance, 0, transform.position.z), Quaternion.identity);
      Instantiate(_pyramidFromCubesFigure, new Vector3(transform.position.x - _distance, 0, transform.position.z), Quaternion.identity);
      Instantiate(_coubeFromSpheresFigure, new Vector3(transform.position.x, 0, transform.position.z + _distance), Quaternion.identity);
      Instantiate(_pyramidFromSpheresFigure, new Vector3(transform.position.x, 0, transform.position.z - _distance), Quaternion.identity);
    }
  }
}
