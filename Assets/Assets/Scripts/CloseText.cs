using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseText : MonoBehaviour
{
    Text mytext;
    float alha;
    // Start is called before the first frame update
    void Start()
    {
        mytext = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        alha += Time.deltaTime;
        mytext.color = new Color(255, 0, 0, alha);
    }
}
