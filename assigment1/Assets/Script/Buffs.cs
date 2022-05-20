using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
  public int amount;
  public bool interacted;

  private void Start() {
    interacted = false;
  }
  private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "ball"){ interacted = true; } //#BUG eğer 2 tane top düzlemin y ekseninde dik gelirse bu flag aynı anda tetiklenir
  }
}
