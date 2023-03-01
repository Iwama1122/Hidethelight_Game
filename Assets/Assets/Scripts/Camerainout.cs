using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerainout : MonoBehaviour
{
   
   [SerializeField] private GameObject[] targetRenderer;
    int length;
    //�@�J�������ɂ��邩�ǂ���
    private bool isInsideCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < targetRenderer.Length; i++) {
            targetRenderer[i].SetActive(false);
        }
        length = targetRenderer.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInsideCamera == true) {
           
            for(int i = 0; i < targetRenderer.Length; i++) {
                targetRenderer[i].SetActive(true);
            }
        }
        else {
          
            for(int i = 0; i < targetRenderer.Length; i++) {
                targetRenderer[i].SetActive(false);
            }
        }
    }

    //�@�J��������O�ꂽ
    private void OnBecameInvisible() {
        isInsideCamera = false;
    }
    //�@�J�������ɓ�����
    private void OnBecameVisible() {
        isInsideCamera = true;
    }

}
