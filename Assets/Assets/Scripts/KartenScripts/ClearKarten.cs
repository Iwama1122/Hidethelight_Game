using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ClearKarten : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] private GameObject ka;
    RawImage kar;
    AudioSource clearmusic;
    [SerializeField] private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        clearmusic = GetComponent<AudioSource>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255, 255, 255, 0);
        DontDestroyOnLoad(this.gameObject);
        video = GetComponentInChildren<VideoPlayer>();
        video.Stop();
        if(Alicenight._yes == true) {
            Invoke("Clear", 10.0f);
        } else {
            Invoke("Clear", 3.0f);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clear() {
        StartCoroutine("Karten");
    }

    IEnumerator Karten() {
        yield return new WaitForSeconds(1.5f);
        clearmusic.PlayOneShot(sound);
        kar.color = new Color32(255, 255, 255, 255);
        video.Play();
        StartCoroutine("Desto");
    }
    IEnumerator Desto() {
        yield return new WaitForSeconds(3.5f);

        Destroy(this.gameObject);
    }
}
