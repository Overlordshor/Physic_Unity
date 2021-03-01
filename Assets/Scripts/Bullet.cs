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
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.OnHit();
            }
            Head head = collision.collider.GetComponent<Head>();
            if (head)
            {
                Debug.Log(head + "SHOT");
            }

            _isActive = false;
        }
    }
}