using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandPosition : MonoBehaviour
{
    [SerializeField] private int xRotation;
    [SerializeField] private int yRotation;
    [SerializeField] private int zRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Right Hand : " + this.gameObject.transform.position);
        //Debug.Log("Right Hand Rotation ("+ this.gameObject.transform.localEulerAngles.x+" ,"+ this.gameObject.transform.localEulerAngles.y+" ,"+ this.gameObject.transform.localEulerAngles.z+")");
        this.gameObject.transform.position = new Vector3(0, 0, 0);
        //this.transform.rotation = Quaternion.Euler(this.gameObject.transform.localEulerAngles.x + xRotation, this.gameObject.transform.localEulerAngles.y + yRotation, this.gameObject.transform.localEulerAngles.z + zRotation);
    }
}
