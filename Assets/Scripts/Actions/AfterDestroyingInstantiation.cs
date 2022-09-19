using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Code_Figures;
using UnityEngine.Events;

public class AfterDestroyingInstantiation : MonoBehaviour
{
  [SerializeField] FigureSettings settings;
  public static UnityAction AfterDestroyingInst;

  private void OnEnable()
  {
    AfterDestroyingInst += AfterDestrouingInstF;
    AfterDestroyingInst += MakeExplodedObjectsInactive;
  }
  private void OnDisable()
  {
    AfterDestroyingInst -= AfterDestrouingInstF;
    AfterDestroyingInst -= MakeExplodedObjectsInactive;
  }
  public void AfterDestrouingInstF()
  {
    StartCoroutine(InstantiationCorutine());
  }
  IEnumerator InstantiationCorutine()
  {
    yield return new WaitForSeconds(settings.rebuildingTime);
    Figure.FigureDestroyingAction?.Invoke();
  }

  public void MakeExplodedObjectsInactive()
  {
    StartCoroutine(MakeExplodedObjectsInactiveCorutine());
  }

  IEnumerator MakeExplodedObjectsInactiveCorutine()
  {
    yield return new WaitForSeconds(3);//change it, will be taken from settings
    foreach (GameObject go in Figure.FiguresAfterExplosion)
    {
      if (go.activeInHierarchy)
      {
        go.SetActive(false);
      }
    }
  }
}
