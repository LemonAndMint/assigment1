using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sayi : MonoBehaviour
{
  public Buffs buff;
  private void Start() {
    GetComponent<Text>().text = buff.amount.ToString();
  }
}
