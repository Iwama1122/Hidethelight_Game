using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MovieController : MonoBehaviour
{
    VideoPlayer my;
    [SerializeField] private GameObject pa;
    Fadecontroller fa;
    float alha;
    float fadeSpeed = 1.0f;
    RawImage mye;
    [SerializeField]
    private GameObject moviemusic;
    // Start is called before the first frame update
    void Start() {
       
        moviemusic.SetActive(false);
        fa = pa.GetComponent<Fadecontroller>();
        my = this.GetComponent<VideoPlayer>();
        my.enabled = false;
        mye = GetComponent<RawImage>();
        mye.enabled = false;
        my.Stop();
    }

    // Update is called once per frame
    void Update() {
        
        if(fa.IIYO == true) {
            alha += fadeSpeed;
            mye.color = new Color32(255, 255, 255, (byte)alha);
            my.enabled = true;
            mye.enabled = true;
            my.Play();

            StartCoroutine("MovieMusic");
            
            StartCoroutine("GameClear");
            //mye.color = new Color32(255, 255, 255, (byte)alha);
            if(alha >= 255f) {
                fa.IIYO = false;
                //fa.isFadeOut = false;
            }
        }
        
    }


    IEnumerator GameClear() {
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("CreditsRollScene");////GameClear
    }
    IEnumerator MovieMusic() {
        yield return new WaitForSeconds(1.2f);
        moviemusic.SetActive(true);
    }
}
