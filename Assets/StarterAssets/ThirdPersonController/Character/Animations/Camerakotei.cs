using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Camerakotei : MonoBehaviour
{
    CinemachineVirtualCamera vi;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    [SerializeField] private GameObject goal;
    //public GameObject ck;
    
    public Transform cks;

    // Start is called before the first frame update
    void Start()
    {
        vi = GetComponent<CinemachineVirtualCamera>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        // = 
        //ck = GameObject.Find()
    }

    // Update is called once per frame
    void Update()
    {
       if(th.WARP == true) {
            StartCoroutine("Warp");
        }
        
       if(th.GAMEOVER == true) {
            vi.Follow = cks;
        }
    }
    IEnumerator Warp() {
        yield return new WaitForSeconds(3.0f);
        this.transform.position = goal.transform.position;
    }
}
