using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameKarten : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] private GameObject alice;
    Alicepoose cu;
    bool DontDestroyEnabled = true;
    [SerializeField] private GameObject ka;
    RawImage kar;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject goal;
    GoalController go;
    AudioSource gamemusic;
    [SerializeField] private AudioClip sound;
    [SerializeField] private GameObject nighticon;
    Alicenight al;
    [SerializeField] private GameObject cameras;
    CameraController cas;
    Animator planim;
    // Start is called before the first frame update
    void Start()
    {
        planim = pl.GetComponent<Animator>();
        cas = cameras.GetComponent<CameraController>();
        al = nighticon.GetComponent<Alicenight>();
        gamemusic = GetComponent<AudioSource>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        go = goal.GetComponent<GoalController>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255, 255, 255, 0);
        if(DontDestroyEnabled) {
            DontDestroyOnLoad(this.gameObject);
        }
        cu = alice.GetComponent<Alicepoose>();
        video = GetComponentInChildren<VideoPlayer>();
        video.Stop();
    }

    // Update is called once per frame
    void Update()
    {
     


        if(cu.RETURNTITLE == true) {
            StartCoroutine("Karten");
            cu.RETURNTITLE = false;
        }
        if(th.GAMEOVERS == true) {
            StartCoroutine("Karten");
            th.GAMEOVERS = false;
        }
        if(go.GOAL == true) {
            StartCoroutine("Kartens");
            go.GOAL = false;
        }
        if(al.NO == true) {
            StartCoroutine("Kartens");
            StartCoroutine("GameClear");
            al.NO = false;
        }
    }

    IEnumerator Karten() {
        yield return new WaitForSeconds(1.5f);
        gamemusic.PlayOneShot(sound);
        kar.color = new Color32(255, 255, 255, 255);
        video.Play();
        StartCoroutine("Desto");
    }
    IEnumerator Kartens() {
        gamemusic.PlayOneShot(sound);
        yield return new WaitForSeconds(0.1f);
        kar.color = new Color32(255, 255, 255, 255);
        video.Play();
        StartCoroutine("Desto");
    }
    IEnumerator Desto() {
        yield return new WaitForSeconds(3.5f);
        //video.Stop();
        DontDestroyEnabled = false;

        Destroy(this.gameObject);
    }


    IEnumerator GameClear() {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GameClear");
    }
    IEnumerator Returntitle()
    {
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("TitleScene");
    }
}
