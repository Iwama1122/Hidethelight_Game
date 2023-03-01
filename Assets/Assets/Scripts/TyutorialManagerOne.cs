using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class TyutorialManagerOne : MonoBehaviour
{
        [SerializeField] private GameObject TyManager;
        TyutorialManager tyu;
        public static TyutorialManagerOne Instance { get; private set; }
        public UserScriptsManagerOne userScriptManagerone;
        public TyutorialText TyutorialTextController;
        [SerializeField]
        private GameObject maintext;
        [SerializeField]
        private GameObject Sousa;
        int count = 0;
        // ���[�U�X�N���v�g�́A���̍s�̐��l�B�N���b�N�i�^�b�v�j�̂��т�1��������B
        [System.NonSerialized] public int lineNumber;
        void Awake() {
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
            if(tyu.NEXTCOUNT == 1)
            {
                maintext.SetActive(true);
            }
            //maintext.SetActive(false);��true�ɂ���
            if(lineNumber == 8) {

                Sousa.SetActive(true);
            }
            if(lineNumber == 9) {
               if(count != 1) { 
                    count = 1;
                    tyu.TYUCOUNT= true;
                }
                maintext.SetActive(false);
            }
        }
    }
}
