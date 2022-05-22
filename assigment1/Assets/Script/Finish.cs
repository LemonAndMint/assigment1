using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
  public GameManager gm;
  private void OnTriggerEnter(Collider other) {
    
    if(other.gameObject.tag == "ball"){
      gm.win();
    }
  }
}
