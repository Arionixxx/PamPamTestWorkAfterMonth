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
    [SerializeField] float _distance = 8;
    [SerializeField] Transform playerTransform;
    private GameObject tempMaterial;
    private float _figureScale = 5;

    private void Awake()
    {
      tempMaterial = cubePref;
      GenerateFigures();
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
      Vector3 tempPos_ = tempPos;

      for (int i = 0; i < height; i++)
      {
        tempPos_ = tempPos;
        tempPos = new Vector3(tempPos_.x, tempPos_.y + _figureScale, tempPos_.z);

        for (int j = 0; j < length; j++)
        {
          tempPos_ = tempPos;
          tempPos_ = new Vector3(tempPos_.x, tempPos_.y, tempPos_.z + (_figureScale * j));


          for (int k = 0; k < width; k++)
          {
            Instantiate(go, tempPos_, Quaternion.identity, _go.transform);
            tempPos_ = new Vector3(tempPos_.x + _figureScale, tempPos_.y, tempPos_.z);
          }
        }
      }
    }

    public void CreateFigurePyramid(GameObject go, int pyramidLevels)
    {
      GameObject _go = Instantiate(figureInstantiationTransform, instantiations.transform) as GameObject;
      _go.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z);
      Vector3 tempPos = _go.transform.position;
      Vector3 tempPos_ = tempPos;

      for (int i = pyramidLevels; i > 0; i--)
      {
        tempPos_ = tempPos;
        tempPos = new Vector3(tempPos_.x + _figureScale * 0.5f, tempPos_.y + _figureScale, tempPos_.z + _figureScale * 0.5f);


        for (int j = i; j > 0; j--)
        {
          tempPos_ = tempPos;
          tempPos_ = new Vector3(tempPos_.x, tempPos_.y, tempPos_.z + (_figureScale * j));


          for (int k = i; k > 0; k--)
          {
            Instantiate(go, tempPos_, Quaternion.identity, _go.transform);
            tempPos_ = new Vector3(tempPos_.x + _figureScale, tempPos_.y, tempPos_.z);
            
          }
        }
      }
    }

    public void GenerateFigures()
    {
      parentTransform.position = new Vector3(playerTransform.position.x + _distance, 0, playerTransform.position.z);
      CubeAsAMaterial();
      CreateCube();
      parentTransform.position = new Vector3(playerTransform.position.x - _distance, 0, playerTransform.position.z);
      CreatePyramid();
      parentTransform.position = new Vector3(playerTransform.position.x, 0, playerTransform.position.z + _distance);
      SphereAsAMaterial();
      CreatePyramid();
      parentTransform.position = new Vector3(playerTransform.position.x, 0, playerTransform.position.z - _distance);
      CreateCube();

    }
  }
}


