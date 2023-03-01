using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rawidou : MonoBehaviour
{
    Vector3 mytranscopy;
    public Vector3 MYTRANS {
        set {
            this.mytranscopy = value;
        }
        get {
            return this.mytranscopy;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        mytranscopy = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float y = this.transform.position.y;
        
        if(y < 700f) {
            transform.position += transform.up * Time.deltaTime * 100;

        }
        if(y > 700f) {
            mytranscopy = this.transform.position;
           

        }
        
    }
}
