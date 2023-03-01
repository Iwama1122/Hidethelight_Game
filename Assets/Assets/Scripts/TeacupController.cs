using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacupController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject myArrow;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    void Start()
    {
        myArrow.SetActive(false);
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(th.SYUGAR == 3) {
            myArrow.SetActive(true);
        }
    }
}
