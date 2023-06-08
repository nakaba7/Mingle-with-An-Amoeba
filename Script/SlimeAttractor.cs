using System;
using UnityEngine;

public class SlimeAttractor : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    public float attractPower = 1.0f;

    private void Start()
    {
        // 子のRigidbodyをすべて取得
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        var massCenter = Vector3.zero;
        foreach (var rb in _rigidbodies)
        {
            massCenter += rb.position;
        }

        massCenter /= _rigidbodies.Length;

        foreach (var rb in _rigidbodies)
        {
            var force = (massCenter - rb.position).normalized * attractPower;
            rb.AddForce(force);
        }
    }
}