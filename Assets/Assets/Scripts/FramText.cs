using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FramText : MonoBehaviour
{
    float time;
    Text timeText;
   
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
            time = 1f / Time.deltaTime; ;
            timeText.text = time.ToString();
        
    }
}
