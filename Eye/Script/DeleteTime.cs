using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DeleteTime : MonoBehaviour
{
    //public float deleteTime = 1.0f;
    private int count = 0;
    GameObject slimeRenderer;
    private int deleteCount;
    private GameObject eyeObject;
 
    void Start()
    {
        //gameObject.SetActive(false);
        //eyeObject = GameObject.Find("NewAnimeEye");
      //this.gameObject.SetActive(false);
        slimeRenderer = GameObject.Find("Slime");
        deleteCount = slimeRenderer.GetComponent<SlimeRenderer>().eyeDeleteTime;
    }
    void Update(){
        count++;
        if(count > deleteCount){
            this.gameObject.SetActive(false);
            count = 0;
        }
    }
}