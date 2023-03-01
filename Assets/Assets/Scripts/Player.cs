using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    Quaternion targetRotation;

    private void Awake()
    {
        //�R���|�[�l���g�֘A�t��
       // animator = GetComponent<Animator>();
       TryGetComponent(out animator);

        //������
        targetRotation = transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        //���̓x�N�g��
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var velocity = new Vector3(horizontal,0,vertical).normalized;
        var speed = Input.GetKeyDown(KeyCode.LeftShift) ? 2: 1;
        var rotationSpeed = 600 * Time.deltaTime;

        //�ړ�����������
        if(velocity.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(velocity,Vector3.up);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed);

        //�ړ����x��Animator�ɔ��f
        animator.SetFloat("Speed",velocity.magnitude * speed,0.1f,Time.deltaTime);
    }
}
