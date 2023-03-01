using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame { 
public class TyutorialManagerTwo : MonoBehaviour
{
    [SerializeField] private GameObject TyManager;
    TyutorialManager tyu;
    public static TyutorialManagerTwo Instance { get; private set; }
    public UserScriptsManagerTwo userScriptManagertwo;
    public TyutorialtextTwo TyutorialTextController;
    [SerializeField]
    private GameObject maintext;
    [SerializeField]
    private GameObject Sousa;
    bool two = false;
    int count= 0;
    int counts = 0;
    // ���[�U�X�N���v�g�́A���̍s�̐��l�B�N���b�N�i�^�b�v�j�̂��т�1��������B
    [System.NonSerialized] public int lineNumber;
    void Awake()
    {
        // ����ŁA�ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂȂ�B

        Instance = this;
        lineNumber = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        tyu = TyManager.GetComponent<TyutorialManager>();
        Sousa.SetActive(false);
        maintext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(tyu.NEXTCOUNT == 4)
        {
            if (count != 1)
            {
                 
                 count = 1;
                  tyu.TYUTORIAL = true;

            }


                maintext.SetActive(true);
        }
    
        if (lineNumber == 5)
        {

            Sousa.SetActive(true);
        }
        if (lineNumber == 6)
        {
                if(counts != 1)
                {
                    counts = 1;
                    tyu.TYUCOUNT = true;
                }
                              
                maintext.SetActive(false);
        }
    }
}
}
