using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadecontroller : MonoBehaviour
{
    float fadeSpeed = 0.005f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
   // public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ
    Image fadeImage;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject goal;
    GoalController go;
    Alicenight hinaano;
    bool iiyo = false;
    public bool IIYO {
        set {
            this.iiyo = value;
        }
        get {
            return this.iiyo;
        }

    }
 
    int y = 0;
    // Start is called before the first frame update
    void Start() {
        go = goal.GetComponent<GoalController>();
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        hinaano = icon.GetComponent<Alicenight>();
    }

    // Update is called once per frame
    void Update() {
    
        if(go.NI == true) {
            isFadeOut = true;
            y++;
            go.NI = false;
        }
      
        if(hinaano.YESGOAL == true) {
            isFadeOut = true;
            y++;
            hinaano.YESGOAL = false;
        }

        if(isFadeOut) {
            StartFadeOut();
        }
    }
    /*
    void StartFadeIn() {
        alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if(alfa <= 0) {                    //c)完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;    //d)パネルの表示をオフにする

        }
    }
    */
    void StartFadeOut() {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if(y == 1) {
            if(alfa >= 0.5) {             // d)完全に不透明になったら処理を抜ける
                                          //iiyo = true;
                isFadeOut = false;

            }
        }
        if(y == 2) {
            if(alfa >= 1) {             // d)完全に不透明になったら処理を抜ける
                iiyo = true;
                isFadeOut = false;

            }
        }
    }
    void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    /*
    IEnumerator StartFadeIns() {
        yield return new WaitForSeconds(1.0f);
        StartFadeIn();
    }
    */
}
