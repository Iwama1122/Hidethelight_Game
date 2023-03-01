using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ClearHome : MonoBehaviour
{
    [SerializeField] private GameObject movie1;
    [SerializeField] private GameObject movie2;
    [SerializeField]
    private GameObject fade;
    VideoPlayer mo;
    [SerializeField] private GameObject _movie1;
    [SerializeField] private AudioSource[] music;
    [SerializeField] private GameObject[] havemusic;
    // Start is called before the first frame update
    void Start()
    {
        
        mo = movie2.GetComponent<VideoPlayer>();
        mo.Stop();
        if(Alicenight._no == true) {
            music[0].mute = false;
            music[1].mute = true;
            havemusic[0].SetActive(true);
            havemusic[1].SetActive(false);
            movie1.SetActive(true);
            _movie1.SetActive(true);
            mo.Stop();
            movie2.SetActive(false);
            fade.SetActive(false);
            Invoke("Hometo", 7.0f);
            Alicenight._no = false;
        } else if(Alicenight._yes == true) {
            music[1].mute = false;
            music[0].mute = true;
            havemusic[0].SetActive(false);
            havemusic[1].SetActive(true);
            fade.SetActive(true);
            movie1.SetActive(false);
            _movie1.SetActive(false);
            mo.Play();
            movie2.SetActive(true);
            Invoke("Hometo", 13.0f);
            Alicenight._yes = false;
        } else {
            music[0].mute = false;
            music[1].mute = true;
            havemusic[0].SetActive(true);
            havemusic[1].SetActive(false);
            movie1.SetActive(true);
            _movie1.SetActive(false);
            mo.Stop();
            fade.SetActive(false);
            movie2.SetActive(false);
            Alicetyutoriaru.gametutorial = false;
            Invoke("Hometo", 7.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Hometo() {
        AliceCursoleStage.stagecount = 0;
        Alicetyutoriaru.nottyutorial = false;
        SceneManager.LoadScene("StageSentaku");
        //mo.Stop();
    }
}
