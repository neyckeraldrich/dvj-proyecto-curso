using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayVerticalPlatform : MonoBehaviour
{

    private PlatformEffector2D effector2D;
    public float waitTime = 0.5f;

    private float remainingWaitTime;
    private bool touchingPlayer;


    void Start()
    {
        effector2D = gameObject.GetComponent<PlatformEffector2D>();
        //Debug.Log(gameObject.name);
        remainingWaitTime = waitTime;
        touchingPlayer = false;
    }

    void Update()
    {
        if (Input.GetButtonUp("Crouch"))
        {
            remainingWaitTime = waitTime;
        }

        if (Input.GetButton("Crouch") && touchingPlayer)
        {
            if (remainingWaitTime <= 0f)
            {
                effector2D.rotationalOffset = 180f;
                remainingWaitTime = waitTime;
            }
            else
            {
                remainingWaitTime -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            effector2D.rotationalOffset = 0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name.Equals("Player"))
        {
            touchingPlayer = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name.Equals("Player"))
        {
            touchingPlayer = false;
        }
    }
}
