using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    
    [SerializeField] private GameObject AliceA;
    [SerializeField] private GameObject AliceB;
    [SerializeField] private GameObject AliceC;
    [SerializeField] private GameObject AliceD;

    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    Animator planim;
    [SerializeField] private GameObject warpUI;

    [SerializeField] private GameObject wapbu;
    AlicecursoruWarp warpbutt;
    [SerializeField] private GameObject ca;
    CameraController cas;


    // Start is called before the first frame update
    void Start()
    {
        cas = ca.GetComponent<CameraController>();
        //wapbu = GameObject.Find("Alicewarp");
        warpbutt = wapbu.GetComponent<AlicecursoruWarp>();
        pl = GameObject.Find("PlayerArmature");
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        planim = pl.GetComponent<Animator>();
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        AliceA.SetActive(false);
        AliceB.SetActive(false);
        AliceC.SetActive(false);
        AliceD.SetActive(false);
        warpUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
            if(warpbutt.KESU == true) {
            Cursor.visible = false;
            warpUI.SetActive(false);
            cas.STOP = false;
            warpbutt.KESU = false;
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && gameObject.name == "WarpPoint1")
        {
            
            th.enabled = false;
            planim.enabled = false;
            //mapを表示させる

            //pauseさせる
            
            cas.STOP = true;
            warpUI.SetActive(true);
            //Cursor.visible = true;
            AliceA.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
            Button4.SetActive(true);
        }
        if(other.gameObject.tag == "Player"  && gameObject.name == "WarpPoint2")
        {
           
            th.enabled = false;
            planim.enabled = false;
            //mapを表示させる
            //pauseさせる
            //warp = true;
            cas.STOP = true;
            warpUI.SetActive(true);
            //Cursor.visible = true;
            AliceB.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
            Button4.SetActive(true);
        }
       if (other.gameObject.tag == "Player"  && gameObject.name == "WarpPoint3")
        {
            
            th.enabled = false;
            planim.enabled = false;
            //mapを表示させる
            //pauseさせる
            //warp = true;
            cas.STOP = true;
            warpUI.SetActive(true);
            //Cursor.visible = true;
            AliceC.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
            Button4.SetActive(true);
        }
        if (other.gameObject.tag == "Player"  && gameObject.name == "WarpPoint4")
        {
            
            th.enabled = false;
            planim.enabled = false;
            //mapを表示させる
            //pauseさせる
            //warp = true;
            cas.STOP = true;
            warpUI.SetActive(true);
            //Cursor.visible = true;
            AliceD.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
            Button4.SetActive(true);
           
        }
    }


}
