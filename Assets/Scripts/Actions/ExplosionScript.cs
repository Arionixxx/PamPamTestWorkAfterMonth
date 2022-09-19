using System.Collections;
using UnityEngine;
using _Code_Figures;


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
      _rigidbody = GetComponent<Rigidbody>();
    }

    public void Explode()
    {
      Collider[] overlappedCollidersForDestroing = Physics.OverlapSphere(transform.position, _radius);
      Collider[] overlappedCollidersForImpulse = Physics.OverlapSphere(transform.position, _radius * 3);//change method here
      Collider [] overlappedCollidersForArray = Physics.OverlapSphere(transform.position, settings.length);
      foreach (Collider col in overlappedCollidersForArray)
      {
        if (col.CompareTag("DestroyedFigure")){
          Figure.FiguresAfterExplosion.Add(col.gameObject);
        }
      }

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
      AfterDestroyingInstantiation.AfterDestroyingInst?.Invoke();
    }


    IEnumerator DestroyCoroutine(Collider gameObj)
    {
      yield return null;
      _rigidbody.isKinematic = true;
      gameObj.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
      if (collider.CompareTag("DestroyedFigure") && collider.gameObject.GetComponent<Rigidbody>().isKinematic)//delete "isKinematic" for separate figures explosion
      {
        Explode();
      }
    }

  }
}
