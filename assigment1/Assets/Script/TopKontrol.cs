using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
  public GameObject topPref;
  public float hiz;
  List<GameObject> balls;
  void Start()
  {
    balls = new List<GameObject>();

    addBall();
    addBall();
    addBall();
    addBall();
    addBall();

  }

  void Update()
  {
    transform.position += Vector3.right * hiz * Time.deltaTime;  
    transform.RotateAround(transform.position, Vector3.forward, 1f); //Dönme hareketi
  }

  public void addBall()
  {
    balls.Add(InsBall());
  }
  public void popBall(GameObject ball)
  {
    int ballIndex;
    ballIndex = balls.IndexOf(ball);
    balls.RemoveRange(ballIndex, balls.Count - (1 + ballIndex));
    Debug.Log(ballIndex);
  }
  GameObject InsBall(){
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
