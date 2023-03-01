using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadecontroller : MonoBehaviour
{
    float fadeSpeed = 0.005f;        //�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�

    public bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
   // public bool isFadeIn = false;   //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O
    Image fadeImage;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject goal;
    GoalController go;
    Alicenight hinaano;
    bool iiyo = false;
    public bool IIYO {
        set {
            this.iiyo = value;
        }
        get {
            return this.iiyo;
        }

    }
 
    int y = 0;
    // Start is called before the first frame update
    void Start() {
        go = goal.GetComponent<GoalController>();
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        hinaano = icon.GetComponent<Alicenight>();
    }

    // Update is called once per frame
    void Update() {
    
        if(go.NI == true) {
            isFadeOut = true;
            y++;
            go.NI = false;
        }
      
        if(hinaano.YESGOAL == true) {
            isFadeOut = true;
            y++;
            hinaano.YESGOAL = false;
        }

        if(isFadeOut) {
            StartFadeOut();
        }
    }
    /*
    void StartFadeIn() {
        alfa -= fadeSpeed;                //a)�s�����x�����X�ɉ�����
        SetAlpha();                      //b)�ύX�����s�����x�p�l���ɔ��f����
        if(alfa <= 0) {                    //c)���S�ɓ����ɂȂ����珈���𔲂���
            isFadeIn = false;
            fadeImage.enabled = false;    //d)�p�l���̕\�����I�t�ɂ���

        }
    }
    */
    void StartFadeOut() {
        fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
        SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
        if(y == 1) {
            if(alfa >= 0.5) {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
                                          //iiyo = true;
                isFadeOut = false;

            }
        }
        if(y == 2) {
            if(alfa >= 1) {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
                iiyo = true;
                isFadeOut = false;

            }
        }
    }
    void SetAlpha() {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    /*
    IEnumerator StartFadeIns() {
        yield return new WaitForSeconds(1.0f);
        StartFadeIn();
    }
    */
}
