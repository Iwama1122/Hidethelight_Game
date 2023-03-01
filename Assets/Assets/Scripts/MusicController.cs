using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource[] music;
    [SerializeField] private GameObject[] havemusic;
    public static MusicController instance;
    // Start is called before the first frame update
    void Awake()
    {
        
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
       var scene = SceneManager.GetActiveScene();
        if(scene.name == "TitleScene") {
            havemusic[0].SetActive(true);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
           // havemusic[3].SetActive(false);
            music[0].mute = false;
            music[1].mute = true;
            music[2].mute = true;
           // music[3].mute = true;
        }
        if(scene.name == "StageSentaku") {
            havemusic[0].SetActive(true);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
            //havemusic[3].SetActive(false);
            music[0].mute = false;
            music[1].mute = true;
            music[2].mute = true;
            //music[3].mute = true;
        }

        if(scene.name == "SousaScene") {
           
            havemusic[0].SetActive(true);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
            //havemusic[3].SetActive(false);
            music[0].mute = false;
            music[1].mute = true;
            music[2].mute = true;
            
            //music[3].mute = true;
        } 
        if(scene.name == "SampleScene") {
            havemusic[0].SetActive(false);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
            //havemusic[3].SetActive(false);
            music[0].mute = true;
            music[1].mute = true;
            music[2].mute = true;
            //music[3].mute = true;
        }
        if(scene.name == "NormalStage") {
            havemusic[0].SetActive(false);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
            //havemusic[3].SetActive(false);
            music[0].mute = true;
            music[1].mute = true;
            music[2].mute = true;
            //music[3].mute = true;
        }
        if(scene.name == "NightmeaScene") {
            havemusic[0].SetActive(false);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
            //havemusic[3].SetActive(false);
            music[0].mute = true;
            music[1].mute = true;
            music[2].mute = true;
            //music[3].mute = true;
        }
        if(scene.name == "TyutorialScene") {
            havemusic[0].SetActive(false);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(false);
            //havemusic[3].SetActive(false);
            music[0].mute = true;
            music[1].mute = true;
            music[2].mute = true;
            //music[3].mute = true;
        }
        if(scene.name == "GameOver") {
            havemusic[0].SetActive(false);
            havemusic[1].SetActive(false);
            havemusic[2].SetActive(true);
            //havemusic[3].SetActive(false);
            music[0].mute = true;
            music[1].mute = true;
            music[2].mute = false;
            //music[3].mute = true;
        }
      
    }

    
}
