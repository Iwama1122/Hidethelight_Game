using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.UI.Extensions;

public class Alicebageidou : MonoBehaviour
{
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject botton1;
    [SerializeField] private GameObject botton2;
    Vector3 bo;//選択1
    Vector3 bo1;//選択2
    Vector3 bo2;//選択3
    Vector3 my;
    [SerializeField]
    private GameObject myme;
    RawImage myarrow;
    //bool osita = false;//押してからアイコンが点滅するから点滅してる間は操作できないようにするフラグ

    bool up = false;
    public GameObject bookPanel;
    private BookUI bookUI;
    [SerializeField] GameObject book;
    public int crrentPage = 0;
    //  public int lastPage = 5;
    private int lastPage;
   [SerializeField] private GameObject bookManager;
    Book books;
    [SerializeField] private GameObject cas;
    CameraController ca;
    AudioSource audios;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private GameObject　tyumane;
    TyutorialManager tyuma;
    int count = 0;
    bool t = false;
    bool right = false;
    bool left = false;
 
    public enum GameLevel
    {
        NORMAL,
        HARD,
        NIGHTMARE,
    }
    public GameLevel level;
    // Start is called before the first frame update
    void Start()
    {
        botton.SetActive(false);
        botton1.SetActive(true);
        botton2.SetActive(true);
        tyuma = tyumane.GetComponent<TyutorialManager>();
        //bookPanel.SetActive(false);
        audios = GetComponent<AudioSource>();
        ca = cas.GetComponent<CameraController>();
        bookManager = GameObject.Find("BookManager");
        books = bookManager.GetComponent<Book>();
        switch (AliceCursoleStage.stagecount)
        {
            case 1:
                level = GameLevel.NORMAL;
               
                break;
            case 2:
                level = GameLevel.HARD;
                break;
            case 3:
                level = GameLevel.NIGHTMARE;
                break;
        }
        bookUI = book.GetComponent<BookUI>();
        //level = GameLevel.NIGHTMARE;
        bo = botton.transform.position;
        bo1 = botton1.transform.position;
        bo2 = botton2.transform.position;
        //this.transform.position = new Vector3(bo1.x, bo1.y, 0);
        myarrow = myme.GetComponent<RawImage>();
        myarrow.color = new Color(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
    
        switch (level)//難易度でページを変える
        {
            case GameLevel.NORMAL:
                lastPage = 2;
                break;
            case GameLevel.HARD:
                lastPage = 5;
                break;
            case GameLevel.NIGHTMARE:
                lastPage = 6;
                break;
        }
        
        
        my = this.transform.position;

        //横バージョン
       
            if(up == false) { 
            if(left == false) { 
            if (my.x < bo1.x-50f)
            {
                if (Gamepad.current.leftStick.right.wasReleasedThisFrame)
                {
                    my.x += 1680f;
                    transform.position = my;
                }
            }
            }
            if(right == false) { 
            if (my.x > bo.x)
            {
                if (Gamepad.current.leftStick.left.wasReleasedThisFrame)
                {
                    my.x -= 1680f;
                    transform.position = my;
                }
            }
            }
        }
            if (Gamepad.current.leftStick.up.wasReleasedThisFrame)
            {
                up = true;
                //if(left == true) {
                my.x = bo2.x;
                my.y = bo2.y;
                //my.y;
            //} 
               //if(right == true) {
                   //my = bo2;
               //}
                
                transform.position = my;
            }
            if(Gamepad.current.leftStick.down.wasReleasedThisFrame)
            {
                up = false;
            //if(left == true) {
                my = bo;
           // }
            //if(right == true) {
               // my = bo1;
           // }
                transform.position = my;
        }
        if (my.x == bo.x)
        {
            if (Gamepad.current.buttonEast.wasReleasedThisFrame)
            {
                left = false;
                if(bookUI.CurrentPage != 0) {
                    audios.PlayOneShot(clip[0]);
               }
                
                bookUI.CurrentPage--;
                if (bookUI.CurrentPage < 0)//ページ範囲外にいかないように
                {
                    bookUI.CurrentPage++;
                }
            }
        }
        if (my.x == bo1.x)
        {
            if (Gamepad.current.buttonEast.wasReleasedThisFrame)
            {
                right = false;
                if(bookUI.CurrentPage != lastPage-1) {
                    audios.PlayOneShot(clip[0]);
                    
                }

                bookUI.CurrentPage++;
                if (bookUI.CurrentPage == lastPage)
                {
                    bookUI.CurrentPage--;
                }
            }
        }
        if(my == bo2)
        {
            if (Gamepad.current.buttonEast.wasReleasedThisFrame)
            {

                if(count != 1) { 
                if(Alicetyutoriaru.gametutorial == true)
                {
                        count = 1;
                        t = true;
                    
                }
                if(t == true)
                {
                    tyuma.TYUCOUNT = true;
                    t = false;
                }
                }
                audios.PlayOneShot(clip[1]);
               StartCoroutine("Book");
            }
        }

        if(bookUI.CurrentPage == 0) {
            botton1.SetActive(true);
            botton.SetActive(false);
            right = true;
            if(up == false) {
                my = bo1;
                transform.position = my;
            }
        } else {
            botton1.SetActive(true);
            botton.SetActive(true);
        }
        if(level == GameLevel.NORMAL && bookUI.CurrentPage == 1) {
            botton1.SetActive(false);
            botton.SetActive(true);
            left = true;
            if(up == false) {
                my = bo;
                transform.position = my;
            }
        }
        else if(level == GameLevel.HARD && bookUI.CurrentPage == 4) {
            botton1.SetActive(false);
            botton.SetActive(true);
            left = true;
            if(up == false) {
                my = bo;
                transform.position = my;
            }
        }
        else if(level == GameLevel.NIGHTMARE && bookUI.CurrentPage == 5) {
            botton1.SetActive(false);
            botton.SetActive(true);
            left = true;
            if(up == false) {
                my = bo;
                transform.position = my;
            }
        }
     
    }
    IEnumerator Book() {
        yield return new WaitForSeconds(0.3f);
    
        ca.STOP = false;
        bookPanel.SetActive(false);
        books.BOOK = false;
    }

}
