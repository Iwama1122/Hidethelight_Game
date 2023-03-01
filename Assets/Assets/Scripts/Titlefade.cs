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
        //fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する

        if(alfa >= 1) {             // d)完全に不透明になったら処理を抜ける
                                      //iiyo = true;
            isFadeOut = false;
            StartCoroutine("Fadein");

            //fadeImage.enabled = false;
        }

    }
    void StartFadeIn() {
        alfa -= fadeinSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する

        if(alfa <= 0) {             // d)完全に不透明になったら処理を抜ける
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
