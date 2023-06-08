using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderChanger : MonoBehaviour
{
    public SkinnedMeshRenderer meshRenderer;
    public MeshCollider collider;
    public float newamp = 0.03f;
    //GameObject handparent;
    HandScaleManager scaleChanger;
    SlimeRenderer slimeRenderer;
    private bool collisionflag;
    [SerializeField] private GameObject dummmyHand;
    private int eyeCreateCount;
    [SerializeField] private GameObject eyeObject;
    private bool eyeCreateFlag;
    private GameObject parentSlime;
    //private int eyeDeleteTime;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Slime")
        {
            if (eyeCreateCount > 100 && !(eyeCreateFlag))
            {
                GameObject newEye = Instantiate(eyeObject, collision.gameObject.transform) as GameObject;
                newEye.transform.parent = parentSlime.transform;
                newEye.SetActive(true);
                //collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);//ÚG‚µ‚½ƒXƒ‰ƒCƒ€—±q‚Ì‚ÂEye‚ğActive‚É‚·‚é
                eyeCreateCount = 0;
            }
            collisionflag = true;
        }
        if (collision.gameObject.tag == "Eye") eyeCreateFlag = true;
    }
    void Start()
    {
       //handparent = transform.parent.gameObject;
       scaleChanger = dummmyHand.GetComponent<HandScaleManager>();
        eyeCreateCount = 0;
        eyeCreateFlag = false;
        parentSlime = GameObject.Find("Slime");
        //eyeDeleteTime = parentSlime.GetComponent<SlimeRenderer>().eyeDeleteTime;
    }

    // Update is called once per frame
    void Update()
    {
        eyeCreateCount++;
        //ObiDistanceField obiDF = new ObiDistanceField();
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        collider.sharedMesh = null;
        collider.sharedMesh = colliderMesh;
        if (collisionflag)
        {
            scaleChanger.amp = newamp;
            collisionflag = false;
        }
        else
        {
            scaleChanger.ResetSize();
            scaleChanger.amp = 0.0f;
        }
        eyeCreateFlag = false;

    }
}
