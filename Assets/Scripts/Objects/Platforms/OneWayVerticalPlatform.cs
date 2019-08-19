using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayVerticalPlatform : MonoBehaviour
{

    private PlatformEffector2D effector2D;
    public float waitTime = 0.5f;

    private float remainingWaitTime;

    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
        remainingWaitTime = waitTime;
    }

    void Update()
    {
        if (Input.GetButtonUp("Crouch"))
        {
            remainingWaitTime = waitTime;
        }

        if (Input.GetButton("Crouch"))
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
}
