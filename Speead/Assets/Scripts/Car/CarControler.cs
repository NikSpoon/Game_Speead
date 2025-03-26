using UnityEngine;

public class CarControler : MonoBehaviour 
{
    [SerializeField] private Wheel[] _wheels;
    [SerializeField] private InputServis _inputServis;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private int _motorForse;

    private float _vertocalInput;
    private float _horizontalInput;
    [SerializeField] private int _whelsAngle;
    [SerializeField] private float _speed;

    void Update()
    {
        Move();
    }

    private void Move()
    {

        _speed = _rb.linearVelocity.magnitude;

        _horizontalInput = _inputServis.horizontalInput;
        _vertocalInput = _inputServis.verticalInput;

        foreach (Wheel wheel in _wheels)
        {
            wheel._wheelCollider.motorTorque = _vertocalInput * _motorForse;
            
        }
    }
    
    private void Steeting()
    {
        float streetingAngle = _horizontalInput * _whelsAngle;
        foreach (Wheel wheel in _wheels)
        {
            if (wheel._isForvord)
            {

            }

        }
    }
 
}
