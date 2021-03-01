using UnityEngine;

//Корректная установка центр массы;
public class CentrOfMass : MonoBehaviour
{
    [SerializeField] private Transform _centrOfMass;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.Scale(_centrOfMass.localScale, _centrOfMass.localPosition);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
    }
}