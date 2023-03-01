using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Spine.Unity;//spineというソフトに対応させるため

public class AliceCursoleStage : MonoBehaviour
{
    [SerializeField] private GameObject tyu;
    [SerializeField] private GameObject backhaikei;
    bool tyutoriaru = false;
    RectTransform w;
    Image back;
    float speed = 0.05f;//0.00955f
    public static int stagecount = 0;
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject botton1;
    [SerializeField] private GameObject botton2;
    Vector3 bo;//選択1
    Vector3 bo1;//選択2
    Vector3 bo2;//選択3
    Vector3 my;
    Vector3 mycopy;//次のシーンまたはワイプが出される前の押したボタンの位置
    [SerializeField]
    private GameObject myme;
    RawImage myarrow;
    bool osita = false;//押してからアイコンが点滅するから点滅してる間は操作できないようにするフラグ
    //スパインでをunityで再生する為の変数たち
    [SerializeField] private GameObject rabit;
    SkeletonAnimation RskeletonAnimation;
    [SerializeField] private GameObject hat;
    SkeletonAnimation HskeletonAnimation;
    [SerializeField] private GameObject mouse;
    SkeletonAnimation MskeletonAnimation;
    

    bool stagekarten = false;
    public bool STAGEKARTEN {
        set {
            this.stagekarten = value;
        }
        get {
            return this.stagekarten;
        }
    }
    bool tyuto = false;
    public bool TYUTO {
        set {
            this.tyuto = value;
        }
        get {
            return this.tyuto;
        }
    }

    bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理する
    float fadeSpeed = 0.0002f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理
    AudioSource aliceaudio;
    [SerializeField] private AudioClip[] soundmusic;
    // Start is called before the first frame update
    void Start()
    {
        
        aliceaudio = GetComponent<AudioSource>();
        tyu.SetActive(false);
        w = tyu.GetComponent<RectTransform>();
        back = backhaikei.GetComponent<Image>();
        red = back.color.r;
        green = back.color.g;
        blue = back.color.b;
        alfa = back.color.a;
        RskeletonAnimation = rabit.GetComponent<SkeletonAnimation>();
        HskeletonAnimation = hat.GetComponent<SkeletonAnimation>();
        MskeletonAnimation = mouse.GetComponent<SkeletonAnimation>();
        bo = botton.transform.position;
        bo1 = botton1.transform.position;
        bo2 = botton2.transform.position;
        this.transform.position = new Vector3(bo.x-280f, bo.y, 0);
        myarrow = myme.GetComponent<RawImage>();
        myarrow.color = new Color(255, 255, 255, 255);
        RskeletonAnimation.AnimationName = "animation";
        HskeletonAnimation.AnimationName = "animation_none";
        MskeletonAnimation.AnimationName = "animation_none";
    }

    // Update is called once per frame
    void Update()
    {
        
        my = this.transform.position;

        //横バージョン
        if(osita == false) { 
        if(my.x < bo2.x - 280f) {
            if(Gamepad.current.leftStick.right.wasReleasedThisFrame) {
                my.x += 600f;
                transform.position = my;
                
            }
        }
        if(my.x > bo.x) {
            if(Gamepad.current.leftStick.left.wasReleasedThisFrame) {
                my.x -= 600f;
                transform.position = my;
                
            }
        }

        if(my.x == bo.x - 280f) {
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                stagecount = 1;
                RskeletonAnimation.AnimationName = "tea";
                    //stagekarten = true;
                    StartCoroutine("Transparent");
                    StartCoroutine("Tyutoriaru");
                    osita = true;
                    aliceaudio.PlayOneShot(soundmusic[1]);
                }
        }
        if(my.x == 693.51f) {//
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                stagecount = 2;
                MskeletonAnimation.AnimationName = "nenuri_nezumi";
                    stagekarten = true;
                    StartCoroutine("Transparent");
                osita = true;
                    aliceaudio.PlayOneShot(soundmusic[2]);
                    StartCoroutine("Normal");
                }
        }
        if(my.x == 1293.51f) {
            if(Gamepad.current.buttonEast.isPressed) {
                stagecount = 3;
                HskeletonAnimation.AnimationName = "bousiya";
                    stagekarten = true;
                    StartCoroutine("Transparent");
                osita = true;
                    aliceaudio.PlayOneShot(soundmusic[3]);
                    StartCoroutine("Nightmea");
            }
        }

        if(Gamepad.current.buttonSouth.wasReleasedThisFrame) {
                stagekarten = true;
                osita = true;
                aliceaudio.PlayOneShot(soundmusic[0]);
                StartCoroutine("Title");
        }
        }
        if(tyutoriaru == true) {
            isFadeOut = true;
            tyu.SetActive(true);
            if(w.localScale.x <= 3 && w.localScale.y <= 3) {
            tyu.transform.localScale = new Vector3(w.localScale.x + speed, w.localScale.y + speed, 1);
        } else {
                tyutoriaru = false;
                tyuto = true;
        }
        }
        if(isFadeOut) {
            StartFadeOut();
        }
    }
    void StartFadeOut() {
        back.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if(alfa >= 0.5f) {             // d)完全に不透明になったら処理を抜ける
            isFadeOut = false;
        }
    }

    void SetAlpha() {
        back.color = new Color(red, green, blue, alfa);
    }
    IEnumerator Transparent() {

        int co = 5;
        while(co != 0) {
            for(int i = 0; i < 100; i++) {
                myarrow.color = new Color(255, 255, 255, 0);
            }

            yield return new WaitForSeconds(0.1f);

            for(int k = 0; k < 100; k++) {
                myarrow.color = new Color32(255, 255, 255, 255);
            }

            yield return new WaitForSeconds(0.1f);
            co--;
            //mesh.color = mesh.color - new Color32(0, 0, 0, 0);
        }
    }

   
    IEnumerator Normal() {
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadScene("NormalStage");
    }
    IEnumerator Nightmea() {
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadScene("NightmeaScene");
    }
    IEnumerator Title() {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("TitleScene"); ;
    }
    IEnumerator Tyutoriaru() {
        yield return new WaitForSeconds(3.0f);
        tyutoriaru = true;
        
        
    }
}
