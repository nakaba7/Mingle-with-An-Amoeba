using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravity : MonoBehaviour
//attach this C# script to all slimeBall 
{
    Rigidbody rb;
    public float CONST_G = 0.03f;
    static List<UniversalGravity> ug_obs = new List<UniversalGravity>();
    // Start is called before the first frame update
    void Start()
    {
        //add slimeBall to list
        //gameObject.AddComponent<Rigidbody>();
        rb = gameObject.GetComponent<Rigidbody>();
        ug_obs.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        //add universal gravity force to slimeBall in list
        var p0 = rb.position;

        foreach(var obj in ug_obs)
        {
            var trb = obj.GetComponent<Rigidbody>();
            var q0 = trb.position;
            var pmq = p0 - q0;

            var F = - CONST_G * rb.mass * trb.mass * pmq * Mathf.Pow(pmq.magnitude, 3);
            rb.AddForce(F, ForceMode.Impulse);
        }
    }
}