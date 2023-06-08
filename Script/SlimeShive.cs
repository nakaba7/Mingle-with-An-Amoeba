using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlimeShive : MonoBehaviour
{
    public float amp = 0.001f;
    public float frequency = 100.0f;
    private Vector3 originalScale;
    private bool collisionFlag;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            collisionFlag = true;
        }
    }
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionFlag)
        {
            //Vector3 size = this.transform.localScale;
            float f = Mathf.Sin(Time.time * frequency) * amp;
            Vector3 delta = new Vector3(f, f, f);
            transform.localScale += delta;
            collisionFlag = false;
        }
        else
        {
            transform.localScale = originalScale;
        }
        
    }
}
