using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttractor : MonoBehaviour
{
    Rigidbody virtualRb;
    public float CONST_G = 0.10f;
    //static List<HandAttractor> slimeObjList = new List<HandAttractor>();
    private GameObject parentSlime;
    private SlimeRenderer slimeRenderer;
    private List<Rigidbody> slimeObjList;
    // Start is called before the first frame update
    void Start()
    {
        //add slimeBall to list
        //gameObject.AddComponent<Rigidbody>();
        virtualRb = gameObject.GetComponent<Rigidbody>();
        parentSlime = GameObject.Find("Slime");
        slimeRenderer = parentSlime.GetComponent<SlimeRenderer>();
        //slimeObjList = slimeRenderer.slimeRbList;
        //slimeObjList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        //virtualRb = gameObject.GetComponent<Rigidbody>();
        //slimeObjList = slimeRenderer.slimeRbList;
        //add universal gravity force to slimeBall in list
        var p0 = virtualRb.position;

        foreach (var trb in slimeObjList)
        {
            //var trb = obj;
            var q0 = trb.position;
            var pmq = p0 - q0;

            var F = -CONST_G * virtualRb.mass * trb.mass * pmq * Mathf.Pow(pmq.magnitude, 3);
            trb.AddForce(F, ForceMode.Impulse);
        }
    }
}
