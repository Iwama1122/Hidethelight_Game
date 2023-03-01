using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.InputSystem;

public class ButterMove : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeTeaset;
    float time;

    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController st;
    //[SerializeField] private ParticleSystem d;
    [SerializeField] private GameObject d;
    float speed;
    bool efstop = false;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject ItemCount;
    hyoujisroto hyouji;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        d.SetActive(false);
        //d.Stop();
        time = 0f;
        pl = GameObject.Find("PlayerArmature");
        st = pl.GetComponent<StarterAssets.ThirdPersonController>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        hyouji = ItemCount.GetComponent<hyoujisroto>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        targets = GameObject.FindGameObjectsWithTag("teatool");
        float closeDist = 1000;//距離の近さ

        foreach(GameObject target in targets) {
            float tDist = Vector3.Distance(transform.position, target.transform.position);//アリスとお茶道具の距離計測

            //if(closeDist > tDist) {
                closeDist = tDist;
                closeTeaset = target;
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ここにスロットで選ばれていたらのif文を作る
        if(ga.START == true) {
            if(cas.STOP == false) {
                //ここにスロットで選ばれていたらのif文を書く
                if(hyouji.COUNT == 2) {
                    if(Gamepad.current.buttonSouth.wasReleasedThisFrame && st.DRINK != 0) {
                        arrow.SetActive(true);
                        st.DRINK--;
                        d.SetActive(true);
                        efstop = true;
                   }
                }
            if(efstop == true) {
            time+= Time.deltaTime;
            speed = 0.05f;
            d.transform.position = Vector3.MoveTowards(d.transform.position, closeTeaset.transform.position, speed);
            Vector3 vector3 = closeTeaset.transform.position - this.transform.position;
            vector3.y = 0f;

            Quaternion quaternion = Quaternion.LookRotation(vector3);//回転値取得
            d.transform.rotation = quaternion;

            if(time >=10f) {//本来は10秒で止めるからスピード要調節//d.transform.position == closeTeaset.transform.position
                            speed = 0f;
                            d.SetActive(false);
                            arrow.SetActive(false);
                efstop = false;
                            time = 0;
            }
        }
      
      }
     }
    }
}
