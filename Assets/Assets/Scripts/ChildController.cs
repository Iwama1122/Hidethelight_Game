using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class ChildController : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private GameObject eye;
    Childeye eys;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject tan;
    TanscuController tansu;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform players;
    [SerializeField] private Transform seiutch;
    //[SerializeField] private Transform seiutch;
    StarterAssets.ThirdPersonController th;
    Animator child;
    SwitchCamera sw;
    float speed = 1.0f;
    bool stop = false;
    //float time;
    
    // Start is called before the first frame update
    void Start()
    {
        tansu = tan.GetComponent<TanscuController>();
        child = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destPoint = Random.Range(0, points.Length);
        eys = GetComponentInChildren<Childeye>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        th = player.GetComponent<StarterAssets.ThirdPersonController>();
        sw = GameObject.Find("Switch Area").GetComponent<SwitchCamera>();
     
    }

    // Update is called once per frame
    void Update()
    {
       
        float rotex = transform.rotation.x;
        float rotez = transform.rotation.z;
        if(ga.START == true) {

            if(cas.STOP == true) {
             //   child.SetBool("childwalk", false);
                agent.enabled = false;
                //agent.speed = 0;
            }

            if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    //agent.speed = 0;
                 //   child.SetBool("childwalk", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    //agent.speed = 1;
                   if(eys.ALICE == false) {  
                     if(stop == false) { 
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                         //   child.SetBool("childwalk", true);
                            agent.speed = 1;
                            GotoNextPoint();
                    }

                 

                    if(th.KABE == true) {

                        //eys.ALICE = false;
                        if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                     //       child.SetBool("childwalk", true);
                            agent.speed = 1;
                            GotoNextPoint();
                        }
                    }
                    
                    if(tansu.STWA == true) {
                        //eys.ALICE = false;
                        if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                      //      child.SetBool("childwalk", true);
                            agent.speed = 1;
                            GotoNextPoint();
                        }
                    }
                    }
                    }
                }
            }
        }
        //–Úü‚ªplayer‚É‚Ó‚ê‚Äplayer‚É‚ð’Ç‚¢‚©‚¯‚é
        if(ga.START == true) {

            if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    //agent.speed = 0;
                 //   child.SetBool("childwalk", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    //ene.SetBool("walk",true);
                    //agent.speed = 1;
                   if(th.SEA == true) { 
                        if(eys.ALICE == true) {

                            //time += Time.deltaTime
                         //   child.SetBool("childwalk", true);
                        // transform.rotation = Quaternion.Euler(rotex,player.transform.rotation.y,rotez);
                        //transform.position = Vector3.MoveTowards(transform.position, players.position, speed * Time.deltaTime);
                        agent.destination = players.position;
                            stop = true;
                            agent.enabled = true;
                            /*
                                transform.DOLookAt(player.transform.position, 6.0f);
                                agent.destination = player.transform.position;
                            */
                            //agent.speed = 3f;


                        } else {
                            stop = false;
                            agent.enabled = true;
                        }
                        if(eys.SEIUCH == true) {
                            //child.SetBool("childwalk", true);
                            //transform.position = Vector3.MoveTowards(transform.position, seiutch.position, speed * Time.deltaTime);
                            agent.destination = seiutch.position;
                            stop = true;
                            agent.enabled = true;
                        }
                        else {
                            stop = false;
                            agent.enabled = true;
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

        //child.SetBool("childwalk", true);
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
