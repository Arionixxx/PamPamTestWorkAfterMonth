using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UsersInteractions
{
  public class ReloadScript : MonoBehaviour
  {
    public void Reload()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
  }
}
