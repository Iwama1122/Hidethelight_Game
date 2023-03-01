using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Idoukarten : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] private GameObject alice;
    Cursoleidou cu;
    bool DontDestroyEnabled = true;
    [SerializeField] private GameObject ka;
    RawImage kar;
    AudioSource katen;
    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        katen = GetComponent<AudioSource>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255,255,255,0);
        if(DontDestroyEnabled){
            DontDestroyOnLoad(this.gameObject);
        }
        cu = alice.GetComponent<Cursoleidou>();
        video = GetComponentInChildren<VideoPlayer>();
        video.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(cu.TITLE == true) {
            
            StartCoroutine("Karten");
            cu.TITLE = false;
        }
    }
    IEnumerator Karten() {
        yield return new WaitForSeconds(1.5f);
        katen.PlayOneShot(clip);
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
    
}
