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
        // ユーザスクリプトの、今の行の数値。クリック（タップ）のたびに1ずつ増える。
        [System.NonSerialized] public int lineNumber;
        void Awake() {
            // これで、別のクラスからGameManagerの変数などを使えるようになる。

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
            //maintext.SetActive(false);をtrueにする
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
