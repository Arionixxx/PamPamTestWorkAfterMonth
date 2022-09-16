using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Code_Figures
{
  public class CubeAndSphereMoveScript : MonoBehaviour
  {
    private void Start()
    {
      StartCoroutine(bulletDestroyCoroutine());
    }

    IEnumerator bulletDestroyCoroutine()
    {
      yield return new WaitForSeconds(3);
      gameObject.SetActive(false);
    }
  }
}
