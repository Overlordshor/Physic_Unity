using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotateSpeed = 2f;
    private Rigidbody _rigidbody;
    private Vector3 _moveForward;
    private Vector3 _rotateForce;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * _rotateSpeed;
        var vertical = Input.GetAxis("Vertical") * _speed;
        _moveForward = new Vector3(0f, 0f, vertical);
        _rotateForce = new Vector3(0f, horizontal, 0f);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddRelativeForce(_moveForward);
        _rigidbody.AddRelativeTorque(_rotateForce);
    }
}