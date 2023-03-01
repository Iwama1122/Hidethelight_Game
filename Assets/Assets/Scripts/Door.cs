using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    //　ドアエリアに入っているかどうか
    private bool isNear;
    //　ドアのアニメーター
    private Animator animator;

    int doorcount = 0;//ドアの開閉カウント

    [SerializeField] private GameObject door;
    BoxCollider dobox;

    // Start is called before the first frame update
    void Start()
    {
        isNear = false;
        animator = transform.parent.GetComponent<Animator>();
        door = GameObject.Find("DoorModel");
        dobox = door.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Keyboard.current.rKey.wasReleasedThisFrame && isNear == true) {
         
            doorcount += 1;
            animator.SetBool("Open", true);
            dobox.isTrigger = false;
        }

        if(doorcount == 2) {
        
            animator.SetBool("Open", false);
            doorcount = 0;
      
        }

      
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            
            isNear = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
             isNear = false;
        }
    }
}
