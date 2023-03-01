using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Returngame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReturn() {
        SceneManager.LoadScene("SampleScene");
    }
    /*
    public void OnReturns() {ここは2番目に難しい
        SceneManager.LoadScene("SampleScene");
    }
    
    public void OnReturnex() {ここはナイトメア
        SceneManager.LoadScene("SampleScene");
    }
    */
}
