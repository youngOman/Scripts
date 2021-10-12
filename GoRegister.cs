using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoRegister : MonoBehaviour
{
  public void GotoRegister(){
      SceneManager.LoadScene("register"); //register index=0
  }
}
