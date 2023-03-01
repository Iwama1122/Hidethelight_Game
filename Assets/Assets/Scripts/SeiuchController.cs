using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class SeiuchController : MonoBehaviour
{
    Seiucheat setaberu;

    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    [SerializeField] private GameObject eye;
    float time;
    Seiucheye eys;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject ca;
    CameraController cas;
  

    Animator seiuch;

    float closeDist = 10000;
    private GameObject closeTeaset;
    SwitchCamera sw;
    [SerializeField] private GameObject pla;
    StarterAssets.ThirdPersonController p;
    //float sespspeed = 3; 
    bool eattyuu = false;
    float settime;
    Seiucheat seich;
    int childcount;
    [SerializeField] private GameObject plbody;
    BodyColorChange body;
    BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        body = plbody.GetComponent<BodyColorChange>();
        setaberu = GetComponentInChildren<Seiucheat>();
        pla = GameObject.Find("PlayerArmature");
        p = pla.GetComponent<StarterAssets.ThirdPersonController>();
        eys = eye.GetComponentInChildren<Seiucheye>();
        seich = GetComponentInChildren<Seiucheat>();
        seiuch = GetComponent<Animator>();
        
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destPoint = 0;
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        sw = GameObject.Find("Switch Area").GetComponent<SwitchCamera>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(body.TOUMEI == true) {
            box.enabled = false;
            eys.enabled = false;
        } else {
            eys.enabled = true;
            box.enabled = true;
        }

        if(p.GAMEOVER == true) {
            this.gameObject.SetActive(false);
        }
        
       

        
        if(ga.START == true) {
            if(cas.STOP == true) {
                agent.enabled = false;
                seiuch.SetBool("seiuch", false);
    
            }
            if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = true;
                    seiuch.SetBool("seiuch", false);
             
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                 
                    if(p.SEA == false) {
                        if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        seiuch.SetBool("seiuch", true);
                            agent.speed = 1;
                            GotoNextPoint();
                        }
                       }
                }
            }
        }
        
        //追いかける
        if(ga.START == true) {

            if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    seiuch.SetBool("seiuch", false);
                }
                if(sw.CAMERAMOVE == false) {
                   // agent.enabled = true;
                      if(p.SEA == true) {
                        
                        if(agent.speed >= 4) {
                          agent.speed = 3;
                        } else {
                            agent.speed = 1 + setaberu.EATCOUNT / 2;
                        }
                        GameObject[] childs = GameObject.FindGameObjectsWithTag("Child");
                        childcount = childs.Length;
                        if(childcount != 0) {
                            foreach(GameObject target in childs) {
                                float tDist = Vector3.Distance(transform.position, target.transform.position);//アリスとお茶道具の距離計測
                               
                                    closeDist = tDist;
                                    closeTeaset = target;
                               
                            }

                            //transform.position = Vector3.MoveTowards(transform.position, closeTeaset.transform.position, sespspeed * Time.deltaTime);
                        agent.destination = closeTeaset.transform.position;
                        //Vector3 vector3 = closeTeaset.transform.position - this.transform.position;
                        //vector3.y = 0f;
                        eattyuu = true;
                        //Quaternion quaternion = Quaternion.LookRotation(vector3);//回転値取得
                        //transform.rotation = quaternion;
                        }
                        
                        agent.enabled = true;
                        if(eys.CHILDSE == true) {
                        seiuch.SetBool("seiuch", true);
                        agent.enabled = true;
                  
                        if(seich.EAT == true) { 
                            transform.DORotate(
                                  new Vector3(45, 0, 0), 0.1f);// 終了時のRotation// 演出時間
                                 
                          transform.DOScale(
                              new Vector3(0.25f, 0.25f, 0.25f), // スケール値
                                     0.1f                    // 演出時間
                                        );
                        settime += Time.deltaTime;
                        }
                        if(settime >= 0.1f) {
                            seich.EAT = false;
                            eys.CHILDSE = false;
                           transform.DORotate(
                            new Vector3(0, 0, 0), 1f);
                          transform.DOScale(
                             new Vector3(0.3f, 0.3f, 0.3f), // スケール値
                                          1f                    // 演出時間
                                           );
                            settime = 0;
                       }
                       } 
                       
                     
                   }
                      
                        if(eattyuu == false) { 
                    if(eys.SEPLAYER == true) {
                        time += Time.deltaTime;
                        transform.DOLookAt(pla.transform.position, 6.0f);
                    agent.destination = pla.transform.position;
                    agent.speed = 3+ setaberu.EATCOUNT;

                    if(time >= 6.0f) {
                        eys.SEPLAYER = false;

                        time = 0;
                    }
                    }
                }
                   
                }
            }
        }
    }

    void GotoNextPoint() {

        if(points.Length == 0) {
            return;
        }

        seiuch.SetBool("seiuch", true);
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    
}
