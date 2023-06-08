using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFlag : MonoBehaviour
{
    public bool collisionFlag;
    private bool isContinious;
    private CollisionFlag[] allFlag;
    private GameObject parentSlime;
    private SlimeRenderer slimeRenderer;
    private bool handcollisionFlag;
    void Start()
    {
        collisionFlag = false;
        parentSlime = GameObject.Find("Slime");
        slimeRenderer = parentSlime.GetComponent<SlimeRenderer>();
        //allFlag = this.GetComponentsInChildren<CollisionFlag>();

    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            //handcollisionFlag = true;
            
            collisionFlag = true;
            slimeRenderer.emotionFlag = true;
        }
        else //if(collision.gameObject.tag == "Ground")
        {
            //handcollisionFlag = false;
            collisionFlag = false;
            //slimeRenderer.falsecount++;
        }
    }

   
    /*private void Update()
    {
        if (handcollisionFlag)
        {
            collisionFlag = true;
            slimeRenderer.emotionFlag = true;
            //Debug.Log(this.gameObject.name);
        }
        else
        {
            collisionFlag = false;
        }

    }*/
}
