using Unity.VisualScripting;
using UnityEngine;

public class Wheel : MonoBehaviour
{   
    [SerializeField] public Transform _wheelMash;
    [SerializeField] public WheelCollider _wheelCollider;
    [SerializeField] public bool _isForvord;

    public void Update()
    {
        Vector3 position;
        Quaternion rotation;

        _wheelCollider.GetWorldPose(out position, out rotation);

        _wheelMash.position = position; 
        _wheelMash.rotation = rotation;
    }
}
