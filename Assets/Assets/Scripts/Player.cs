using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    Quaternion targetRotation;

    private void Awake()
    {
        //コンポーネント関連付け
       // animator = GetComponent<Animator>();
       TryGetComponent(out animator);

        //初期化
        targetRotation = transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        //入力ベクトル
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var velocity = new Vector3(horizontal,0,vertical).normalized;
        var speed = Input.GetKeyDown(KeyCode.LeftShift) ? 2: 1;
        var rotationSpeed = 600 * Time.deltaTime;

        //移動方向を向く
        if(velocity.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(velocity,Vector3.up);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed);

        //移動速度をAnimatorに反映
        animator.SetFloat("Speed",velocity.magnitude * speed,0.1f,Time.deltaTime);
    }
}
