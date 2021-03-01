using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Action OnHit;
    private Rigidbody _rigidbody;
    private bool _isActive = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isActive)
        {
            _rigidbody.useGravity = true;
            Debug.Log(collision.gameObject.name);
            _isActive = false;
        }
    }
}