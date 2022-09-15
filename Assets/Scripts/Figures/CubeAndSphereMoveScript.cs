using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Figures
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
      Destroy(gameObject);
    }
  }
}
