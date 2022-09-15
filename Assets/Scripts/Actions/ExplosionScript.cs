using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
  public class ExplosionScript : MonoBehaviour
  {

    public float _radius;
    public float _force;

    public void Explode()
    {
      Collider[] overlappedCollidersForDestroing = Physics.OverlapSphere(transform.position, _radius);
      Collider[] overlappedCollidersForImpulse = Physics.OverlapSphere(transform.position, _radius * 3);

      for (int i = 0; i < overlappedCollidersForDestroing.Length; i++)
      {
        Rigidbody rigidbody = overlappedCollidersForDestroing[i].attachedRigidbody;
        if (rigidbody)
        {
          rigidbody.isKinematic = false;
          StartCoroutine(DestroyCoroutine(overlappedCollidersForDestroing[i]));
        }
      }

      for (int i = 0; i < overlappedCollidersForImpulse.Length; i++)
      {
        Rigidbody rigidbody = overlappedCollidersForImpulse[i].attachedRigidbody;
        if (rigidbody)
        {
          rigidbody.isKinematic = false;
          rigidbody.AddExplosionForce(_force, transform.position, _radius * 3);
        }
      }
    }


    IEnumerator DestroyCoroutine(Collider gameObj)
    {
      yield return new WaitForSeconds(0.1f);
      Destroy(gameObj.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
      if (collider.CompareTag("DestroyedFigure"))
      {
        Explode();
      }
    }

  }
}
