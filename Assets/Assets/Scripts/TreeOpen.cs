using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TreeOpen : MonoBehaviour
{
    SwitchCamera sw;
    float y;
    bool movefin = false;
    [SerializeField] private GameObject effects;
    [SerializeField] private GameObject MapTree;
    public bool MOVEFIN {
        set {
            this.movefin = value;
        }
        get {
            return this.movefin;
        }
    }
    [SerializeField] private GameObject mirror;
    // Start is called before the first frame update
    void Start()
    {
        MapTree.SetActive(true);
        mirror.SetActive(false);
        sw = GameObject.Find("Switch Area").GetComponent<SwitchCamera>();
        effects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        y = this.transform.position.y;
        if(sw.CAMERAMOVE == true) 
        {
            MapTree.SetActive(false);
            effects.SetActive(true);
            //transform.position -= transform.up * Time.deltaTime;
            transform.DOMove(new Vector3(-0.1033261f, -6.0f, 47.80936f), 4f);
                                              // 移動終了地点      // 演出時間
            transform.DOShakePosition(3.0f, 0.07f);
            if(y < -3.9f) {
                mirror.SetActive(true);
                mirror.transform.DOMove(new Vector3(-2.41f, 4.48f, 49.45f), 3f);
                // 移動終了地点      // 演出時間
                //mirror.transform.DOShakePosition(3.0f, 0.07f);
               StartCoroutine("Mirr");


            }   
        }

    }
    IEnumerator Mirr() {
        yield return new WaitForSeconds(4.0f);
        effects.SetActive(false);
        movefin = true;
        sw.CAMERAMOVE = false;
        this.gameObject.SetActive(false);
    }
}
