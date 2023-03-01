using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Cursoleidou : MonoBehaviour
{
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject botton1;
    [SerializeField] private GameObject botton2;
    [SerializeField] private GameObject line;
    [SerializeField] private GameObject linemini;
    Vector3 bo;//選択1
    Vector3 bo1;//選択2
    Vector3 bo2;//選択3
    Vector3 my;
    Vector3 mycopy;//次のシーンまたはワイプが出される前の押したボタンの位置
    //bool moidou = false;
    [SerializeField]
    private GameObject myme;
    RawImage myarrow;
    bool osita = false;
    bool finish = false;
    bool titleidou = false;
    public bool TITLE {
        set {
            this.titleidou = false;
        }
        get {
            return this.titleidou;
        }
    }
    AudioSource alicetitle;
   [SerializeField] private AudioClip alicemusic;
   [SerializeField] private GameObject titlmanager;
    TitleManager timane;
    
    // Start is called before the first frame update
    void Start()
    {
        timane = titlmanager.GetComponent<TitleManager>();
        alicetitle = GetComponent<AudioSource>();
       line.SetActive(true);
        linemini.SetActive(false);
        bo = botton.transform.position;
        bo1 = botton1.transform.position;
        bo2 = botton2.transform.position;
        this.transform.position = new Vector3(bo.x - 350f, bo.y, 0);
        myarrow = myme.GetComponent<RawImage>();
        myarrow.color = new Color32(255, 255,255, 255);
    }

    // Update is called once per frame
    void Update()
    {
       
        Cursor.visible = false;
        my = this.transform.position;
        if(osita == false && finish == false) { 
            if(my.y == bo.y) {
                if(Gamepad.current.leftStick.down.wasReleasedThisFrame)
                {//Gamepad.current.dpad.down.wasReleasedThisFrame
                     mycopy = my;
                     my.y -= 197.0f;
                     transform.position = my;
                    line.SetActive(true);
                    linemini.SetActive(false);
                }
             }
            if(my.y < bo.y) {
                if(Gamepad.current.leftStick.up.wasReleasedThisFrame)
                {//Gamepad.current.dpad.up.wasReleasedThisFrame
                     mycopy = my;
                     my.y += 197.0f;
                     transform.position = my;
                    line.SetActive(true);
                    linemini.SetActive(false);
                }
        }
        }
       
        
        if(Gamepad.current.leftStick.left.wasPressedThisFrame) {
                line.SetActive(false);
                linemini.SetActive(true);
                my.x = bo2.x-200f;
                my.y = bo2.y - 2f;
                transform.position = my;
                finish = true;
             
            
        }
        if(Gamepad.current.leftStick.right.wasPressedThisFrame) {
            my.x = bo.x - 350f;
            my.y = bo.y;

            transform.position = my;
            finish = false;
            line.SetActive(true);
            linemini.SetActive(false);

        }


        if(my.y == bo.y) {
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                    timane.TITLEMANAGER = true;
                timane.MOVIEPLAY = false;
                timane.DEMOFLAG = false;
                    StartCoroutine("Transparent");
                    osita = true;
                    titleidou = true;
                    alicetitle.PlayOneShot(alicemusic);
                    StartCoroutine("Stage");
                 }
             }
             if(my.y == bo1.y) {
                if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                timane.TITLEMANAGER = true;
                timane.MOVIEPLAY = false;
                timane.DEMOFLAG = false;
                titleidou = true;
                    StartCoroutine("Transparent");
                osita = true;
                alicetitle.PlayOneShot(alicemusic);
                StartCoroutine("Sousa");
                }
             }
             if(my.x == bo2.x - 200f && my.y == bo2.y - 2f) {
                if(Gamepad.current.buttonEast.isPressed) {
                    //StartCoroutine("Transparent");
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
                }
            }
             
        
    }
    IEnumerator Transparent() {

        int co = 5;
        while(co != 0) {
            for(int i = 0; i < 100; i++) {
                myarrow.color = new Color32(255, 255, 255, 0);
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
    IEnumerator Stage() {
        yield return new WaitForSeconds(4.0f);
        timane.TITLEMANAGER = false;
        SceneManager.LoadScene("StageSentaku");
    }
    IEnumerator Sousa() {
        yield return new WaitForSeconds(4.0f);
        timane.TITLEMANAGER = false;
        SceneManager.LoadScene("SousaScene");
    }
}
