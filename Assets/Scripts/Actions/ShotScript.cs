using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
  public class ShotScript : MonoBehaviour
  {
    [SerializeField] GameObject _cube;
    [SerializeField] GameObject _sphere;
    [SerializeField] float _shotForce;

    private GameObject bullet; //cube/sphere instantiation script

    public void OnShotButtonDown()
    {

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

      bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shotForce);
    }
  }
}
