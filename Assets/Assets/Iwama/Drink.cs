using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drink: MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeTeaset;
    public GameObject guide;//追加
    public GameObject icon;//追加

    float time;
    
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController st;
   
    void Start()
    {
        
       
        time = 0f;
        pl = GameObject.Find("PlayerArmature");
        st = pl.GetComponent<StarterAssets.ThirdPersonController>();

            targets = GameObject.FindGameObjectsWithTag("teatool");
            float closeDist = 1000;//距離の近さ

            foreach (GameObject target in targets)
            {
                float tDist = Vector3.Distance(transform.position, target.transform.position);//アリスとお茶道具の距離計測

                if (closeDist > tDist)
                {
                    closeDist = tDist;
                    closeTeaset = target;
                }
            }
    }
    void Update()
    {
       
        
            time += Time.deltaTime;
           
            Vector3 vector3 = closeTeaset.transform.position - this.transform.position;
            vector3.y = 0f;

             Quaternion quaternion = Quaternion.LookRotation(vector3);//回転値取得
             this.transform.rotation = quaternion;
           
        
        if (time >= 10)
        {
            
            this.gameObject.SetActive(false);
            st.DRINK--;
            time = 0;
        }
        
    }
}