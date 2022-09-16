using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actions;


namespace _Code_Figures
{
  public class CubeAndSphereMoveScript : MonoBehaviour
  { 
    private ExplosionScript _explosionScript;

    private void OnEnable()
    {
      StartCoroutine(bulletDestroyCoroutine());
    }
    private void Start()
    {
      _explosionScript = this.GetComponent<ExplosionScript>();
      //StartCoroutine(bulletDestroyCoroutine());
    }

    IEnumerator bulletDestroyCoroutine()
    {
      yield return new WaitForSeconds(3);
      gameObject.SetActive(false);
      ShotScript.poolBullets.Add(_explosionScript);
    }
  }
}
