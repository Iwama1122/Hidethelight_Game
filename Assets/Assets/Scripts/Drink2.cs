using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink2 : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeTeaset;
    float time;

    public GameObject guide;
    public GameObject icon;
    float fadespeed = 0.02f;
    float red, green, blue, alpha;
    bool isFadeIn = false;
    bool isFadeOut = false;

    Renderer r;

    void Start()
    {
        time = 0f;

        targets = GameObject.FindGameObjectsWithTag("teatool");
        float closeDist = 100000;//距離の近さ

        foreach (GameObject target in targets)
        {
            float tDist = Vector3.Distance(transform.position, target.transform.position);//アリスとお茶道具の距離計測
            if (closeDist > tDist)
            {
                closeDist = tDist;
                closeTeaset = target;
            }
        }

        //r = guide.GetComponent<Renderer>();
        //r.material.color = new Color(red, green, blue, alpha);
        //red = r.material.color.r;
        //green = r.material.color.g;
        //blue = r.material.color.b;

        //alpha = r.material.color.a;


    }
    void Update()
    {
        //if (isFadeIn)
        //{
          //  FadeIn();
        //}
        //if (isFadeOut)
        //{
         //   FadeOut();
       // }

        //time += Time.deltaTime;
        //isFadeIn = true;
        //icon.SetActive(false);

        Vector3 vector3 = closeTeaset.transform.position - this.transform.position;
        vector3.y = 0f;

        Quaternion quaternion = Quaternion.LookRotation(vector3);//回転値取得
        this.transform.rotation = quaternion;

        //if (alpha >= 1)
        //{
         //   isFadeIn = false;
       // }
    //
        
        //if (time >= 10)
        //{
        //    this.gameObject.SetActive(false);
        //    icon.SetActive(true);
        //}
    }

    //void FadeIn()
    //{
       // r.enabled = true;
       // alpha += fadespeed;
       // SetAlpha();
       
        
   // }

    //void FadeOut()
    //{
      //  alpha -= fadespeed;
       // SetAlpha();
       // if (alpha <= 0)
       // {
        //  isFadeOut = false;
         //   r.enabled = false;
        //}
    //

    // SetAlpha()
    //{
      //  r.material.color = new Color(red, green, blue, alpha);
    //
}
