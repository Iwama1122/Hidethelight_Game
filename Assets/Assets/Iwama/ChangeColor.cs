using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    PlayerController script;

    public GameObject roze;
    Renderer r;
    float red = 255f;
    float green = 255f;
    float blue = 255f;

    bool Stay;
    float time;

    void Start()
    {
        script = GameObject.Find("Player").GetComponent<PlayerController>();

        r = roze.GetComponent<Renderer>();

        Stay = false;
        time = 0f;
    }

    void Update()
    {
        if (Stay)
        { 
            time += Time.deltaTime;
            if (time >= 5)
            {
                Destroy(roze);

               script = script.gameObject.GetComponent<PlayerController>();
                script.enabled = true;
            }
        }
    }


    void OnTriggerStay(Collider collider)
    {

        if (collider.gameObject.tag == "Enemy")//F•ÏX‚·‚é
        {
            r.material.color = new Color(red, green, blue);

            if (green >= 0 && blue >= 0)
            {
               green -= 1f;
               blue -= 1f;
                GetComponent<Renderer>().material.color = new Color(red / 255, green / 255, blue / 255);

                script = script.gameObject.GetComponent<PlayerController>();
                script.enabled = false;

                Stay = true;
                //Debug.Log(r.material.color);
            }
        }
    }
}
