using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RetrunTitles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Gamepad.current.buttonSouth.isPressed) {
            StartCoroutine("Titleretrun");
        }
    }

    IEnumerator Titleretrun() {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("TitleScene");
    }
}
