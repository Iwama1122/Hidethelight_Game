using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinsearch : MonoBehaviour
{
    [SerializeField]
    private GameObject kaku;
    kakureru ka;
    AudioSource audioSource;
    bool twinmusic = false;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        kaku = GameObject.Find("kakure");
        ka = kaku.GetComponent<kakureru>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(th.GAMEOVER == true) {
            audioSource.mute = true;
        }
        if(twinmusic == true) {
            audioSource.mute = false;
            twinmusic = false;
        }

        if(ka.TWIN == true) {
            twinmusic = true;
           
        } else if(ka.TWIN == false) {
           
            audioSource.mute = true;
        }
    }
}
