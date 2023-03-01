using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public float speed;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //speed = 0.05f;
        //target = GameObject.Find("P");
        offset = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = target.transform.position + offset;
        //transform.LookAt(target.transform);
        //float x = this.transform
        //transform.position += transform.right * speed;
    }
}
