using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class EndRollScript : MonoBehaviour
{
    //　テキストのスクロールスピード
    [SerializeField]
    private float textScrollSpeed = 80f;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 3900f;

    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;

    //　シーン移動用コルーチン
    private Coroutine endRollCoroutine;

    [SerializeField] private GameObject Fadeui;
    Image Fade;

    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
    float  alfa;   //不透明度を管理


    [SerializeField] private GameObject EndRollmovie;
    RawImage endrollmovie;
    VideoPlayer _endroll;
    bool pushbotton = false;
    [SerializeField] private GameObject SkkipButton;
    // Start is called before the first frame update
    void Start()
    {
        SkkipButton.SetActive(false);
        endrollmovie = EndRollmovie.GetComponent<RawImage>();
        endrollmovie.enabled = false;
        _endroll = EndRollmovie.GetComponent<VideoPlayer>();
        _endroll.enabled = false;
        Invoke("StartMovie",2.0f);
        Fade = Fadeui.GetComponent<Image>();
       
        alfa = Fade.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current.buttonSouth.wasReleasedThisFrame) {
            pushbotton = true;
            
        }
        if(pushbotton == true) {
            StartFadeOut();
            StartCoroutine("GoToNextScenes");
        }
        if(pushbotton == false){ 
        //　エンドロールが終了した時
           if(isStopEndRoll) {
                endRollCoroutine = StartCoroutine(GoToNextScene());
           } 
           else {
                  //　エンドロール用テキストがリミットを越えるまで動かす
                  if(transform.position.y >=  4700f) {
                    endrollmovie.enabled = false;
                    _endroll.enabled = false;
                  }
                  if(transform.position.y <= limitPosition) {
                  transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
                  } 
          
                  else {
                  isStopEndRoll = true;
                  }
           }
        }
        
       
        
    }

    void StartMovie() {
        endrollmovie.enabled = true;
        _endroll.enabled = true;
        SkkipButton.SetActive(true);
    }

    void StartFadeOut() {
        Fade.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        
    }

    void SetAlpha() {
        Fade.color = new Color(0, 0, 0, alfa);
    }

    IEnumerator GoToNextScene() {
        yield return new WaitForSeconds(5f);
        StartFadeOut();

        //　1(6)秒間待つ
        yield return new WaitForSeconds(1f);
            StopCoroutine(endRollCoroutine);
            SceneManager.LoadScene("GameClear");

        yield return null;
    }

    IEnumerator GoToNextScenes() {
        //　3秒間待つ
        yield return new WaitForSeconds(3f);
        endrollmovie.enabled = false;
        _endroll.enabled = false;
        SceneManager.LoadScene("GameClear");
     

        yield return null;
    }
}
