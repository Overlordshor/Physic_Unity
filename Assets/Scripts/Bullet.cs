using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _markPrefab;
    private Rigidbody _rigidbody;
    private bool _isActive = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isActive)
        {
            _rigidbody.useGravity = true;
            Debug.Log(collision.gameObject.name);

            OnHitGameObject(collision);

            _isActive = false;
        }
    }

    private void OnHitGameObject(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.OnHit();
            Head head = collision.collider.GetComponent<Head>();
            if (head)
            {
                Debug.Log(head + "SHOT");
            }
        }
        else
        {
            AddMark(collision);
        }
    }

    private void AddMark(Collision collision)
    {
        // Позиция первого контакта;
        var positionMark = collision.contacts[0].point;
        // Поворот метки. Получаем кватернион из вектора поверхности (нормали);
        var rotationMark = Quaternion.LookRotation(collision.contacts[0].normal);
        Instantiate(_markPrefab, positionMark, rotationMark, collision.transform);
    }
}