using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCommon : MonoBehaviour
{
    public string sceneTheme;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(sceneTheme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
