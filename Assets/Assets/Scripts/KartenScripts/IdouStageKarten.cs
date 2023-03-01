using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IdouStageKarten : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] private GameObject alice;
    AliceCursoleStage cu;
    bool DontDestroyEnabled = true;
    [SerializeField] private GameObject ka;
    RawImage kar;
    AudioSource katenmusic;
    [SerializeField] private AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {

        katenmusic = GetComponent<AudioSource>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255, 255, 255, 0);
        if(DontDestroyEnabled) {
            DontDestroyOnLoad(this.gameObject);
        }
        cu = alice.GetComponent<AliceCursoleStage>();
        video = GetComponentInChildren<VideoPlayer>();
        video.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(cu.STAGEKARTEN == true) {

            StartCoroutine("Karten");
            cu.STAGEKARTEN = false;
        }
    }

    IEnumerator Karten() {
        yield return new WaitForSeconds(1.49f);
        katenmusic.PlayOneShot(sound);
        kar.color = new Color32(255, 255, 255, 255);
        video.Play();
        StartCoroutine("Desto");
    }
    IEnumerator Desto() {
        yield return new WaitForSeconds(5.0f);
        DontDestroyEnabled = false;
        video.Stop();
        Destroy(this.gameObject);
    }
}
