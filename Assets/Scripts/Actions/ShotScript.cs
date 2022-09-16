using _Code_Figures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
  public class ShotScript : MonoBehaviour
  {
    [SerializeField] ExplosionScript _cube;
    [SerializeField] ExplosionScript _sphere;
    [SerializeField] FigureSettings settings;
    [SerializeField] float _shotForce;


    private ExplosionScript bullet; //cube/sphere instantiation script
  
    private void Awake()
    {
      List<ExplosionScript> poolBullets = new List<ExplosionScript>();
      for (int i = 0; i  < 10; i++)
      {
        ExplosionScript cube = new ExplosionScript();
        cube = _cube;
        cube.gameObject.SetActive(false);
        poolBullets.Add(cube);
      }
      for (int i = 0; i < 10; i++)
      {
        ExplosionScript sphere = new ExplosionScript();
        sphere = _sphere;
        sphere.gameObject.SetActive(false);
        poolBullets.Add(sphere);
      }
      RandomShuffle(poolBullets);
      foreach (var pool in poolBullets)
      {
        Debug.Log (pool);
      }
    }

    private void RandomShuffle(List<ExplosionScript> poolBullets)
    {
      for (int i = poolBullets.Count - 1; i >= 1; i--)
      {
        int j = Random.Range(1, 10); 
        var temp = poolBullets[j];
        poolBullets[j] = poolBullets[i];
        poolBullets[i] = temp;
      }
    }


    public void OnShotButtonDown()
    {
      _shotForce = settings.bulletSpeed;

      Vector3 shotVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);

      float randNum = Random.Range(1, 3);

      if (randNum == 1)
      {
        bullet = Instantiate(_cube, shotVector, Quaternion.identity);
      }
      else

      {
        bullet = Instantiate(_sphere, shotVector, Quaternion.identity);
      }

      bullet.Rigidbody.AddForce(transform.forward * _shotForce);
      StartCoroutine(InstantiationCorutine());
    }

    IEnumerator InstantiationCorutine()
    {
      yield return new WaitForSeconds(settings.rebuildingTime);
      Figure.FigureDestroyingAction?.Invoke();
    }
  }
}
