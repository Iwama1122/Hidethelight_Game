using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private GameObject re;//赤の女王のリクエストのUIを入れる
    int random;
    private float countdown = 5.0f;
    private float counts;
    [SerializeField] private Text CountText;
    private bool startgame = false;
    [SerializeField]
    private Text TimerText;

    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField]
    private Text yuke;
    float time = 5f;
    float timer;

    [SerializeField]
    private GameObject ple;
    StarterAssets.ThirdPersonController pl;

    
    [SerializeField]
    private GameObject kabe;

    [SerializeField] private AudioClip[] yure;
    AudioSource au;
  
    //bool complete = false;

    public bool START
    {
        set
        {
            this.startgame = value;
        }
        get
        {
            return this.startgame;
        }
        
        
    }

    public float TIME {
        set {
            this.time = value;
        }
        get {
            return this.time;
        }
    }
    bool timerflag = false;
    bool timerflags = false;
    bool timerflagd = false;
    [SerializeField]
    private GameObject finishText;
    Text FinishText;
    [SerializeField]
    private GameObject finishcountText;
    Text FinishCountText;
    float finishtimer = 5.0f;
    float activefinish;
    int samecount = 4;
    // Start is called before the first frame update
    void Start()
    {
        FinishCountText = finishcountText.GetComponent<Text>();
        FinishText = finishText.GetComponent<Text>();
        yuke.text = " ";
        au = GetComponent<AudioSource>();
        kabe.SetActive(false);
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        ple = GameObject.Find("PlayerArmature");
        pl = ple.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Alicetyutoriaru.gametutorial == true)
        {
            if (pl.SYUGAR == 6)
            {//ここはお茶会道具の個数) {
             //complete = true;

                kabe.SetActive(false);
                au.PlayOneShot(yure[0]);
                //yuke.text = "森の抜け道を目指せ!!";
                //pl.SYUGAR = 0;
            }
        }
        

        if(Alicetyutoriaru.gametutorial == false) {
          
            if(pl.SYUGAR == 6) {//ここはお茶会道具の個数) {
                                //complete = true;

                kabe.SetActive(false);
                au.PlayOneShot(yure[0]);
                
                //pl.SYUGAR = 0;
            }  
            if(pl.ITEM == false) {
                yuke.text = "お茶会道具を集めてくれ!!";
            } else {
                yuke.text = "森の抜け道を目指せ!!";
            }
           if(cas.STOP == false) { 
               if(countdown >= 0)
               {
                  timer = (int)time;
                  TimerText.text = timer.ToString();
                  countdown -= Time.deltaTime;
                  counts = (int)countdown;
                  CountText.text = counts.ToString();
         
                }
           
                if(countdown <= 0)
                {
                startgame = true;
                CountText.text = " ";
                if(cas.STOP == false) { 
                time -= Time.deltaTime / 60;
                timer = (int)time;
                    if(time >= 0) { 
                    TimerText.text = timer.ToString();
                    }
                        if(!timerflag) { 
                        if(time <= 4.0f) {
                            
                            timerflag = true;
                                FinishCountText.text = "残り3分";
                            StartCoroutine("Kesu");
                        } 
                        }
                        if(!timerflags) { 
                        if(time <= 3.0f) {
                            timerflags = true;
                                FinishCountText.text = "残り2分";
                                StartCoroutine("Kesus");
                            } 
                        }
                    if(!timerflagd) { 
                        if(time <= 2.0f) {
                            timerflagd = true;
                                FinishCountText.text = "残り1分";
                            StartCoroutine("Kesud");

                        }
                    }
                     
                        if(time <= 1.06f) {
                                finishtimer-=Time.deltaTime;
                                activefinish = (int)finishtimer;
                                if(activefinish == samecount) {
                                samecount--;
                                au.PlayOneShot(yure[1]);
                            }
                                if(finishtimer <= 0.99f) {
                                    FinishText.text = " ";
                                    finishtimer = 0;
                                } else {
                                    FinishText.text = activefinish.ToString();
                                }

                            }
                         
                    }

                }
            }
        }
    }

    IEnumerator Kesu() {
        yield return new WaitForSeconds(3.0f);
        FinishCountText.text = " ";
        //timerflag = false;
    }
    IEnumerator Kesus() {
        
        yield return new WaitForSeconds(3.0f);
        FinishCountText.text = " ";
        ///timerflags = false;
    }
    IEnumerator Kesud() {
        
        yield return new WaitForSeconds(3.0f);
        FinishCountText.text = " ";
        //timerflagd = false;
    }
}
