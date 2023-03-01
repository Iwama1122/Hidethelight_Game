using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyutorialManager : MonoBehaviour
{
    bool TyutorialCount = false;
    public bool TYUTORIAL {
        set {
            this.TyutorialCount = value;
        }
        get {
            return this.TyutorialCount;
        }
    }
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController th;
    Animator planim;

    //本とろうそくの矢印と敵とアイテム、テキストを格納する
   [SerializeField] private GameObject Bookarrow;
    [SerializeField] private GameObject tablearrow;
    [SerializeField] private GameObject mirorrarrow;
    [SerializeField] private GameObject goalarrow;
    [SerializeField] private GameObject sloatarrow;



    [SerializeField] private GameObject gotext;
    [SerializeField] private GameObject gotext1;
    [SerializeField] private GameObject gotext2;


    [SerializeField] private GameObject tyutorose;
    [SerializeField] private GameObject tyutospoon;
    [SerializeField] private GameObject Enemys;
    [SerializeField] private GameObject[] kubi;
    int kubicount = 0;
    [SerializeField] private GameObject mane;
    GameManager ga;
    int nextCount = 0;
    public int NEXTCOUNT
    {
        set
        {
            this.nextCount = value;
        }
        get
        {
            return this.nextCount;
        }
    }
    bool tyucount = false;
    public bool TYUCOUNT
    {
        set
        {
            this.tyucount = value;
        }
        get
        {
            return this.tyucount;
        }
    }
    //ここで背景を薄暗くするオブジェクトを管理する
    // Start is called before the first frame update
    void Start()
    {
        mirorrarrow.SetActive(false);
        goalarrow.SetActive(false);
        sloatarrow.SetActive(false);
        gotext.SetActive(false);
        gotext1.SetActive(false);
        gotext2.SetActive(false);
        ga = mane.GetComponent<GameManager>();
        th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        planim = pl.GetComponent<Animator>();
        Bookarrow.SetActive(false);
        tablearrow.SetActive(false);
        tyutorose.SetActive(false);
        tyutospoon.SetActive(false);
        if (Alicetyutoriaru.gametutorial == true)
        {
            Enemys.SetActive(false);
            kubicount = kubi.Length;
            for (int i = 0; i < kubicount; i++)
            {
                kubi[i].SetActive(false);
            }
        }
       
        
             
       
        if(Alicetyutoriaru.gametutorial == true)
        {
            Invoke("Tyutorial", 1.0f);
        }
       
        //TyuTwo.SetActive(false);
        //TyuThird.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(tyucount == true)
        {
            nextCount++;
            tyucount = false;
        }
       
        switch (nextCount)
        {
            case 1:
                Bookarrow.SetActive(false);
                tablearrow.SetActive(false);
                tyutorose.SetActive(false);
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(false);
                tyutospoon.SetActive(false);
                Enemys.SetActive(false);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(false);
                }
                th.enabled = false;
                planim.enabled = false;
                ga.START = false;
                break;
            case 2:
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(false);
                Bookarrow.SetActive(true);
                tablearrow.SetActive(true);
                tyutorose.SetActive(false);
                tyutospoon.SetActive(false);
                gotext.SetActive(true);
                gotext1.SetActive(false);
                gotext2.SetActive(false);
                Enemys.SetActive(false);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(false);
                }
                th.enabled = true;
                planim.enabled = true;
                ga.START = true;
                break;
            case 3:
                tyutorose.SetActive(false);
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(false);
                tyutospoon.SetActive(false);
                Enemys.SetActive(false);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(false);
                }
                th.enabled = true;
                planim.enabled = true;
                ga.START = true;
                break;
            case 4:
                Bookarrow.SetActive(false);
                tablearrow.SetActive(false);
                tyutorose.SetActive(false);
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(false);
                tyutospoon.SetActive(false);
                Enemys.SetActive(false);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(false);
                }
                th.enabled = false;
                planim.enabled = false;
                ga.START = false;
                break;
            case 5:
                gotext.SetActive(false);
                gotext1.SetActive(true);
                gotext2.SetActive(false);
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(true);
                Bookarrow.SetActive(false);
                tablearrow.SetActive(false);
                if(th.WH != 2)
                {
                    tyutorose.SetActive(true);
                    
                }
                if(th.WH == 2)
                {
                    tyutorose.SetActive(false);
                }
                
                tyutospoon.SetActive(false);
                Enemys.SetActive(false);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(false);
                }
                th.enabled = true;
                planim.enabled = true;
                ga.START = true;
                break;
            case 6:
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(false);
             
                Bookarrow.SetActive(false);
                tablearrow.SetActive(false);
                tyutospoon.SetActive(false);
                tyutorose.SetActive(false);
         
                tyutospoon.SetActive(false);
                Enemys.SetActive(false);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(false);
                }
                th.enabled = false;
                planim.enabled = false;
                ga.START = false;
                break;
            case 7:
                mirorrarrow.SetActive(false);
                goalarrow.SetActive(false);
                sloatarrow.SetActive(false);
                Bookarrow.SetActive(false);
                tablearrow.SetActive(false);
                gotext.SetActive(false);
                gotext1.SetActive(false);
                gotext2.SetActive(true);
                if(th.SPOON == true)
                {
              
                    tyutospoon.SetActive(false);
                    //th.SPOON = false;
                }
                if(th.SPOON == false)
                {
                    tyutospoon.SetActive(true);
                }
               
                Enemys.SetActive(true);
                for (int i = 0; i < kubicount; i++)
                {
                    kubi[i].SetActive(true);
                }
                th.enabled = true;
                planim.enabled = true;
                ga.START = true;
                break;
                case 8:
                mirorrarrow.SetActive(true);
                goalarrow.SetActive(true);
                sloatarrow.SetActive(false);
                gotext.SetActive(false);
                tyutospoon.SetActive(false);
                break;
           
                
        }
        /*デバック用のキー
        if(Input.GetKeyDown(KeyCode.L))
        {
            nextCount++;
            TyutorialCount = true;
        }
  */
        /*
        switch(nextCount)
        {
            case 1:
              //  TyuOne.SetActive(true);
                break;
            case 2:
              //  TyuTwo.SetActive(true);
                break;
            case 3:
              //  TyuThird.SetActive(true);
                break;

        }
        */
       
    }
    void Tyutorial()
    {
        nextCount++;
        TyutorialCount = true;
        
    }
}
