using UnityEngine;

public class CarControler : MonoBehaviour 
{
    [SerializeField] private Wheel[] _wheels;
    [SerializeField] private InputServis _inputServis;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _centreOfMass;
    [SerializeField] private AnimationCurve _steeringCuve;
    [SerializeField] private Transform _Car;

    private float _vertocalInput;
    private float _horizontalInput;
    private float _brakeForvordWheel = 0.7f;
    private float _brakeRoadWheel = 0.3f;

    [SerializeField] private float _brakeInput;
    [SerializeField] private float _speed;

    [SerializeField] private int _brakeForse;
    [SerializeField] private int _motorForse;
    [SerializeField] private int _whelsAngleMax = 50;
    
    
    [SerializeField] float movingDorection;
    private void Start()
    {
        _rb.centerOfMass = _centreOfMass.position;
    }
    void Update()
    {
        Move();
        Steeting();
        Brake();
        CheckDirection();

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
        float steeringAngle = _horizontalInput * _steeringCuve.Evaluate(_speed);
        float slipAngle = Vector3.Angle(_Car.forward, _rb.linearVelocity - _Car.forward);

        if (slipAngle < 120)
            steeringAngle += Vector3.SignedAngle(_Car.forward, _rb.linearVelocity, Vector3.up);

        steeringAngle = Mathf.Clamp(steeringAngle, -_whelsAngleMax, _whelsAngleMax);

        foreach (Wheel wheel in _wheels)
        {
            if (wheel._isForvord)
            {
                wheel._wheelCollider.steerAngle = steeringAngle;
            }

        }
    }
 
    private void Brake()
    {
        foreach (Wheel wheel in _wheels)
        {
            wheel._wheelCollider.brakeTorque = _brakeInput * _brakeForse * (wheel._isForvord ? _brakeForvordWheel : _brakeRoadWheel);
            
        }
    }

    private void CheckDirection()
    {
        movingDorection = Vector3.Dot(_Car.forward, _rb.linearVelocity);
        _brakeInput = ((movingDorection < -0.5f && _vertocalInput > 0) || (movingDorection > 0.5f && _vertocalInput < 0)) ? Mathf.Abs(_vertocalInput):0 ;
        
    }
}
