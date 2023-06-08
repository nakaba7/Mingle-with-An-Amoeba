using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLocation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject leftHandPos;
    [SerializeField] private GameObject slime;
    private bool checkFlag;
    private Vector3 deskPos;
    public float offset = 0.6f;
   

    void Start()
    {
        checkFlag = false;
        //this.gameObject.SetActive(false);
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;
        //slime = GameObject.Find("Slime");
    }

    // Update is called once per frame
    void Update()
    {
        deskPos = this.gameObject.transform.position;

        deskPos.y = leftHandPos.transform.position.y - offset;

        this.gameObject.transform.position = deskPos;


        if (Input.GetKey(KeyCode.Return))
        {
            var renderer = gameObject.GetComponent<Renderer>();
            renderer.enabled = true;
            //slime.SetActive(true);
            //this.gameObject.SetActive(true);
            this.enabled = false;
        }
    }
}
