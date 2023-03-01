using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject titlealice;
    Cursoleidou cualice;
    [SerializeField] private GameObject titlefade;
    Titlefade ti;
    [SerializeField] private GameObject titlemovie;
    [SerializeField] private GameObject demomovie;
    VideoPlayer demo;
    RawImage demoimage;
    [SerializeField] private GameObject titlemusic;
    float titletime;
    bool title = false;
    public bool TITLEMANAGER {
        set {
            this.title = value;
        }
        get {
            return this.title;
        }
    }
    [SerializeField] private GameObject sousa;
    float demotime;
    bool demoflag = false;
    public bool DEMOFLAG {
        set {
            this.demoflag = value;
        }
        get {
            return this.demoflag;
        }
    }
    public bool MOVIEPLAY {
        set {
            this.movieplay = value;
        }
        get {
            return this.movieplay;
        }
    }
    bool movieplay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        demo = demomovie.GetComponent<VideoPlayer>();
        demoimage = demo.GetComponent<RawImage>();
        demoimage.enabled = false;


        demo.frame = 0;
        demo.Stop();
        titlemusic = GameObject.Find("MusicManager");
        titlemusic.SetActive(true);
        ti = titlefade.GetComponent<Titlefade>();
        titlemovie.SetActive(true);
        demomovie.SetActive(false);
       sousa.SetActive(false);
        cualice = titlealice.GetComponent<Cursoleidou>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(title == false) { 
            titletime += Time.deltaTime;
                if(titletime >= 15) {
                    
                StartCoroutine("WaitTitle");
                     StartCoroutine("Sousa");
                 
                
              
                demomovie.SetActive(true);
                demo.Play();

                StartCoroutine("WaitDemo");
                title = true;
                demoflag = true;
                movieplay = true;
                     cualice.enabled = false;
                titlemusic.SetActive(false);
                titletime = 0 ;
                }
        }
        if(demoflag == true) {
            demotime += Time.deltaTime;
            if(demotime >= 58f) {
                sousa.SetActive(false);
            }
            if(demotime >= 59f) {
                demotime = 0;


                ti.FADEOUT = true;
                StartCoroutine("TitleMovies");

               
                demoflag = false;
;            }
        }



        if(Gamepad.current.buttonSouth.wasReleasedThisFrame && movieplay == true) {
        //if(Input.GetKeyDown(KeyCode.A)) { 
            demo.Stop();
            demo.frame = 0;
            sousa.SetActive(false);
            demoflag = false;
            demotime = 0;
            title = true;
            titletime = 0;
            ti.FADEOUT = true;
            movieplay = false;
            StartCoroutine("TitleMovie");
            titlemovie.SetActive(true);
           

        }
    }

    IEnumerator TitleMovie() {
        yield return new WaitForSeconds(4.0f);
        demoimage.enabled = false;
        demomovie.SetActive(false);
        titlemusic.SetActive(true);
        //titlemovie.SetActive(true);
        StartCoroutine("TitleLook");
    }
    IEnumerator TitleMovies() {
        yield return new WaitForSeconds(4.0f);
        demo.Stop();
        demo.frame = 0;
        demoimage.enabled = false;
        demomovie.SetActive(false);
        titlemusic.SetActive(true);
        titlemovie.SetActive(true);
        StartCoroutine("TitleLook");
    }
    IEnumerator TitleLook() {
        yield return new WaitForSeconds(0.1f);
        cualice.enabled = true;
       
        StartCoroutine("TitleFlag");
    }
  
    IEnumerator TitleFlag() {
        yield return new WaitForSeconds(2.0f);
        title = false;
    }
    IEnumerator Sousa() {
        yield return new WaitForSeconds(1.5f);
        sousa.SetActive(true);
    }
    IEnumerator WaitTitle() {
        yield return new WaitForSeconds(1.5f);
        titlemovie.SetActive(false);
    }
    IEnumerator WaitDemo() {
        yield return new WaitForSeconds(0.2f);
        demoimage.enabled = true;
    }
}
