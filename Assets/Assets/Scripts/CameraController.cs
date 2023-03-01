using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    //private GameObject pauseUIInstance;

    [SerializeField] private GameObject bookUI;
    [SerializeField] private GameObject bookManager;
    Book book;
    [SerializeField] private AudioClip close;
    AudioSource closemusic;
    [SerializeField] private GameObject alicearrow;
    Alicepoose alice;
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    bool stopp = false;//これがポーズ画面になったことを示すフラグ
    int stops = 0;//tabキーを押した回数

    public bool STOP {
        set {
            this.stopp = value;
        }
        get {
            return this.stopp;
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        alice = alicearrow.GetComponent<Alicepoose>();
        pauseUIPrefab.SetActive(false);
        Cursor.visible = false;
        bookUI.SetActive(false);
        bookManager = GameObject.Find("BookManager");
        book = bookManager.GetComponent<Book>();
        closemusic = GetComponent<AudioSource>();
        
    }


    void Update()
    {
      
        if(th.WARP == true) {
            StartCoroutine("Wa");
        }

        //if(Keyboard.current.tabKey.wasReleasedThisFrame) {
        if(Gamepad.current.startButton.wasReleasedThisFrame) {
            pauseUIPrefab.SetActive(true);
            stopp = true;
          
        }
        
        if(alice.NEXT == true){
            stopp = false;
            Cursor.visible = false;
            pauseUIPrefab.SetActive(false);
            alice.NEXT = false;
        }
        if(book.BOOK == true) {
            stopp = true;
            bookUI.SetActive(true);
            Cursor.visible = true;
            //Time.timeScale = 0f;
        }
     
    }
    /*
    public void OnClosebook() {
        stopp = false;
        closemusic.PlayOneShot(close);
        Cursor.visible = false;
        bookUI.SetActive(false);
        book.BOOK = false;
        //Time.timeScale = 1f;
    }
    :*/
    IEnumerator Wa() {
        yield return new WaitForSeconds(3.0f);
        pl.transform.position = goal.transform.position;
        transform.position = goal.transform.position;
    }
}
