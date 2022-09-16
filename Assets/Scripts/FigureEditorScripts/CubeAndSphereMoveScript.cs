using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actions;


namespace _Code_Figures
{
  public class CubeAndSphereMoveScript : MonoBehaviour
  { 
    private ExplosionScript _explosionScript;
    private Rigidbody _rb;

    private void OnEnable()
    {
      StartCoroutine(bulletDestroyCoroutine());
    }
    private void Start()
    {
      _rb = gameObject.GetComponent<Rigidbody>();
      _explosionScript = this.GetComponent<ExplosionScript>();
    }

    IEnumerator bulletDestroyCoroutine()
    {
      yield return new WaitForSeconds(3);
      _rb.isKinematic = true;
      gameObject.SetActive(false);
    }
  }
}
