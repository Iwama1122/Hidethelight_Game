using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Big : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    StarterAssets.ThirdPersonController bg;
    bool bi = false;//大きくなるフラグ
    //大きくなる用の時間
    float time;
    public float BIGTIME {
        set {
            this.time = value;
        }
        get {
            return this.time;
        }
    }
    float times;
    bool sm = false;//小さくなるフラグ
    float stime;
    float stimes;
    bool sestop = false;
    bool efstop = false;
    [SerializeField] private GameObject effect;

    //[SerializeField] private GameObject kakureru;
    //Leefkakureru le;
    [SerializeField] private GameObject _light;
    Light li;

    [SerializeField] private GameObject rou;
    rousokude r;

    AudioSource a;
    [SerializeField] private AudioClip b1;
    [SerializeField] private AudioClip b2;
    [SerializeField] private GameObject ItemCount;
    hyoujisroto hyouji;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject ma;
    GameManager ga;
    public bool BI
    {
        set
        {
            this.bi = value;
        }
        get
        {
            return this.bi;
        }
    }

    public bool SM {
        set {
            this.sm = value;
        }
        get {
            return this.sm;
        }
    }
    int count = 0;
    public int COUNT {
        set {
            this.count = value;
        }
        get {
            return this.count;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hyouji = ItemCount.GetComponent<hyoujisroto>();
        _light = GameObject.Find("rousoku");
        _light.SetActive(false);
        li = _light.GetComponent<Light>();
        effect.SetActive(false);
        player = GameObject.Find("PlayerArmature");
        bg = player.GetComponent<StarterAssets.ThirdPersonController>();
        rou = GameObject.Find("Rousokumanager");
        r = rou.GetComponent<rousokude>();
        a = GetComponent<AudioSource>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(r.LIGHTUP == true) {
            _light.SetActive(true);
            r.LIGHTUP = false;
        }


        //ここはアイテムのキノコを使った時
        //ここにあとでアイテムスロットのカウントで今選択されていたらのフラグを入れる
        if(ga.START == true) {
            if(cas.STOP == false) {
               if(hyouji.COUNT == 0) { 
                    if(Gamepad.current.buttonSouth.wasReleasedThisFrame && bg.KI != 0)
                    {
         
                        a.PlayOneShot(b1);
                      
                        bi = true;
            
                    }
                }
                if(bi == true)
                    {
                    effect.SetActive(true);
                    li.spotAngle = 63.9f;
                    transform.localScale = new Vector3(2f, 2f, 2f);
                    time += Time.deltaTime;
                if(time >= 1) {
                effect.SetActive(false);
                
                }
                if(time >= 10f)
                {
                li.spotAngle = 54.2f;
                bg.KI--;
                a.PlayOneShot(b1);
                effect.SetActive(true);
                transform.localScale = new Vector3(1f, 1f, 1f);
                efstop = true;
                bi = false;
                time = 0;
            }
           
        }
        if(efstop == true) {
            times += Time.deltaTime;
            if(times >= 1) {
                effect.SetActive(false);
                efstop = false;
                times = 0;
            }
        }
        
        //=====================================
        //ここからが隠れる(草)
        if(Gamepad.current.buttonEast.wasPressedThisFrame && bg.KAKURERU == true)
        {
            // count++;
            a.PlayOneShot(b2);
            li.spotAngle = 0f;
            //effect.SetActive(true);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            sm = true;
        }
        if(sm == true) {
            stime += Time.deltaTime;
            if(stime >= 1) {
                
                sm = false;
                stime = 0;
                //effect.Play();
            }
            
        }
        if(bg.HANARERU == true) {//ここに隠れている範囲からはなれたら//bg.HANARERU == true
            li.spotAngle = 54.2f;
            
            transform.localScale = new Vector3(1f, 1f, 1f);
            sestop = true;
            if(sestop == true) {
                stimes += Time.deltaTime;
            }
            if(stimes >= 1) {
                
                bg.HANARERU = false;
                sestop = false;
                stimes = 0;
                count = 0;
            }
        }
       }
            if(cas.STOP == true) {
                effect.SetActive(false);
            }
        }
    }
}
