using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSayiDegistir : MonoBehaviour
{
  public TopKontrol tk;
  public GameManager gm;

  private void OnTriggerEnter(Collider other) {
    GameObject buffObj = other.gameObject;
    Buffs buff = buffObj.GetComponent<Buffs>();

     if(buffObj.tag == "finish"){
         gm.win();
        return;
      }
   
    if(buff.interacted == false){ //Birden çok topun buffla etkileşime girmesini engelliyoruz
      if(buffObj.tag == "decrease"){
        tk.popBall(buff.GetComponent<Buffs>().amount, buffObj.transform.position);
        buffObj.GetComponent<Animator>().SetBool("destroyed", true);
        Destroy(other.gameObject, 0.5f);
      }

      if(buffObj.tag == "obstacle"){
        tk.popBall(buff.GetComponent<Buffs>().amount, buffObj.transform.position);
      }

      if(buffObj.tag == "increase"){
        tk.addBall(buff.GetComponent<Buffs>().amount);
        buffObj.GetComponent<Animator>().SetBool("destroyed", true);
        Destroy(other.gameObject, 0.5f);
      }
    }
  }
}
