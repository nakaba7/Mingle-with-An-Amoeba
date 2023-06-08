using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskChildrenEnable : MonoBehaviour
{
    void Start()
    {
        
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Return))
        {
            var renderer = gameObject.GetComponent<Renderer>();
            renderer.enabled = true;
        }
    }
}
