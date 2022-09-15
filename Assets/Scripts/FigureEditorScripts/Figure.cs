using System;
using UnityEngine;

namespace _Code_Figures
{
  public class Figure : MonoBehaviour
  {
    [SerializeField] GameObject cubePref;
    [SerializeField] GameObject spherePref;
    [SerializeField] Transform parentTransform;
    [SerializeField] private GameObject figureInstantiationTransform;
    [SerializeField] private GameObject instantiations;
    [SerializeField] private FigureSettings settings;
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
      CreateFigureCube(tempMaterial, settings.length, settings.width, settings.height);
    }
    public void CreatePyramid()
    {
      CreateFigurePyramid(tempMaterial, settings.pyramidLevelsCount);
    }


    public void CreateFigureCube(GameObject go, int length, int width, int height)
    {
      GameObject _go = Instantiate(figureInstantiationTransform, instantiations.transform) as GameObject;
      _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);
      Vector3 tempPos = _go.transform.position;

      for (int i = 0; i < height; i++)
      {
        _go.transform.position = tempPos;
        tempPos = new Vector3(_go.transform.position.x, _go.transform.position.y + _figureScale, _go.transform.position.z);

        for (int j = 0; j < length; j++)
        {
          _go.transform.position = tempPos;
          _go.transform.position = new Vector3(_go.transform.position.x, _go.transform.position.y, _go.transform.position.z + (_figureScale * j));


          for (int k = 0; k < width; k++)
          {
            Instantiate(go, _go.transform.position, Quaternion.identity, instantiations.transform);
            _go.transform.position = new Vector3(_go.transform.position.x + _figureScale, _go.transform.position.y, _go.transform.position.z);
          }
        }
      }
    }

    /*   public void CreateFigurePyramid(GameObject go, int pyramidLevels)
       {
         GameObject _go = Instantiate(figureInstantiationTransform, instantiations.transform) as GameObject;
         _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);
         Vector3 tempPos = _go.transform.position;
         double tempMove;



         for (int i = pyramidLevels; i > 0; i--)
         {
           _go.transform.position = new Vector3(_go.transform.position.x - _figureScale * (1.5f * Convert.ToInt32(Math.Pow(2, (i-1)))), _go.transform.position.y + _figureScale, _go.transform.position.z);
           for (int j = 0; j < Math.Pow(2, i - 1); j++)
           {
             Instantiate(go, _go.transform.position, Quaternion.identity, instantiations.transform);
             _go.transform.position = new Vector3(_go.transform.position.x + _figureScale, _go.transform.position.y, _go.transform.position.z);
           }
         } 



       } */

    public void CreateFigurePyramid(GameObject go, int pyramidLevels)
    {
      GameObject _go = Instantiate(figureInstantiationTransform, instantiations.transform) as GameObject;
      _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);
      Vector3 tempPos = _go.transform.position;
      double tempMove;

      for (int i = pyramidLevels; i > 0; i--)
      {
        _go.transform.position = tempPos;
        tempPos = new Vector3(_go.transform.position.x, _go.transform.position.y + _figureScale, _go.transform.position.z);


        for (int j = i; j > 0; j--)
        {
          _go.transform.position = tempPos;
          _go.transform.position = new Vector3(_go.transform.position.x, _go.transform.position.y, _go.transform.position.z + (_figureScale * j));


          for (int k = i; k > 0; k--)
          {
            Instantiate(go, _go.transform.position, Quaternion.identity, instantiations.transform);
            _go.transform.position = new Vector3(_go.transform.position.x + _figureScale, _go.transform.position.y, _go.transform.position.z);
            
          }
        }
      }



    }
  }
}


