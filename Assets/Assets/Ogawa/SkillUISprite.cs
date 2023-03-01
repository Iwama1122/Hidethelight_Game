using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUISprite : MonoBehaviour
{
    //�A�C�e����ێ����Ă��邩�̃t���O
    private bool Mushroom = false;
    private bool WhiteRose = false;
    public GameObject skill1;
    public GameObject skill2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Use();

        if(Input.GetKey(KeyCode.Q)){
            Mushroom = true;
        }
        else if (Input.GetKey(KeyCode.W)){
            WhiteRose = true;
        }

        ChangeImage();
        
    }

    void Use()
    {
        //�A�C�e���g�p���̃A�N�V�����͖�����
        if (Input.GetKey(KeyCode.E) && WhiteRose){
            WhiteRose = false;
        }

        if (Input.GetKey(KeyCode.R) && Mushroom){
            Mushroom = false;
        }
    }

    //�A�C�e���������Ă��邩���Ȃ����ŃA�C�R���𖾖ł�����
    void ChangeImage()
    {
        if (WhiteRose){
            skill1.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else if (!WhiteRose){
            skill1.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
        }
        if (Mushroom){
            skill2.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        else if (!Mushroom){
            skill2.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
        }
    }
}
