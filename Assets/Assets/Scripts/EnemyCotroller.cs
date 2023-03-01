using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyCotroller : MonoBehaviour
{
    [SerializeField]
    private GameObject biribiri;
    
    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private  GameObject player;
    [SerializeField] private GameObject eye;
    float time;
    Eye eys;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject tan;
    TanscuController tansu;
   
    Animator ene;

    
    float stoptime;

    [SerializeField] private GameObject co;
    EnemyCollision col;
 

    [SerializeField] private GameObject plg;
    Big bi;
    SwitchCamera sw;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject gai;
    UnlockMap g;
    // Start is called before the first frame update
    void Start()
    {
        icon.SetActive(false);
        g = gai.GetComponent<UnlockMap>();
        biribiri.SetActive(false);
        tansu = tan.GetComponent<TanscuController>();
        ene = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destPoint = Random.Range(0,points.Length);
        eys =  GetComponentInChildren<Eye>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        col = co.GetComponentInChildren<EnemyCollision>();
        
        plg = GameObject.Find("Playermono");
        bi = plg.GetComponent<Big>();
        pl = GameObject.Find("PlayerArmature");
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        sw = GameObject.Find("Switch Area").GetComponent<SwitchCamera>();
        
    }

  

    // Update is called once per frame
    void Update()
    {
        
       
        float y = this.transform.rotation.y;
        float z = this.transform.rotation.z;
        if(th.GAMEOVER == true) {
            transform.rotation = Quaternion.Euler(0, y, z);
            this.gameObject.SetActive(false);
        }
        if(g.TERASU == true) {
            icon.SetActive(true);
            //g.TERASU = false;
        }

        //”’åKåN‚ÉG‚ê‚½Žž
        if(col.WHSTOP == true)
        {
            stoptime += Time.deltaTime;
            ene.SetBool("dash", false);
            transform.DOShakePosition(5.2f,0.0001f);
            biribiri.SetActive(true);
            
            if(stoptime >= 5.0f)
            {
                ene.SetBool("dash", true);
                biribiri.SetActive(false);
                col.WHSTOP = false;
                stoptime = 0;
            }
        }
        
        if (ga.START == true )
        {
            
            if(cas.STOP == true) {
                ene.SetBool("dash", false);
                agent.enabled = false;
                //agent.speed = 0;
            }
            
            if (cas.STOP == false) { 
            if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    //agent.speed = 0;
                    ene.SetBool("dash", false);
                }
            if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    //agent.speed = 1;
                    if(col.WHSTOP == false){
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        ene.SetBool("dash", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                    
                }
                
                if(th.KABE == true){ 
                    
                    eys.EYE = false;
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        ene.SetBool("dash", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if(bi.SM == true) { 
                    
                    eys.EYE = false;
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        ene.SetBool("dash", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if(tansu.STWA == true) {
                    eys.EYE = false;
                    if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                        ene.SetBool("dash", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                
            }
            }
        }
        //–Úü‚ªplayer‚É‚Ó‚ê‚Äplayer‚É‚ð’Ç‚¢‚©‚¯‚é
        if(ga.START == true ) {
          
                if(cas.STOP == false) {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    //agent.speed = 0;
                    ene.SetBool("dash", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    //ene.SetBool("walk",true);
                    //agent.speed = 1;
                    if(col.WHSTOP == false) { 
                        if(eys.EYE == true) {
                        
                        time +=Time.deltaTime;
                        ene.SetBool("walk",true);
            
                         transform.DOLookAt(player.transform.position,6.0f);
                          agent.destination = player.transform.position;
                           agent.speed = 3f;
           
                             if(time >= 6.0f) {
                             eys.EYE = false;
                
                               time = 0;
                             }  
                         }
                    }
                 }

            }
        }
    }

    void GotoNextPoint()
    {
       
        if (points.Length == 0)
        {
            return;
        }
       
        ene.SetBool("walk", false);
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
        
}
