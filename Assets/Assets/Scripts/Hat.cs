using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class Hat : MonoBehaviour
{
    VideoPlayer videoPlayer;
    [SerializeField] private GameObject ga;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GameObject.Find("Hat").GetComponent<VideoPlayer>();
        videoPlayer.Stop();
        ga.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            videoPlayer.Play();
            //StartCoroutine("TH");
        }
    }

    IEnumerator TH()
    {
        yield return new WaitForSeconds(1f);
        ga.SetActive(true);
    }
}
