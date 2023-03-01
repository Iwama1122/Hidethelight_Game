using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NovelGame
{
    public class Tyutorialfade : MonoBehaviour
    {
        float fadeSpeed = 0.005f;
        float alfa;
        bool isTyutorialFadeOut = false;
        bool Fadefinish = false; 
        Image fadeImage;
        [SerializeField] private GameObject tyuMane;
        [SerializeField]
        private GameObject tyuMane1;
        [SerializeField]
        private GameObject tyuMane2;
        [SerializeField]
        private GameObject tyuMane3;
        TyutorialManagerOne tyu1;
        TyutorialManagerTwo tyu2;
        TyutorialManagerThird tyu3;
        TyutorialManager tyu;
        // Start is called before the first frame update
        void Start()
        {
            fadeImage = GetComponent<Image>();
            tyu = tyuMane.GetComponent<TyutorialManager>();
            tyu1 = tyuMane1.GetComponent<TyutorialManagerOne>();
            tyu2 = tyuMane2.GetComponent<TyutorialManagerTwo>();
            tyu3 = tyuMane3.GetComponent<TyutorialManagerThird>();
        }

        // Update is called once per frame
        void Update()
        {

            //�����Ƀ`���[�g���A���}�l�[�W���[�̈�t���O��p�ӂ���true�ɂ��Ď��s
           
            if(tyu.TYUTORIAL == true) {
                isTyutorialFadeOut = true;
           
            }
                if(TyutorialManagerOne.Instance.lineNumber >= 9) {
                
                    Fadefinish = true;
                    tyu1.enabled = false;
                    TyutorialManagerOne.Instance.lineNumber = 0;
                }
                
            
                if(tyu.NEXTCOUNT == 5) {
                   
                    Fadefinish = true;
                    
                //StartCoroutine("TyuTwo");
                }
                if(TyutorialManagerThird.Instance.lineNumber >= 5) {
              
                    Fadefinish = true;
                    tyu3.enabled = false;
                }
                if(Fadefinish == true) {
                    alfa = 0f;
                    SetAlpha();
                    Fadefinish = false;
                }

                if(isTyutorialFadeOut)
                {
                    StartFadeOut();
                }
           
            }
        void StartFadeOut()
        {
            //fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
            alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
            SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
        
                if (alfa >= 0.5)
                {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
                              //iiyo = true;
                    isTyutorialFadeOut = false;
                     tyu.TYUTORIAL = false;
                
                //fadeImage.enabled = false;
            }
            
        }
        void SetAlpha()
        {
            fadeImage.color = new Color(0, 0, 0, alfa);
        }
        IEnumerator TyuTwo() {
            yield return new WaitForSeconds(0.1f);
            //tyu2.enabled = false;
            TyutorialManagerTwo.Instance.lineNumber = 0;
        }
    }
}
