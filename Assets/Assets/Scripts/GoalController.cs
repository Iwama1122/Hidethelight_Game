using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    bool goal = false;
    bool nightmearagoal = false;
    bool night = false;
    Animator planim;
    public bool NIGHT {
        set {
            this.nightmearagoal = value;
        }
        get {
            return this.nightmearagoal;
        }
    }
    public bool NI {
        set {
            this.night = value;
        }
        get {
            return this.night;
        }
    }
    public bool GOAL {
        set {
            this.goal = value;
        }
        get {
            return this.goal;
        }

    }
    [SerializeField] private GameObject camer;
    CameraController cas;
    // Start is called before the first frame update
    void Start()
    {
        planim = pl.GetComponent<Animator>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        cas = camer.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
       
            
            if(AliceCursoleStage.stagecount == 3) {
               
                nightmearagoal = true;
                night = true;
               th.enabled = false;
               planim.enabled = false;
                cas.STOP = true;
            } else {
                cas.STOP = true;
                goal = true;
                StartCoroutine("GameClear");
            }
            
        }
    }

    IEnumerator GameClear() {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GameClear");
    }
}
