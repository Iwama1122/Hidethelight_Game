using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OverKarten : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] private GameObject alice;
    AliceOverarrow cu;
    bool DontDestroyEnabled = true;
    [SerializeField] private GameObject ka;
    RawImage kar;
    AudioSource overmusic;
    [SerializeField] private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        overmusic = GetComponent<AudioSource>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255, 255, 255, 0);
        if(DontDestroyEnabled) {
            DontDestroyOnLoad(this.gameObject);
        }
        cu = alice.GetComponent<AliceOverarrow>();
        video = GetComponentInChildren<VideoPlayer>();
        video.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(cu.OVERTITLE == true) {
            StartCoroutine("Karten");
            cu.OVERTITLE = false;
        }
    }

    IEnumerator Karten() {
        yield return new WaitForSeconds(1.5f);
        overmusic.PlayOneShot(sound);
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
