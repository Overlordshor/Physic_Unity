using UnityEngine;

public class WaterSimulation : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _waterDensity = 10f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var divePercent = -transform.position.y + transform.localScale.y * 0.5f;
        divePercent = Mathf.Clamp(divePercent, 0f, 1f);

        _rigidbody.AddForce(Vector3.up * divePercent * _waterDensity);
        _rigidbody.drag = divePercent * 2f;
        _rigidbody.angularDrag = divePercent * 2f;
    }
}