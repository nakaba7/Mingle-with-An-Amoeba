using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandScaleManager : MonoBehaviour
{
    public float amp = 0.0f;
    public float frequency = 100.0f;
    private Vector3 originalSize;
    // Start is called before the first frame update

    public void ResetSize()
    {
        this.transform.localScale = originalSize;
    }
    void Start()
    {
        originalSize = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 size = this.transform.localScale;
        float f = Mathf.Sin(Time.time*frequency) * amp;
        Vector3 delta = new Vector3(f, f, f);
        this.transform.localScale += delta;
    }
}