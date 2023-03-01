using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Ø‚è‘Ö‚¦Œã‚ÌƒJƒƒ‰")]
    private CinemachineVirtualCamera virtualCamera;

    
    bool cameraidou = false;
    bool sindou = false;
    public bool SINDOU {
        set {
            this.sindou = value;
        }
        get {
            return this.sindou;
        }
    }
    public bool CAMERAMOVE {
        set {
            this.cameraidou = value;
        }
        get {
            return this.cameraidou;
        }
    }
    bool move = false;
    public bool MOVES {
        set {
            this.move = false;
        }
        get {
            return this.move;
        }
    }
    CameraController cas;
    StarterAssets.ThirdPersonController pl;
    TreeOpen tr;
    GameManager ga;
    // Ø‚è‘Ö‚¦Œã‚ÌƒJƒƒ‰‚ÌŒ³X‚ÌPriority‚ğ•Û‚µ‚Ä‚¨‚­
    private int defaultPriority;
   float times;
  
    // Start is called before the first frame update
    void Start()
    {
        defaultPriority = virtualCamera.Priority;
        //ga = GameObject.Find("GameManager").GetComponent<GameManager>();
        pl = GameObject.Find("PlayerArmature").GetComponent<StarterAssets.ThirdPersonController>();
        cas = GameObject.Find("MainCamera").GetComponent<CameraController>();
        tr = GameObject.Find("Treekaihou").GetComponent<TreeOpen>();
        ga = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pl.SYUGAR == 6) {
            sindou = true;
            move = true;
            
            cameraidou = true;
            virtualCamera.Priority = 100;
         
        }
        if(move == true) {
            times += Time.deltaTime;
        }
        if(times >= 8.0f) {
            move = false;
            times = 0;
            
        }
        if(tr.MOVEFIN == true) {
            virtualCamera.Priority = defaultPriority;
            //cameraidou = false;
            tr.MOVEFIN = false;
           
        }
       
        
    }
    /*
    IEnumerator Moves() {
        
        yield return new WaitForSeconds(1.0f);
        move = false;
        //pl.SYUGAR = 0;
    }
    */
}
