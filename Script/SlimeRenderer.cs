using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public enum EyeCondition
{
    Blink,
    Close,
    Surprised,
}

[ExecuteAlways] 
public class SlimeRenderer : MonoBehaviour
{
    [SerializeField] private Material material;

    private const int MaxSphereCount = 256; 
    private readonly Vector4[] _spheres = new Vector4[MaxSphereCount];
    private SphereCollider[] _colliders;
    private CollisionFlag[] _collisionFlagList;
    private Vector4[] _basecolors = new Vector4[MaxSphereCount];
    public float k = 120f;
    private float red = 0.0f;
    private float green = 1.0f;
    private float blue = 0.0f;
    public float redChangeRate = 0.005f;
    public float greenChangeRate = 0.005f;
    public float blueChangeRate = 0.005f;
    private Vector4[,] metaBallGroup = new Vector4[10,10];
    private Transform[] _sphereTrans;
    public int randcount;
    private GameObject eyeObj;
    public EyeCondition alleyeCondition;
    public int eyeDeleteTime = 300;
    public Vector4 baseColor;
    public bool emotionFlag;
    private static float rand;
    private bool[] collisionFlags;
    private List<bool> collisionFlagList;
    private int ListSize;

    //private Rigidbody[] _rigidbodies;
    //public List<Rigidbody> slimeRbList;
   
   
    private void EyeBlinkColor()
    {
        if (red > 0) red -= redChangeRate;
        if (green < 1) green += greenChangeRate;
        if (blue > 0) blue -= blueChangeRate;
    }
    private void EyeCloseColor()
    {
        if(red > 0) red -= redChangeRate;
        if (green > 0) green -= greenChangeRate;
        if (blue < 1) blue += blueChangeRate;
    }
    private void EyeSurprisedColor()
    {
        if (red < 1) red += redChangeRate;
        if (green < 1) green += greenChangeRate;
        if (blue > 0) blue -= blueChangeRate;
    }
    private void EyeCrossColor()
    {
        if (red < 1) red += redChangeRate;
        if (green > 0) green -= greenChangeRate;
        if (blue > 0) blue -= blueChangeRate;
    }


    
    private void Start()
    {
        _colliders = GetComponentsInChildren<SphereCollider>();
        rand = Random.Range(0.1f, 9.9f);
        _sphereTrans = GetComponentsInChildren<Transform>();
        randcount = 0;
        material.SetInt("_SphereCount", _colliders.Length);
        material.SetFloat("_k", k);
        baseColor = new Vector4(red, green, blue,0.5f);
        _collisionFlagList = GetComponentsInChildren<CollisionFlag>();
        collisionFlagList = new List<bool>();

        //_rigidbodies = GetComponentsInChildren<Rigidbody>();
        //slimeRbList = new List<Rigidbody>(_rigidbodies);

    }

    private void Update()
    {
        //_rigidbodies = GetComponentsInChildren<Rigidbody>();
        //slimeRbList = new List<Rigidbody>(_rigidbodies);
        randcount++;
        _colliders = GetComponentsInChildren<SphereCollider>();
        material.SetInt("_SphereCount", _colliders.Length);

        for (var i = 0; i < _colliders.Length; i++)
        {
            var col = _colliders[i];
            //var flag = _collisionFlagList[i].collisionFlag;
            if (emotionFlag)
            {
                if (rand > 5)
                {
                    alleyeCondition = EyeCondition.Close;
                    EyeCloseColor();
                    randcount = 0;

                }
                else if (rand <= 5)
                {
                    alleyeCondition = EyeCondition.Surprised;
                    EyeSurprisedColor();
                    randcount = 0;
                }
            }
            else
            {
                alleyeCondition = EyeCondition.Blink;
                EyeBlinkColor();
                if(randcount > 10)
                {
                    rand = Random.Range(0.1f, 9.9f);
                    randcount = 0;
                }
            }
            //emotionFlag = false;
            var t = col.transform;
            var center = t.position;
            var radius = t.lossyScale.x * col.radius;
           
            _spheres[i] = new Vector4(center.x, center.y, center.z, radius);
            baseColor = new Vector4(red, green, blue, 0.5f);
            _basecolors[i] = baseColor;
        }
        emotionFlag = false;
        material.SetVector("baseColor", baseColor);
        material.SetVectorArray("_Spheres", _spheres);
        
        //Debug.Log(emotionFlag);
        //Debug.Log(rand);
        //emotionFlag = false;
    }
}