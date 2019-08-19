using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Events : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
