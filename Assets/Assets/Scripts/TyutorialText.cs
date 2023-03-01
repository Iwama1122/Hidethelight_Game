using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

namespace NovelGame
{
    public class TyutorialText : MonoBehaviour
{
        [SerializeField] TextMeshProUGUI _mainTextObject;
        int _displayedSentenceLength;
        int _sentenceLength;
        float _time;
        float _feedTime;
        [SerializeField] private GameObject Alice;
        [SerializeField] private GameObject Hat;
        [SerializeField] private TextMeshProUGUI NameText;
        //[SerializeField]
        //private Text NameText;
        [SerializeField] private GameObject talkicon;
        [SerializeField] private GameObject _camera;
        CameraController cas;
        // Start is called before the first frame update
        void Start()
        {
            cas = _camera.GetComponent<CameraController>();
            DisplayText();
            _time = 0f;
            _feedTime = 0.05f;
            Alice.SetActive(false);
            Hat.SetActive(false);
            talkicon.SetActive(false);
        }

    // Update is called once per frame
    void Update()
    {
            switch(TyutorialManagerOne.Instance.lineNumber) {
                case 0:
                    NameText.text = "???";
                    Alice.SetActive(false);
                    Hat.SetActive(true);
                    break;
                case 1:
                    NameText.text = "�A���X";
                    Alice.SetActive(true);
                    Hat.SetActive(false);
                    break;
                case 2:
                    NameText.text = "�X�q��";
                    Alice.SetActive(false);
                    Hat.SetActive(true);
                    break;
                case 3:
                    NameText.text = "�A���X";
                    Alice.SetActive(true);
                    Hat.SetActive(false);
                    break;
                case 4:
                    NameText.text = "�X�q��";
                    Alice.SetActive(false);
                    Hat.SetActive(true);
                    break;
                case 5:
                    NameText.text = "�X�q��";
                    Alice.SetActive(false);
                    Hat.SetActive(true);
                    break;
                case 6:
                    NameText.text = "�X�q��";
                    Alice.SetActive(false);
                    Hat.SetActive(true);
                    break;
                case 7:
                    NameText.text = "�A���X";
                    Alice.SetActive(true);
                    Hat.SetActive(false);
                    break;
                case 8:
                    NameText.text = "�X�q��";
                    Alice.SetActive(false);
                    Hat.SetActive(true);
                    break;
              

            }
            // �N���b�N���ꂽ�Ƃ��A���̍s�ֈړ�
            // ���͂��P�������\������
            _time += Time.deltaTime;
            if(_time >= _feedTime) {
                _time -= _feedTime;
                if(!CanGoToTheNextLine()) {
                    talkicon.SetActive(false);
                    _displayedSentenceLength++;
                    _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;
                } else {
                    talkicon.SetActive(true);
                }
            }
            //if(Gamepad.current.aButton.wasReleasedThisFrame) {
            if(cas.STOP == false) { 
            if(Gamepad.current.buttonEast.wasReleasedThisFrame) {
                if(CanGoToTheNextLine()) {

                    GoToTheNextLine();
                    DisplayText();
                }
            }
        }
        }
        // ���̍s�́A���ׂĂ̕������\������Ă��Ȃ���΁A�܂����̍s�֐i�ނ��Ƃ͂ł��Ȃ�
        public bool CanGoToTheNextLine() {
            string sentence = TyutorialManagerOne.Instance.userScriptManagerone.GetCurrentSentence();
            return (_displayedSentenceLength > sentence.Length);
        }

        // ���̍s�ֈړ�
        public void GoToTheNextLine() {
            _displayedSentenceLength = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;
            TyutorialManagerOne.Instance.lineNumber++;
        }

        // �e�L�X�g��\��
        public void DisplayText() {
            string sentence = TyutorialManagerOne.Instance.userScriptManagerone.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
    }
}
