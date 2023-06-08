using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCount : MonoBehaviour
{
    private CollisionFlag[] _collisionFlagList;
    private List<bool> collisionFlagList;
    private int trueCount;
    private SlimeRenderer slimeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _collisionFlagList = GetComponentsInChildren<CollisionFlag>();
        slimeRenderer = gameObject.GetComponent<SlimeRenderer>();
        //collisionFlagList = new List<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        trueCount = 0;
        collisionFlagList = new List<bool>();
        foreach (var flag in _collisionFlagList)
        {
            Debug.Log("flag " + flag.collisionFlag);
            if (flag.collisionFlag) trueCount++;
        }
        Debug.Log(trueCount);
        if (trueCount == 3) slimeRenderer.emotionFlag = false;
    }
}
