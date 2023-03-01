using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class TalkManager : MonoBehaviour
    {
        // �ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂ��邽�߂̂��́B�i�ύX�͂ł��Ȃ��j
        public static TalkManager Instance { get; private set; }
        public UserScriptsManager userScriptManager;
        public MainTextController mainTextController;
        [SerializeField] private GameObject Chase;
        [SerializeField] private GameObject Chase1;
        [SerializeField] private GameObject movie;
        [SerializeField]
        private GameObject fade;

        Fadecontroller fa;
        [SerializeField]
        private GameObject maintext;
        [SerializeField]
        private GameObject icon;
        [SerializeField] private GameObject goal;
        GoalController go;
        Alicenight hi;
        [SerializeField] private GameObject pl;
        StarterAssets.ThirdPersonController th;
        Animator planim;
        // ���[�U�X�N���v�g�́A���̍s�̐��l�B�N���b�N�i�^�b�v�j�̂��т�1��������B
        [System.NonSerialized] public int lineNumber;
        void Awake() {
            // ����ŁA�ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂȂ�B

            Instance = this;
            lineNumber = 0;
        }
        private void Start() {
            th = pl.GetComponent<StarterAssets.ThirdPersonController>();
            planim = pl.GetComponent<Animator>();
            go = goal.GetComponent<GoalController>();
            Chase.SetActive(false);
            Chase1.SetActive(false);
            icon.SetActive(false);
            maintext.SetActive(false);
            hi = icon.GetComponent<Alicenight>();
            movie.SetActive(false);
            fa = fade.GetComponent<Fadecontroller>();
        }
        private void Update() {
            /*�f�o�b�O�p�̃L�[
            if(Input.GetKeyDown(KeyCode.M)) {
                go.NIGHT = true;
                go.NI = true;
                th.enabled = false;
                planim.enabled = false;
            }*/
            if(go.NIGHT == true) {
                maintext.SetActive(true);
            }
            if(lineNumber == 11) {
                Chase.SetActive(true);
                Chase1.SetActive(true);
                icon.SetActive(true);
                maintext.SetActive(false);
            }
            
            if(hi.YES == true) {
                Chase.SetActive(false);
                Chase1.SetActive(false);
                icon.SetActive(false);
            }
           if(fa.IIYO == true) {
                movie.SetActive(true);
            }
            
        }
    }
}
