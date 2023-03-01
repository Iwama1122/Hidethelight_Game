using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class EndRollScript : MonoBehaviour
{
    //�@�e�L�X�g�̃X�N���[���X�s�[�h
    [SerializeField]
    private float textScrollSpeed = 80f;
    //�@�e�L�X�g�̐����ʒu
    [SerializeField]
    private float limitPosition = 3900f;

    //�@�G���h���[�����I���������ǂ���
    private bool isStopEndRoll;

    //�@�V�[���ړ��p�R���[�`��
    private Coroutine endRollCoroutine;

    [SerializeField] private GameObject Fadeui;
    Image Fade;

    float fadeSpeed = 0.02f;        //�����x���ς��X�s�[�h���Ǘ�
    float  alfa;   //�s�����x���Ǘ�


    [SerializeField] private GameObject EndRollmovie;
    RawImage endrollmovie;
    VideoPlayer _endroll;
    bool pushbotton = false;
    [SerializeField] private GameObject SkkipButton;
    // Start is called before the first frame update
    void Start()
    {
        SkkipButton.SetActive(false);
        endrollmovie = EndRollmovie.GetComponent<RawImage>();
        endrollmovie.enabled = false;
        _endroll = EndRollmovie.GetComponent<VideoPlayer>();
        _endroll.enabled = false;
        Invoke("StartMovie",2.0f);
        Fade = Fadeui.GetComponent<Image>();
       
        alfa = Fade.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current.buttonSouth.wasReleasedThisFrame) {
            pushbotton = true;
            
        }
        if(pushbotton == true) {
            StartFadeOut();
            StartCoroutine("GoToNextScenes");
        }
        if(pushbotton == false){ 
        //�@�G���h���[�����I��������
           if(isStopEndRoll) {
                endRollCoroutine = StartCoroutine(GoToNextScene());
           } 
           else {
                  //�@�G���h���[���p�e�L�X�g�����~�b�g���z����܂œ�����
                  if(transform.position.y >=  4700f) {
                    endrollmovie.enabled = false;
                    _endroll.enabled = false;
                  }
                  if(transform.position.y <= limitPosition) {
                  transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
                  } 
          
                  else {
                  isStopEndRoll = true;
                  }
           }
        }
        
       
        
    }

    void StartMovie() {
        endrollmovie.enabled = true;
        _endroll.enabled = true;
        SkkipButton.SetActive(true);
    }

    void StartFadeOut() {
        Fade.enabled = true;  // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
        SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
        
    }

    void SetAlpha() {
        Fade.color = new Color(0, 0, 0, alfa);
    }

    IEnumerator GoToNextScene() {
        yield return new WaitForSeconds(5f);
        StartFadeOut();

        //�@1(6)�b�ԑ҂�
        yield return new WaitForSeconds(1f);
            StopCoroutine(endRollCoroutine);
            SceneManager.LoadScene("GameClear");

        yield return null;
    }

    IEnumerator GoToNextScenes() {
        //�@3�b�ԑ҂�
        yield return new WaitForSeconds(3f);
        endrollmovie.enabled = false;
        _endroll.enabled = false;
        SceneManager.LoadScene("GameClear");
     

        yield return null;
    }
}
