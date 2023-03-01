using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Stagebuutton : MonoBehaviour
{
    public static int stagecount = 0;

    VideoPlayer videoPlayer;
    [SerializeField] GameObject mou;
    RawImage moe;
    [SerializeField] GameObject moucopy;
    RawImage mouraw;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("Rabitt").GetComponent<VideoPlayer>();
        mou.SetActive(true);
        videoPlayer.Stop();
        moucopy.SetActive(true);
        mouraw = moucopy.GetComponent<RawImage>();
        moe = mou.GetComponent<RawImage>();
        moe.color = new Color32(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            stagecount = 2;
            //moucopy.SetActive(false);

            mouraw.color = new Color32(255, 255, 255, 0);
            videoPlayer.Play();


            //moe.color = new Color32(255, 255, 255, 255);
            StartCoroutine("Movie");
        }
    }

    public void OnNormal() {
        stagecount = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void OnHard() {
        /*
        stagecount = 2;
        //moucopy.SetActive(false);
        
        mouraw.color = new Color32(255,255,255,0);
        

        videoPlayer.Play();
        //moe.color = new Color32(255, 255, 255, 255);
        StartCoroutine("Movie");
        //mou.SetActive(true);




        //StartCoroutine("Movie");
        //SceneManager.LoadScene("SampleScene");ここは2番目ステージ
        */
    }
        
    public void OnNightmare() {
        stagecount = 3;
        //SceneManager.LoadScene("SampleScene");ここは3番目ステージ
    }

    IEnumerator Movie() {
        
        yield return new WaitForSeconds(0.2f);
        StartCoroutine("Movies");
        
        // moe.color = new Color32(255, 255, 255, 255);
    }
    IEnumerator Movies()
    {
        
        for(byte i = 1; i < 255; i++) { 
        yield return new WaitForSeconds(0.02f);
            
            moe.color = new Color32(255, 255, 255, i);
        }
    }
}
