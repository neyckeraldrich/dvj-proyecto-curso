﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag =="Player")
        {
//            Application.LoadLevel(4);
                SceneManager.LoadScene(2,LoadSceneMode.Single);
        }
    }

    
}
