using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateWhiteFlower : MonoBehaviour
{
    [SerializeField] private GameObject WhFlower;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ma;
    GameManager ga;
    StarterAssets.ThirdPersonController th;
    //int whcount = 4;//ここは今は仮の変数を入れていて
    //本来はplayerが白い薔薇をゲットした際にgetで取得する
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject ItemCount;
    hyoujisroto hyouji;
    [SerializeField] private GameObject tyumane;
    TyutorialManager tyuma;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        tyuma = tyumane.GetComponent<TyutorialManager>();
        hyouji = ItemCount.GetComponent<hyoujisroto>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        player = GameObject.Find("PlayerArmature");
        th = player.GetComponentInParent<StarterAssets.ThirdPersonController>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ga.START == true ) {
            if(cas.STOP == false) { 
            //ここにスロットで選ばれていたらのif文を書く
            if(hyouji.COUNT == 1) { 
            if(Gamepad.current.buttonSouth.isPressed && th.WH != 0) {

                if(th.WH > 0) { 
                CrateWhiteFlower();
                    if(count != 1) { 
                        if(Alicetyutoriaru.gametutorial == true)
                        {
                                    CrateWhiteFlower();
                                    tyuma.TYUCOUNT = true;
                        count = 1;
                    }
                    }
                    th.WH--;
                 }
                
            }
           }
         }
        }
    }

    public void CrateWhiteFlower() {
        
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        Instantiate(WhFlower, new Vector3(x, y, z), transform.rotation);
        
    }
}
