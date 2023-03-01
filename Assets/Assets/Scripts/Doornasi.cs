using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doornasi : MonoBehaviour
{
    [SerializeField] private GameObject door;
    BoxCollider dobox;
    [SerializeField] private GameObject player;
    StarterAssets.ThirdPersonController pl;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("DoorModel");
        dobox = door.GetComponent<BoxCollider>();
        player = GameObject.Find("PlayerArmature");
        pl = player.GetComponent<StarterAssets.ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pl.DOA == true) {
            dobox.isTrigger = true;
        } else {
            dobox.isTrigger = false;
        }
    }
}
