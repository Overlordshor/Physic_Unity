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
        //Симуляция погружения в воду объекта на половину;
        //При условии, что вода находится ниже 0 по y;
        var divePercent = -transform.position.y + transform.localScale.y * 0.5f;

        //Ограничивает переменную от 0f до 1f;
        divePercent = Mathf.Clamp(divePercent, 0f, 1f);

        //Подъёмная сила * на плотность воды - чем больше плотность, тем больше вытакливание;
        _rigidbody.AddForce(Vector3.up * divePercent * _waterDensity);

        //Изменение сопртивиления объекта в другой среде;
        _rigidbody.drag = divePercent * 2f;
        _rigidbody.angularDrag = divePercent * 2f;
    }
}