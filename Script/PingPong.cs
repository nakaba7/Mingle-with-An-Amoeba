using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PingPong : MonoBehaviour
{
    private float nowPosiX;
    private float nowPosiY;
    private float nowPosiZ;
    
    private SlimeRenderer slimeRenderer;
    private bool standardPosFlag;
    private bool moveFlag;
    private bool invokeFlag;
    private int rand;
    public float amp = 0.004f;
    void Start()
    {
        slimeRenderer = GameObject.Find("Slime").GetComponent<SlimeRenderer>();
        standardPosFlag = false;
        moveFlag = false;
        invokeFlag = false;
        rand = Random.Range(100, 200 + 1);
        Invoke("PosSet", 5.0f);
    }
    private void PosSet()
    {
        nowPosiX = this.transform.position.x;
        nowPosiY = this.transform.position.y;
        nowPosiZ = this.transform.position.z;
        invokeFlag = true;
        moveFlag = true;
    }

    private void Update()
    {
       
        if (!(moveFlag) && !(slimeRenderer.emotionFlag))
        {
            if (invokeFlag) {
                invokeFlag = false;
                Invoke("PosSet", 3.0f);
            }
        }
        if (slimeRenderer.emotionFlag)
        {
            moveFlag = false;
        }
        if(moveFlag)transform.position = new Vector3(nowPosiX + Mathf.PingPong(Time.time / rand, amp) , nowPosiY + Mathf.PingPong(Time.time / rand, amp), nowPosiZ + Mathf.PingPong(Time.time / rand, amp));
        //Debug.Log(moveFlag);

    }


}
