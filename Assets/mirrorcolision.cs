using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorcolision : MonoBehaviour
{
    [SerializeField] private GameObject Goal;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        Goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(th.WARP == true) { 
        Goal.SetActive(true);
            //StartCoroutine("My");
        }
    }
    IEnumerator My() {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
    }
    
}
