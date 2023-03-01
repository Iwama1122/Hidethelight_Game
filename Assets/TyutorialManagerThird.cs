using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class TyutorialManagerThird : MonoBehaviour
    {
        [SerializeField] private GameObject TyManager;
        TyutorialManager tyu;
        public static TyutorialManagerThird Instance { get; private set; }
        public UserScriptsManagerThird userScriptManagerthird;
        public TyutorialTextThird TyutorialTextController;
        [SerializeField]
        private GameObject maintext;
        int counts = 0;
        int count = 0;
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
         
            maintext.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //���ƂŃ`���[�g���A���}�l�[�W���[�̂ق��Ńt���O��p�ӂ���
            //maintext.SetActive(false);��true�ɂ���
           if(tyu.NEXTCOUNT == 6)
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
                if (counts != 1)
                {
                    counts = 1;
                    tyu.TYUCOUNT = true;
                }
                maintext.SetActive(false);
            }
        }
    }
}
