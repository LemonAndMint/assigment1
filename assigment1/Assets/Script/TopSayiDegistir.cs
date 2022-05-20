using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSayiDegistir : MonoBehaviour
{
  public TopKontrol tk;

  private void OnTriggerEnter(Collider other) {
    GameObject buffObj = other.gameObject;
    Buffs buff = buffObj.GetComponent<Buffs>();
    Debug.Log(buff.interacted);
    if(buff.interacted == false){ //Birden çok topun buffla etkileşime girmesini engelliyoruz
      if(buffObj.tag == "decrease"){
        tk.popBall(buff.GetComponent<Buffs>().amount);
        Destroy(other.gameObject);
      }

      if(buffObj.tag == "increase"){
        tk.addBall(buff.GetComponent<Buffs>().amount);
        Destroy(other.gameObject);
      }
    }
  }
}
