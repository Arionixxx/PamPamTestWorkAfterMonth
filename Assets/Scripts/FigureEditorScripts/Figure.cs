using UnityEngine;

namespace _Code_Figures
{
  public class Figure : MonoBehaviour
  {
    [SerializeField] GameObject cubePref;
    [SerializeField] GameObject spherePref;
    [SerializeField] Transform parentTransform;
    [SerializeField] private GameObject figureInstantiationTransform;
    private GameObject tempMaterial;
    private float _figureScale;

    private void Awake()
    {
      tempMaterial = cubePref;
    }

    public void CubeAsAMaterial()
    {
      tempMaterial = cubePref;
      _figureScale = tempMaterial.transform.localScale.x;
      Debug.Log("Cube will be as a material for figure");
    }
    public void SphereAsAMaterial()
    {
      tempMaterial = spherePref;
      _figureScale = tempMaterial.transform.localScale.x;
      Debug.Log("Sphere will be as a material for figure");
    }
    public void CreateCube()
    {
      //add script for parent transform moving if another object are nearby
      CreateFigureCube(tempMaterial, 5, 5, 5);
    }
    public void CreateSphere()
    {
      Debug.Log("sphere was created");
    }


    /*  public void CreateFigureCube(GameObject go, int length, int width, int height)//length, width, height will be taken from settings file 
      {
        GameObject _go = Instantiate(figureInstantiationTransform) as GameObject;
        // _go.transform.position = parentTransform.position;
        _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);

        // Debug.Log(figureInstantiationTransform.position);
        for (int i = 0; i < height; i++)
        {
          //move to the start position and up by the radius or side of cube
          _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y + _figureScale * (i + 1), parentTransform.position.z);

          for (int j = 0; j < length; j++)
          {
            //move to the start position and move to the side by the distance of the radius or side of the cube
            _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z + _figureScale * (j + 1));

            for (int k = 0; k < width; k++)
            {
              //  Instantiate(go, figureInstantiationTransform.position, Quaternion.identity, parentTransform);
              // Instantiate(go, _go.transform.position, Quaternion.identity, _go.transform);
              Instantiate(go, _go.transform.position, Quaternion.identity);
              _go.transform.position = new Vector3(parentTransform.position.x + _figureScale * (k + 1), parentTransform.position.y, parentTransform.position.z);
               Debug.Log(_go.transform.position); 
            }
          }
        }
      } */

    public void CreateFigureCube(GameObject go, int length, int width, int height)
    {
      GameObject _go = Instantiate(figureInstantiationTransform) as GameObject;
      _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);
      Vector3 tempPos = _go.transform.position;

      for (int i = 0; i < height; i++)
      {
        _go.transform.position = tempPos;
       // _go.transform.position = new Vector3(_go.transform.position.x, _go.transform.position.y + (_figureScale * i), _go.transform.position.z);
       tempPos = new Vector3(_go.transform.position.x, _go.transform.position.y + _figureScale, _go.transform.position.z);

        for (int j = 0; j < length; j++)
        {
          _go.transform.position = tempPos;
          _go.transform.position = new Vector3(_go.transform.position.x, _go.transform.position.y, _go.transform.position.z + (_figureScale * j));


          for (int k = 0; k < width; k++)
          {
            Instantiate(go, _go.transform.position, Quaternion.identity);
            _go.transform.position = new Vector3(_go.transform.position.x + _figureScale, _go.transform.position.y, _go.transform.position.z);
            Debug.Log(_go.transform.position);
          }
        }
      }


    }



  }
}


