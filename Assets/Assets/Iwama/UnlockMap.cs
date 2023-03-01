using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class UnlockMap : MonoBehaviour
{
    [SerializeField] private GameObject Area;
    [SerializeField] private GameObject AllArea;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject sousa;
    [SerializeField] private Text gaitoutext;
    bool lights = false;
    bool terasu = false;
    public bool TERASU 
    {
        set 
        {
            this.terasu = value;
        }
        get
        {
            return this.terasu;
        }
    }
   
    void Start()
    {
        AllArea.SetActive(false);
        Light.SetActive(false);
        sousa.SetActive(false);
        gaitoutext.text = " "; 
    }
    private void Update() 
    {
            
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" && lights == false)
        {
            sousa.SetActive(true);
            gaitoutext.text = "  �Ŗ�����𓔂�";

            if (Gamepad.current.buttonNorth.isPressed)
           {  
                Light.SetActive(true);
                AllArea.SetActive(true);
                Area.layer = 6;//�~�j�}�b�v�ŕ\��������G���A�p�̃��C���[�ԍ�
                
                //�n�ʈȊO���~�j�}�b�v�ŕ\�����������ꍇ
                for(int index = 0; index < Area.transform.childCount; index++) 
                {
                    GameObject child = Area.transform.GetChild(index).gameObject;
                    child.layer = 7; 
                }
                lights = true;
                terasu = true;
            }
        }
    }
    private void OnTriggerExit(Collider col) 
    {
        if(col.tag == "Player") 
        {
            sousa.SetActive(false);
            gaitoutext.text = " ";
        } 
    }
}

