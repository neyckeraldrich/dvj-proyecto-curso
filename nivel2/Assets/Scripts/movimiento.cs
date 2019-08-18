using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right")) {
            if (GetComponent<SpriteRenderer>().flipX == true) {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.Translate(0.02f,0,0);
        }
        if (Input.GetKey("left")) {
            if (GetComponent<SpriteRenderer>().flipX==false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(-0.02f,0,0);
        }
        

    }
}
