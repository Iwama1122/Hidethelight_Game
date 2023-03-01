using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatherController : MonoBehaviour
{
    [SerializeField] private Transform player;
    bool atack = false;
    float falsetime;
    float truetime;
    float speed =3.0f;
    [SerializeField]
    private GameObject biribiri;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject _camera;
    CameraController cas;
    [SerializeField] private GameObject _player;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject area;
    SwitchCamera sc;
    bool playerwh = false;
    float whtime;
    [SerializeField] private GameObject tan;
    TanscuController tansu;
    [SerializeField] private GameObject plbody;
    BodyColorChange body;
    BoxCollider box;
  
    // Start is called before the first frame update
    void Start()
    {
       
        box = GetComponent<BoxCollider>();
        body = plbody.GetComponent<BodyColorChange>();
        biribiri.SetActive(false);
        tansu = tan.GetComponent<TanscuController>();
        sc = area.GetComponent<SwitchCamera>();
        th = _player.GetComponent<StarterAssets.ThirdPersonController>();
        cas = _camera.GetComponent<CameraController>();
        ga = ma.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(body.TOUMEI == true) {
            box.enabled = false;
        } else {
            box.enabled = true;
        }
        if(th.GAMEOVER == true) {
            this.gameObject.SetActive(false);
        }
        if(sc.CAMERAMOVE == true) {
            atack = true;
        }
        else {
            atack = false;
        }
        if(th.KAKURERU == true) {
            atack = false;
            transform.position = Vector3.MoveTowards(transform.position, -player.position, speed * Time.deltaTime);
        }
        else {
            atack = true;
            
        }
        if(playerwh == true) {
            biribiri.SetActive(true);
            atack = true;
            whtime += Time.deltaTime;
        }
        if(whtime >= 6.0f) {
            atack = false;
            whtime = 0;
            playerwh = false;
        }
        if(tansu.STWA == true) {
            atack = true;
        }
        else {
            atack = false;
        }
        if(ga.START == true) { 
            if(cas.STOP == false) { 
        
        if(atack == false && th.SEA == true) {
          transform.LookAt(player);
          transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
          falsetime += Time.deltaTime; 
        }
        if(falsetime >= 10.0f) {
            falsetime = 0;
            atack = true;
        }
        if(atack == true) {
            truetime += Time.deltaTime;
            if(truetime >= 6.0f) {
                truetime = 0;
                atack = false;
            }
        }
            }
       }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "flower") {
            playerwh = true;
        }
        
    }
}
