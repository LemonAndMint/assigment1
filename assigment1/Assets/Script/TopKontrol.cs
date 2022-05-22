using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hem topun dönüşünü kontrol eder hem de top ekleme çıkarma fonksiyonlarını barındırır.
public class TopKontrol : MonoBehaviour
{
  public float hiz;
  public GameObject topPref;
  public DynamicJoystick joystick;
  public GameManager gm;
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
        transform.RotateAround(transform.position, Vector3.forward, 0.75f);
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
  public void popBall(int i, Vector3 colliderPosition)
  {
    GameObject willDestroyBall;
    for(;i > 0; i--){
      willDestroyBall = balls[balls.Count - 1];
      balls.RemoveAt(balls.Count - 1);
     
      willDestroyBall.GetComponent<SphereCollider>().enabled = false;//düşen topların birbiriyle etkileşime geçmemesi için

      willDestroyBall.transform.SetParent(null); //topun kendisini mevcut toplardan çıkarma
      willDestroyBall.transform.GetChild(0).SetParent(null); //Trailin kanvasta kalması için gerekli kod
      
      willDestroyBall.GetComponent<Rigidbody>().useGravity = true;
      willDestroyBall.GetComponent<Rigidbody>().AddForce(-colliderPosition * 10f * Random.Range(0f, 2f) +
                                                          willDestroyBall.transform.forward * 2f * Random.Range(0f, 2f) /* TODO */);
      
      willDestroyBall.transform.GetChild(1).GetComponent<Animator>().SetBool("destroyed", true); //GFX'teki animasyonu çalıştırır

      willDestroyBall.transform.GetChild(0).GetComponent<ParticleSystem>().Play(); //Particle system çalıştırma
      willDestroyBall.transform.GetChild(0).SetParent(null); 
      
      Destroy(willDestroyBall, 1.5f);
      loseCondition();
    }
  }
  private void loseCondition(){
    if(balls.Count <= 1){
      gm.lose();
    }
  }
  private GameObject InsBall(){
    GameObject InsBall;
    Vector3 insLocation;
    Color ballColor;
    Gradient trailGradient;
    TopSayiDegistir temp;

    //DEFAULT ASSIGMENTS
    GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
    GradientColorKey[] colorKey = new GradientColorKey[1];
    alphaKey[0].alpha = 1.0f;
    alphaKey[0].time = 0.0f;
    alphaKey[1].alpha = 1.0f;
    alphaKey[1].time = 1.0f;

    ballColor = Color.white; 
    insLocation = Vector3.zero;
    //DEFAULT ASSIGMENTS

    if(balls.Count == 0){
      insLocation = transform.position;
      ballColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    if(balls.Count != 0){
      insLocation = balls[balls.Count - 1].transform.position + transform.up * 0.25f;//constant
      ballColor = balls[balls.Count - 1].transform.GetChild(2).GetComponent<Renderer>().material.color
                  + new Color(0f, 30f/255f, 10f/225f); //Renk ayarlamaları
    }

    colorKey[0] = new GradientColorKey(ballColor, 0f); 
    trailGradient = new Gradient();
    trailGradient.SetKeys(colorKey, alphaKey);
   
    InsBall = Instantiate(topPref, insLocation, Quaternion.identity, transform); 
    
    InsBall.transform.GetChild(2).GetComponent<Renderer>().material.color = ballColor; //GFX renk ayarlaması
    InsBall.transform.GetChild(0).GetComponent<TrailRenderer>().colorGradient = trailGradient; //Trail renk ayarlaması
    InsBall.transform.GetChild(1).GetComponent<ParticleSystem>().startColor = ballColor; //Particle renk ayarlaması

    temp = InsBall.AddComponent<TopSayiDegistir>();
    temp.tk = this;
    temp.gm = gm;

    return InsBall;
  }
}
