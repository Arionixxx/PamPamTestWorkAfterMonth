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

    private Vector3 startPos;
    private Quaternion startRot;
    private int bulletIndex;

    public static List<ExplosionScript> poolBullets;


    private ExplosionScript bullet;
  
    private void Awake()
    {
      startPos = _cube.transform.position;
      startRot = _cube.transform.rotation;
      poolBullets = new List<ExplosionScript>();
      for (int i = 0; i  < 10; i++)
      {
        ExplosionScript cube = new ExplosionScript();
        cube = Instantiate(_cube);
        cube.gameObject.SetActive(false);
        poolBullets.Add(cube);
      }
      for (int i = 0; i < 10; i++)
      {
        ExplosionScript sphere = new ExplosionScript();
        sphere = Instantiate(_sphere);
        sphere.gameObject.SetActive(false);
        poolBullets.Add(sphere);
      }
      RandomShuffle(poolBullets);
      bulletIndex = poolBullets.Count;
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
      Quaternion shotRotation = transform.rotation;

      if (bulletIndex <= 1)
      {
        bulletIndex = poolBullets.Count;
      }
      bullet = poolBullets[bulletIndex-1];
      bulletIndex--;
      bullet.Rigidbody.isKinematic = false;
      bullet.transform.position = shotVector;
      bullet.transform.rotation = shotRotation;
      bullet.gameObject.SetActive(true);
      bullet.Rigidbody.AddForce(transform.forward * _shotForce);
    }
  }
}
