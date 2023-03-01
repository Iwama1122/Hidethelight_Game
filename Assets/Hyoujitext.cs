using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hyoujitext : MonoBehaviour
{
    [SerializeField] private GameObject Hyoujisuru;
    hyoujisroto hi;
    Text te;
    // Start is called before the first frame update
    void Start()
    {
        hi = Hyoujisuru.GetComponent<hyoujisroto>();
        te = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
