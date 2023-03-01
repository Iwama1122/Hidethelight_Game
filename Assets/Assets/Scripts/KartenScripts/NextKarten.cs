using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class NextKarten : MonoBehaviour
{
    
    
   [SerializeField] private GameObject ka;
    VideoPlayer video;
    RawImage kar;
    AudioSource reqestmusic;
    [SerializeField] private AudioClip sound;
    bool DontDestroyEnabled = true;
    int recount = 0;
    public int RECOUNT
    {
        set
        {
            this.recount = value;
        }
        get
        {
            return this.recount;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        reqestmusic = GetComponent<AudioSource>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255, 255, 255, 0);
        video = ka.GetComponent<VideoPlayer>();
        video.Stop();
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this.gameObject);
        }
      
        
        if(AliceCursoleStage.stagecount == 1 && Alicetyutoriaru.gametutorial == true)
        {
            
            //recount = 2;
            Invoke("Clear", 2.8f);
        }
        if(AliceCursoleStage.stagecount == 1 && Alicetyutoriaru.nottyutorial == true)
        {
            //recount = 1;
            Invoke("Clear", 2.8f);
            //Alicetyutoriaru.nottyutorial = false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Clear() {
        //yield return new WaitForSeconds(2.5f);
        StartCoroutine("Karten");
        StartCoroutine("Desto");
    }
 
    IEnumerator Karten() {
       
        yield return new WaitForSeconds(1.0f);
        reqestmusic.PlayOneShot(sound);
        kar.color = new Color32(255, 255, 255, 255);
        video.Play();




    }
  
    
    IEnumerator Desto() {
        
        yield return new WaitForSeconds(6.0f);
        video.Stop();
        //recount = 0;

        DontDestroyEnabled = false;
       
        Destroy(this.gameObject);

    }
    
   
}
