using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSayiDegistir : MonoBehaviour
{
  public TopKontrol tk;

  private void OnTriggerEnter(Collider other) {
    
    if(other.gameObject.tag == "decrease"){
      tk.popBall(this.gameObject);
      Destroy(other.gameObject);
    }

    if(other.gameObject.tag == "increase"){
      tk.addBall();
      Destroy(other.gameObject);
    }
  }
}
