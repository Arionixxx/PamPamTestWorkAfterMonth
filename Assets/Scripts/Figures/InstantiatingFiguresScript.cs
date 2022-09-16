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


    /*   private void Start()
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

       */

    /*   private void Start()
       {
         GenerateFigures();
       }
       public void GenerateFigures()
       {
         parentTransform.position = new Vector3(transform.position.x + _distance, 0, transform.position.z);
         _figure.CubeAsAMaterial();
         _figure.CreateCube();
         parentTransform.position = new Vector3(transform.position.x - _distance, 0, transform.position.z);
         _figure.CreatePyramid();
         parentTransform.position = new Vector3(transform.position.x, 0, transform.position.z + _distance);
         _figure.SphereAsAMaterial();
         _figure.CreatePyramid();
         parentTransform.position = new Vector3(transform.position.x, 0, transform.position.z - _distance);
         _figure.CreateCube();

       }
    */
  }
}
