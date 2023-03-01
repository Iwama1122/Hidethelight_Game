using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.InputSystem;

public class ButterMove : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeTeaset;
    float time;

    [SerializeField] private GameObject pl;
    StarterAssets.ThirdPersonController st;
    //[SerializeField] private ParticleSystem d;
    [SerializeField] private GameObject d;
    float speed;
    bool efstop = false;
    [SerializeField] private GameObject ca;
    CameraController cas;
    [SerializeField] private GameObject ItemCount;
    hyoujisroto hyouji;
    [SerializeField] private GameObject ma;
    GameManager ga;
    [SerializeField] private GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        d.SetActive(false);
        //d.Stop();
        time = 0f;
        pl = GameObject.Find("PlayerArmature");
        st = pl.GetComponent<StarterAssets.ThirdPersonController>();
        ca = GameObject.Find("MainCamera");
        cas = ca.GetComponent<CameraController>();
        hyouji = ItemCount.GetComponent<hyoujisroto>();
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
        targets = GameObject.FindGameObjectsWithTag("teatool");
        float closeDist = 1000;//�����̋߂�

        foreach(GameObject target in targets) {
            float tDist = Vector3.Distance(transform.position, target.transform.position);//�A���X�Ƃ�������̋����v��

            //if(closeDist > tDist) {
                closeDist = tDist;
                closeTeaset = target;
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�����ɃX���b�g�őI�΂�Ă������if�������
        if(ga.START == true) {
            if(cas.STOP == false) {
                //�����ɃX���b�g�őI�΂�Ă������if��������
                if(hyouji.COUNT == 2) {
                    if(Gamepad.current.buttonSouth.wasReleasedThisFrame && st.DRINK != 0) {
                        arrow.SetActive(true);
                        st.DRINK--;
                        d.SetActive(true);
                        efstop = true;
                   }
                }
            if(efstop == true) {
            time+= Time.deltaTime;
            speed = 0.05f;
            d.transform.position = Vector3.MoveTowards(d.transform.position, closeTeaset.transform.position, speed);
            Vector3 vector3 = closeTeaset.transform.position - this.transform.position;
            vector3.y = 0f;

            Quaternion quaternion = Quaternion.LookRotation(vector3);//��]�l�擾
            d.transform.rotation = quaternion;

            if(time >=10f) {//�{����10�b�Ŏ~�߂邩��X�s�[�h�v����//d.transform.position == closeTeaset.transform.position
                            speed = 0f;
                            d.SetActive(false);
                            arrow.SetActive(false);
                efstop = false;
                            time = 0;
            }
        }
      
      }
     }
    }
}
