using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kusa : MonoBehaviour
{
    [SerializeField] private Text kusatext;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject plbig;
    Big bi;
   
    [SerializeField] private GameObject hair;
    hairu hai;
    // Start is called before the first frame update
    void Start()
    {
        hai = hair.GetComponent<hairu>();
      
        
        icon.SetActive(false);
        kusatext.text = " ";
        bi = plbig.GetComponent<Big>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(hai.HAIRU == true) {
          
                icon.SetActive(true);
            kusatext.text = "Å@Ç≈èoÇÈ";
            hai.HAIRU = false;
        }
        
    }

}
