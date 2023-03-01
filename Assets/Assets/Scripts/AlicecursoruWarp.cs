using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AlicecursoruWarp : MonoBehaviour
{
    [SerializeField] private GameObject warpa;
    [SerializeField] private GameObject warpb;
    [SerializeField] private GameObject warpc;
    [SerializeField] private GameObject warpd;
    private Vector3 pos1;//= new Vector3(0, 0, 0);
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;

    [SerializeField] private GameObject WarpButton1;
    [SerializeField] private GameObject WarpButton2;
    [SerializeField] private GameObject WarpButton3;
    [SerializeField] private GameObject WarpButton4;

    [SerializeField] private GameObject AliceA;
    [SerializeField] private GameObject AliceB;
    [SerializeField] private GameObject AliceC;
    [SerializeField] private GameObject AliceD;

    [SerializeField] private GameObject Warp1p;
    [SerializeField] private GameObject Warp2p;
    [SerializeField] private GameObject Warp3p;
    [SerializeField] private GameObject Warp4p;

    [SerializeField] private GameObject Player;
    StarterAssets.ThirdPersonController th;
    Animator planim;
    [SerializeField] private GameObject tan;
    TanscuController tansu;
    bool kesu = false;
    [SerializeField] private GameObject upcamera;

    [SerializeField] private GameObject myAlice;
    Vector3 miA;
    RawImage mya;


    public bool KESU
    {
        set
        {
            this.kesu = value;
        }
        get
        {
            return this.kesu;
        }
    }
    AudioSource warpmusic;
    [SerializeField] private AudioClip alicewarp;
    bool osita = false;
 
    // Start is called before the first frame update
    void Start()
    {
      
        
        th = Player.GetComponent<StarterAssets.ThirdPersonController>();
        planim = Player.GetComponent<Animator>();
        upcamera.SetActive(false);
        pos1 = warpa.transform.position;
        pos2 = warpb.transform.position;
        pos3 = warpc.transform.position;
        pos4 = warpd.transform.position;
        warpmusic = GetComponent<AudioSource>();
        tansu = tan.GetComponent<TanscuController>();

        Warp1p = GameObject.Find("WarpPoint1");
        Warp2p = GameObject.Find("WarpPoint2");
        Warp3p = GameObject.Find("WarpPoint3");
        Warp4p = GameObject.Find("WarpPoint4");
        miA = myAlice.transform.position;
        mya = myAlice.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
     
       
          if(osita == false) { 
        if (miA.y < 806.86f)
        {
            if(Gamepad.current.leftStick.up.wasReleasedThisFrame)
            {
                miA.y += 180f;
                transform.position = miA;
            }
            
        }
        if(miA.y > 266.86f)
        {
            if (Gamepad.current.leftStick.down.wasReleasedThisFrame)
            {
                miA.y -= 180f;
                transform.position = miA;
            }
        }
      
       if(miA.y == 806.86f)
        {
            if(Gamepad.current.buttonEast.wasReleasedThisFrame)
            //if(Input.GetKeyDown(KeyCode.Q))
            {
                    Player.transform.position = pos1;
                    osita = true;
               
               warpmusic.PlayOneShot(alicewarp);
                StartCoroutine("Transparent");
               StartCoroutine("WarpA");
               //Warp1();
                
            }
       }

        if(miA.y == 626.86f) {
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                    Player.transform.position = pos2;
                    osita = true;
                    
                    warpmusic.PlayOneShot(alicewarp);
                    StartCoroutine("Transparent");
                     StartCoroutine("WarpB");
                    //Warp2();
                }
        }
        if(miA.y == 446.86f) {
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                    Player.transform.position = pos3;
                    osita = true;
                   
                    warpmusic.PlayOneShot(alicewarp);
                    StartCoroutine("Transparent");
                     StartCoroutine("WarpC");
                   
                }
        }
        if(miA.y == 266.86f) {
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                    Player.transform.position = pos4;
                    osita = true;
                    
               warpmusic.PlayOneShot(alicewarp);
                StartCoroutine("Transparent");
                StartCoroutine("WarpD");
            }
        }
        }
    }

    IEnumerator Transparent()
    {

        int co = 5;
        while (co != 0)
        {
            for (int i = 0; i < 100; i++)
            {
                mya.color = new Color(255, 255, 255, 0);
            }

            yield return new WaitForSeconds(0.1f);

            for (int k = 0; k < 100; k++)
            {
                mya.color = new Color32(255, 255, 255, 255);
            }

            yield return new WaitForSeconds(0.1f);
            co--;
            //mesh.color = mesh.color - new Color32(0, 0, 0, 0);
        }
    }


    IEnumerator WarpA()
    {
        yield return new WaitForSeconds(1.0f);
        Warp1();
        upcamera.SetActive(false);
        th.WARPDO = false;
    }
    IEnumerator WarpB() {
        yield return new WaitForSeconds(1.0f);
        Warp2();
        upcamera.SetActive(false);
        th.WARPDO = false;
    }

    IEnumerator WarpC() {
        yield return new WaitForSeconds(1.0f);
        Warp3();
        upcamera.SetActive(false);
        th.WARPDO = false;
    }
    IEnumerator WarpD() {
        yield return new WaitForSeconds(1.0f);
        Warp4();
        upcamera.SetActive(false);
        th.WARPDO = false;
    }
    void Warp1()
    {
        
        //Player.transform.position = pos1;
        th.enabled = true;
            planim.enabled = true;
            tansu.STWA = false;
            
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);

            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
        osita = false;
            kesu = true;
       
    }

    void Warp2()
    {
        //pause‚É‚·‚é
        // if (WarpButton2.name == "Warpbutton2")
        // {
        
        th.enabled = true;
            planim.enabled = true;
            tansu.STWA = false;
         
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
        osita = false;
        kesu = true;
            //pause‚ð‰ðœ‚³‚¹‚é
       // }
    }

    void Warp3()
    {
        //pause‚É‚·‚é
        // if (WarpButton3.name == "Warpbutton3")
        // {
        
        th.enabled = true;
            planim.enabled = true;
            tansu.STWA = false;
           
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
        osita = false;
        kesu = true;
            //pause‚ð‰ðœ‚³‚¹‚é
       // }
    }

     void Warp4()
    {
        //pause‚É‚·‚é
        // if (WarpButton4.name == "Warpbutton4")
        // {
        
        th.enabled = true;
            planim.enabled = true;
            tansu.STWA = false;
         
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
        osita = false;
        kesu = true;
            //pause‚ð‰ðœ‚³‚¹‚é
      //  }
    }
}
