using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class Kartensousa : MonoBehaviour
{
    VideoPlayer video;
    [SerializeField] private GameObject ka;
    RawImage kar;
    AudioSource sousamusic;
    [SerializeField] private AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        sousamusic = GetComponent<AudioSource>();
        kar = ka.GetComponent<RawImage>();
        kar.color = new Color32(255, 255, 255, 0);
        DontDestroyOnLoad(this.gameObject);
        video = GetComponentInChildren<VideoPlayer>();
        video.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current.buttonSouth.wasReleasedThisFrame) {
            StartCoroutine("Karten");
        }
    }

    IEnumerator Karten() {
        yield return new WaitForSeconds(0.1f);
        sousamusic.PlayOneShot(sound);
        kar.color = new Color32(255, 255, 255, 255);
        video.Play();
        StartCoroutine("Desto");
    }
    IEnumerator Desto() {
        yield return new WaitForSeconds(3.5f);

        Destroy(this.gameObject);
    }
}
