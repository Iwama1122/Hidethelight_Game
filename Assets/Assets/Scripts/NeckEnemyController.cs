using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class NeckEnemyController : MonoBehaviour
{
    [SerializeField] private GameObject pla;
    StarterAssets.ThirdPersonController p;

    [SerializeField]
    private GameObject biribiri;

    [SerializeField] private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    [SerializeField] private GameObject eye;
    float time;
    Eye eys;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject ca;
    CameraController cas;

    Animator neck;
    [SerializeField] private GameObject player;

    bool stop = false;
    float stoptime;
    [SerializeField] private GameObject plg;
    Big bi;


    [SerializeField] private GameObject tan;
    TanscuController tansu;
    SwitchCamera sw;
    int random;
    bool kakuritu = false;
    [SerializeField] private GameObject plbody;
    BodyColorChange body;
    BoxCollider box;
    
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        
        body = plbody.GetComponent<BodyColorChange>();
        pla= GameObject.Find("PlayerArmature");
        p = pla.GetComponent<StarterAssets.ThirdPersonController>();
        biribiri.SetActive(false);
        neck = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        destPoint = 0;//Random.Range(0, points.Length);
        eys = GetComponentInChildren<Eye>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        tansu = tan.GetComponent<TanscuController>();
        plg = GameObject.Find("Playermono");
        bi = plg.GetComponent<Big>();
        sw = GameObject.Find("Switch Area").GetComponent<SwitchCamera>();
    }

    //Šî–{“I‚É‚Í‰~‚ð•`‚­‚æ‚¤‚Éœpœj
    //’i·ƒLƒmƒR‚Ü‚½‚Íplayer‚ª‘å‚«‚­‚È‚Á‚½‚ç’Ç‚¢‚©‚¯‚é‚ÌƒLƒƒƒ“ƒZƒ‹‚µ‚Äœpœj
    // Update is called once per frame
    void Update()
    {
        if(body.TOUMEI == true) {
            eys.enabled = false;
            box.enabled = false;
        }
        else {
            eys.enabled = true;
            box.enabled = true;
        }
        if(p.GAMEOVER == true) {
            this.gameObject.SetActive(false);
        }
       
        //”’åKåN‚ÉG‚ê‚½Žž
        if (stop == true)
        {
            stoptime += Time.deltaTime;
            neck.SetBool("neck", false);
            transform.DOShakePosition(5.2f, 0.0001f);
            biribiri.SetActive(true);

            if (stoptime >= 5.0f)
            {
                neck.SetBool("neck", true);
                biribiri.SetActive(false);
                stop = false;
                stoptime = 0;
            }
        }
        


        if (ga.START == true)
        {
            if(cas.STOP == true) {
                agent.enabled = false;
                neck.SetBool("neck", false);
            }
            if (cas.STOP == false)
            {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    neck.SetBool("neck", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                if (stop == false)
                {
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    {
                        neck.SetBool("neck", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }

                }
                
                if (p.KABE == true)
                {

                    eys.EYE = false;
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    {
                        //neck.SetBool("neck", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if (p.MASH == true)
                {

                    eys.EYE = false;
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    {
                        //neck.SetBool("neck", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if (tansu.STWA == true)
                {
                    eys.EYE = false;
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    {
                        //neck.SetBool("neck", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if(bi.BI == true)//‚±‚±‚É‘å‚«‚­‚È‚Á‚½‚Æ‚«‚à’Êíœpœj
                {
                    eys.EYE = false;
                    if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    {
                        //neck.SetBool("neck", true);
                        agent.speed = 1;
                        GotoNextPoint();
                    }
                }
                if(bi.SM == true) {
                        eys.EYE = false;
                        if(!agent.pathPending && agent.remainingDistance < 0.5f) {
                            //neck.SetBool("neck", true);
                            agent.speed = 1;
                            GotoNextPoint();
                        }
                    }
                }
            }
        }

        //–Úü‚ªplayer‚É‚Ó‚ê‚Äplayer‚É‚ð’Ç‚¢‚©‚¯‚é
        if (ga.START == true)
        {
           
            if (cas.STOP == false)
            {
                if(sw.CAMERAMOVE == true) {
                    agent.enabled = false;
                    neck.SetBool("neck", false);
                }
                if(sw.CAMERAMOVE == false) {
                    agent.enabled = true;
                    if (stop == false)
                {
                    if (eys.EYE == true)
                    {

                        time += Time.deltaTime;
                            neck.SetBool("neck", true);

                        transform.DOLookAt(player.transform.position, 6.0f);
                        agent.destination = player.transform.position;
                        agent.speed = 10;

                        if (time >= 6.0f)
                        {
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

        neck.SetBool("neck", true);
        if(kakuritu == false) { 
            agent.destination = points[destPoint].position;
            destPoint++;//(destPoint + 1) % points.Length;
                        //if(destPoint == 4) {
                        //destPoint = 0;
                        //}
        }
        if(destPoint == 4) {
            random = Random.Range(1, 101);
        
        
        if(random >= 70) {
            kakuritu = true;
            
        } else {
            destPoint = 0;
        }
        }
        if(kakuritu == true) {
            //destPoint = 3;
            agent.destination = points[destPoint].position;
            destPoint++;
            
        }
        if(destPoint == 7) {
            kakuritu = false;
            destPoint = 0;
        }

    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "White")
        {
            stop = true;
        }
    }

    
}
