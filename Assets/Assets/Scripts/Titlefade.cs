using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Titlefade : MonoBehaviour
{
    float fadeSpeed = 0.005f;
    float fadeinSpeed = 0.005f;
    float alfa;
    Image fadeImage;
    bool isFadeOut = false;
    bool isFadeIn = false;
    public bool FADEOUT {
        set {
            this.isFadeOut = value;
        }
        get {
            return this.isFadeOut;
        }
    }
    [SerializeField] private GameObject titlealice;
    Cursoleidou cualice;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        cualice = titlealice.GetComponent<Cursoleidou>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeOut) {
            StartFadeOut();
        }

        if(isFadeIn) {
            StartFadeIn();
        }

    }

    void StartFadeOut() {
        //fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
        SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����

        if(alfa >= 1) {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
                                      //iiyo = true;
            isFadeOut = false;
            StartCoroutine("Fadein");

            //fadeImage.enabled = false;
        }

    }
    void StartFadeIn() {
        alfa -= fadeinSpeed;         // b)�s�����x�����X�ɂ�����
        SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����

        if(alfa <= 0) {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
                                    //iiyo = true;
            isFadeIn = false;
            

            //fadeImage.enabled = false;
        }
    }

    void SetAlpha() {
        fadeImage.color = new Color(0, 0, 0, alfa);
    }
    IEnumerator Fadein() {
       yield return new  WaitForSeconds(2.0f);
        isFadeIn = true;
    }
}
