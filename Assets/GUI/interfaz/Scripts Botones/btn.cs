using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn : MonoBehaviour
{
    public  GameObject introduccion;

  public void pulsar(){
    Debug.Log("hola");
    introduccion.SetActive(true);
  }
}
