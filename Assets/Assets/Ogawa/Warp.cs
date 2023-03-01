using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] private GameObject warpa;
    [SerializeField] private GameObject warpb;
    [SerializeField] private GameObject warpc;
    [SerializeField] private GameObject warpd;
    private Vector3 pos1 ;//= new Vector3(0, 0, 0);
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;

    public GameObject WarpButton1;
    public GameObject WarpButton2;
    public GameObject WarpButton3;
    public GameObject WarpButton4;
    [SerializeField] private GameObject AliceA;
    [SerializeField] private GameObject AliceB;
    [SerializeField] private GameObject AliceC;
    [SerializeField] private GameObject AliceD;


    

    public GameObject Warp1p;
    
    public GameObject Warp2p;
    
    public GameObject Warp3p;
   
    public GameObject Warp4p;
    

    [SerializeField] private GameObject Player;
   

    [SerializeField] private GameObject tan;
    TanscuController tansu;

    bool kesu = false;

    public bool KESU {
        set {
            this.kesu = value;
        }
        get {
            return this.kesu;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pos1 = warpa.transform.position;
        pos2 = warpb.transform.position;
        pos3 = warpc.transform.position;
        pos4 = warpd.transform.position;
        Player = GameObject.Find("PlayerArmature");
        
        tansu = tan.GetComponent<TanscuController>();
        
        Warp1p = GameObject.Find("WarpPoint1");
        Warp2p = GameObject.Find("WarpPoint2");
        Warp3p = GameObject.Find("WarpPoint3");
        Warp4p = GameObject.Find("WarpPoint4");
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void Warp1()
    {
        //ワープした先でもう一度ボタンが表示される不具合がある

        //pauseにする
        if (WarpButton1.name == "Warpbutton1")
        {
            
            
            tansu.STWA = false;
            Player.transform.position = pos1;
            Player.transform.rotation = Quaternion.Euler(0,180,0);
            
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
            kesu = true;
            //th.WAB = false;
            //pauseを解除させる
        }
    }

    public void Warp2()
    {
        //pauseにする
        if (WarpButton2.name == "Warpbutton2")
        {
            
            tansu.STWA = false;
            Player.transform.position = pos2;
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
            kesu = true;
            //pauseを解除させる
        }
    }

    public void Warp3()
    {
        //pauseにする
        if (WarpButton3.name == "Warpbutton3")
        {
            
            tansu.STWA = false;
            Player.transform.position = pos3;
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
            kesu = true;
            //pauseを解除させる
        }
    }

    public void Warp4()
    {
        //pauseにする
        if (WarpButton4.name == "Warpbutton4")
        {
            
            tansu.STWA = false;
            Player.transform.position = pos4;
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            AliceA.SetActive(false);
            AliceB.SetActive(false);
            AliceC.SetActive(false);
            AliceD.SetActive(false);
            WarpButton1.SetActive(false);
            WarpButton2.SetActive(false);
            WarpButton3.SetActive(false);
            WarpButton4.SetActive(false);
            kesu = true;
            //pauseを解除させる
        }
    }

    
}
