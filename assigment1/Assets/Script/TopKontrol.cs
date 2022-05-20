using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hem topun dönüşünü kontrol eder hem de top ekleme çıkarma fonksiyonlarını barındırır.
public class TopKontrol : MonoBehaviour
{
  public GameObject topPref;
  public float hiz;
  public DynamicJoystick joystick;
  bool istouched;
  List<GameObject> balls;
  void Start()
  {
    balls = new List<GameObject>();

    addBall(3); //başlangıç topları
  }

  void Update()
  {
    istouched = joystick.backg.activeSelf;
    switch (istouched)
    {
      case true:
        transform.RotateAround(transform.position, Vector3.forward, 0.5f); //Dönme hareketi,
        break;
      case false:
        transform.position += transform.right * hiz * Time.deltaTime;
        break;
    }
  }

  public void addBall(int i)
  {
    for(;i > 0; i--){
      balls.Add(InsBall());
    }
  }
  public void popBall(int i)
  {
    GameObject willDestroyBall;
    for(;i > 0; i--){
      willDestroyBall = balls[balls.Count - 1];
      balls.RemoveAt(balls.Count - 1);
      Destroy(willDestroyBall);
    }
  }
  private GameObject InsBall(){
    GameObject InsBall;
    Vector3 insLocation;
    insLocation = Vector3.zero;

    if(balls.Count == 0){
      insLocation = transform.position;
    }
    if(balls.Count != 0){
      insLocation = balls[balls.Count - 1].transform.position + transform.up * 0.25f;//constant
    }
    InsBall = Instantiate(topPref, insLocation, Quaternion.identity, transform); 
    InsBall.AddComponent<TopSayiDegistir>().tk = this;

    return InsBall;
  }
}
