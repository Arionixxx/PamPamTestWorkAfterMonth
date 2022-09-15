using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
  public class ExplosionScript : MonoBehaviour
  {
    [SerializeField] private FigureSettings settings;
    [SerializeField] private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    public float _radius;
    public float _force;

    private void Start()
    {
      _radius = settings.bulletExplosionRadius;
      _force = settings.bulletDamageForce;
    }

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
      yield return new WaitForSeconds(0.005f);
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
