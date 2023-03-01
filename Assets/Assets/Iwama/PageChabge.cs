using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageChabge : AliceCursoleStage
{
    [SerializeField] Sprite[] bookPages;
    public int crrentPage = 0;
    public int lastPage;
    Image bookImage;

    [SerializeField] private AudioClip nextpage;
    AudioSource page;

    public enum GameLevel
    {
        NORMAL,
        HARD,
        UNKNOWN,
    }
    public GameLevel level;



    void Start()
    {
      bookImage = GetComponent<Image>();
      switch(stagecount) {
            case 1:
                level = GameLevel.NORMAL;
                
                break;
            case 2:
                level = GameLevel.HARD;
                break;
            case 3:
                level = GameLevel.UNKNOWN;
                break;
        }
      //level = GameLevel.HARD;
        page = GetComponent<AudioSource>();
    }


    void Update()
    {
        switch (level) {
            case GameLevel.NORMAL:
               
                lastPage = 3;
                break;
            case GameLevel.HARD:
                lastPage = 4;
                break;
            case GameLevel.UNKNOWN:
                lastPage = 5;
                break;
        }
    }


    public void BackPages()
    {
       crrentPage--;
        page.PlayOneShot(nextpage);

        if (crrentPage < 0)
        {
            crrentPage++;
        }
        bookImage.sprite = bookPages[crrentPage];
    }

    public void AheadPages()
    {
       crrentPage++;
        page.PlayOneShot(nextpage);
        if (crrentPage == lastPage)
        {
            crrentPage--;
        }
        bookImage.sprite=  bookPages[crrentPage];
    }
}

