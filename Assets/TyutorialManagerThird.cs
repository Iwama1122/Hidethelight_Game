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
        // ユーザスクリプトの、今の行の数値。クリック（タップ）のたびに1ずつ増える。
        [System.NonSerialized] public int lineNumber;

        void Awake()
        {
            // これで、別のクラスからGameManagerの変数などを使えるようになる。

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
            //あとでチュートリアルマネージャーのほうでフラグを用意して
            //maintext.SetActive(false);をtrueにする
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
