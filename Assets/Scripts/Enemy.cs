using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public void OnHit()
    {
        _rigidbody.AddForce(Vector3.up * 1000f);
        _rigidbody.AddRelativeTorque(800f, 0f, 0f);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}