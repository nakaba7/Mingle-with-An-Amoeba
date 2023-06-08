using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallManager : MonoBehaviour
{
    private CollisionFlag flagclass;
    private bool flag;
    void Start()
    {
        flagclass = this.GetComponent<CollisionFlag>();
    }

    // Update is called once per frame
    void Update()
    {
        flag = flagclass.collisionFlag;
        if (flag)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
