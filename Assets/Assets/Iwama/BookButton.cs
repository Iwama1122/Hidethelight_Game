using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class BookButton : MonoBehaviour
{
    public GameObject bookPanel;
    private BookUI bookUI;
    [SerializeField] GameObject book;
    public int crrentPage = 0;
    //  public int lastPage = 5;
    private int lastPage;

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
        bookUI = book.GetComponent<BookUI>();
        level = GameLevel.NIGHTMARE;

        
    }

    // Update is called once per frame
    void Update()
    {
        switch (level)//難易度によってページ数変化させる
        {
            case GameLevel.NORMAL:
                lastPage = 2;
                break;
            case GameLevel.HARD:
                lastPage = 4;
                break;
            case GameLevel.NIGHTMARE:
                lastPage = 6;
                break;
        }
    }

    public void BackPages()//左ボタン
    {
        bookUI.CurrentPage--;
        if(bookUI.CurrentPage < 0)
        {
          bookUI.CurrentPage++;
        }
    }

    public void AheadPages()//右ボタン、出てこないページを出さないように
    {
        bookUI.CurrentPage++;
       if (bookUI.CurrentPage == lastPage)
       {
          bookUI.CurrentPage--;
       }
    }

    public void ChoseBook()//閉じる
    {
        bookPanel.SetActive(false);
    }
}
