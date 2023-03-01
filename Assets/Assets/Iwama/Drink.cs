using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drink: MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeTeaset;
    public GameObject guide;//�ǉ�
    public GameObject icon;//�ǉ�

    float time;
    
    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController st;
   
    void Start()
    {
        
       
        time = 0f;
        pl = GameObject.Find("PlayerArmature");
        st = pl.GetComponent<StarterAssets.ThirdPersonController>();

            targets = GameObject.FindGameObjectsWithTag("teatool");
            float closeDist = 1000;//�����̋߂�

            foreach (GameObject target in targets)
            {
                float tDist = Vector3.Distance(transform.position, target.transform.position);//�A���X�Ƃ�������̋����v��

                if (closeDist > tDist)
                {
                    closeDist = tDist;
                    closeTeaset = target;
                }
            }
    }
    void Update()
    {
       
        
            time += Time.deltaTime;
           
            Vector3 vector3 = closeTeaset.transform.position - this.transform.position;
            vector3.y = 0f;

             Quaternion quaternion = Quaternion.LookRotation(vector3);//��]�l�擾
             this.transform.rotation = quaternion;
           
        
        if (time >= 10)
        {
            
            this.gameObject.SetActive(false);
            st.DRINK--;
            time = 0;
        }
        
    }
}