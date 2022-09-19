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
  }
  private void OnDisable()
  {
    AfterDestroyingInst -= AfterDestrouingInstF;
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
}
