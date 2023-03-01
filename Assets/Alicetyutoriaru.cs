using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Alicetyutoriaru : MonoBehaviour
{
    [SerializeField] private GameObject stagealice;
    AliceCursoleStage stage;
    Vector3 my;
    public static bool gametutorial = false;
    bool osenai = false;
    
    [SerializeField]
    private GameObject myme;
    RawImage myarrow;
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject botton1;
    Vector3 bo;//‘I‘ð1
    Vector3 bo1;//‘I‘ð2
    public static bool nottyutorial = false;
    AudioSource alicetyuto;
    [SerializeField] private AudioClip alice;
    // Start is called before the first frame update
    void Start()
    {
        alicetyuto = GetComponent<AudioSource>();
        bo = botton.transform.position;
        bo1 = botton1.transform.position;
        this.transform.position = new Vector3(bo.x-100f, bo.y, 0);
        myarrow = myme.GetComponent<RawImage>();
        myarrow.color = new Color(255, 255, 255, 255);
        stage = stagealice.GetComponent<AliceCursoleStage>();
    }

    // Update is called once per frame
    void Update()
    {
        my = this.transform.position;
        if(osenai == false && stage.TYUTO == true) {
            if(my.y < bo.y) {
                if(Gamepad.current.leftStick.up.isPressed) {
                    my.y += 275f;
                    transform.position = my;
                    
                }
            }
            if(my.y > bo1.y) {
                if(Gamepad.current.leftStick.down.isPressed) {
                    my.y -= 275f;
                    transform.position = my;
                }
            }
            if(my.y == 562.8929f)
            {//2585
                if (Gamepad.current.buttonEast.isPressed) {
                    gametutorial = true;
                    stage.STAGEKARTEN = true;
                    StartCoroutine("Transparent");
                    StartCoroutine("Starts");
                    osenai = true;
                    alicetyuto.PlayOneShot(alice);
                }
            }
            if(my.y <= 287.8929f) {
                if(Gamepad.current.buttonEast.isPressed) {
                    stage.STAGEKARTEN = true;
                    nottyutorial = true;
                    StartCoroutine("Transparent");
                    osenai = true;
                    StartCoroutine("Starts");
                    alicetyuto.PlayOneShot(alice);
                }
            }
        }
    }
    IEnumerator Transparent() {

        int co = 5;
        while(co != 0) {
            for(int i = 0; i < 100; i++) {
                myarrow.color = new Color(255, 255, 255, 0);
            }

            yield return new WaitForSeconds(0.1f);

            for(int k = 0; k < 100; k++) {
                myarrow.color = new Color32(255, 255, 255, 255);
            }

            yield return new WaitForSeconds(0.1f);
            co--;
            //mesh.color = mesh.color - new Color32(0, 0, 0, 0);
        }
    }
    IEnumerator Starts() {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("RequestScene");
    }
  
}
