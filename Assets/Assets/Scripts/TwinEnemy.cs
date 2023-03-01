using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TwinEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject biribiri;
    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject tan;
    TanscuController tansu;

    Animator twin;
    [SerializeField] private GameObject eye;
    float time;
    Eye eys;
    [SerializeField] private GameObject ma;
    GameManager ga;
    float stoptime;
    SwitchCamera sw;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    bool stop = false;
    bool hutago = false;
    public bool HUTAGO {
        set {
            this.hutago = value;
        }
        get {
            return this.hutago;
        }
    }
    [SerializeField] private GameObject plbody;
    BodyColorChange body;
    BoxCollider box;
    [SerializeField] private GameObject bi;
    Big big;
    // Start is called before the first frame update
    void Start()
    {
        big = bi.GetComponent<Big>();
        box = GetComponent<BoxCollider>();
        body = plbody.GetComponent<BodyColorChange>();
        biribiri.SetActive(false);
        tansu = tan.GetComponent<TanscuController>();
        twin = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destPoint = 0;
        eys = GetComponentInChildren<Eye>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        pl = GameObject.Find("PlayerArmature");
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
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
        //”’åKåN‚ÉG‚ê‚½Žž
        if(stop == true) {
            stoptime += Time.deltaTime;
            twin.SetBool("Twin", false);
            transform.DOShakePosition(5.2f, 0.0001f);
            biribiri.SetActive(true);

            if(stoptime >= 5.0f) {
                twin.SetBool("Twin", true);
                biribiri.SetActive(false);
                stop = false;
                stoptime = 0;
            }
        }




        if(ga.START == true) {
            if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    twin.SetBool("Twin", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    if(stop == false) {
                        if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                            twin.SetBool("Twin", true);
                            agent.speed = 1;
                            GotoNextPoint();
                        }

                    }
                 }
                if(tansu.STWA == true) {
                    agent.enabled = true;
                    eys.EYE = false;
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        twin.SetBool("Twin", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if(big.SM == true) {
                    agent.enabled = true;
                    eys.EYE = false;
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        twin.SetBool("Twin", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
            }
            
        }
        if(ga.START == true) {

            if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    twin.SetBool("Twin", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    if(stop == false) {
                        if(eys.EYE == true) {
                            
                            time += Time.deltaTime;
                            twin.SetBool("Twin", false);
                            agent.speed = 0;
                            hutago = true;
                            //transform.DOLookAt(pl.transform.position, 6.0f);
                            //agent.destination = pl.transform.position;
                            //agent.speed = 3f;

                            if(time >= 4.0f) {
                                twin.SetBool("Twin", true);
                                eys.EYE = false;
                                agent.speed = 1;
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
        twin.SetBool("Twin", true);
        agent.destination = points[destPoint].position;
        destPoint++;
        if(destPoint == 4) {
            destPoint = 0;
        }
    }
    public void OnTriggerEnter(Collider col) {
        if(col.tag == "White") {
            stop = true;
        }
    }
}
