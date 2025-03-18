 using UnityEngine;

public class InputServis : MonoBehaviour
{
    public Vector3 Direction { get; set; } 
    void Update()
    {
        Direction = new Vector3(Input.GetAxis("Horizontal"),0,  Input.GetAxis("Vertical"));
    }
}
