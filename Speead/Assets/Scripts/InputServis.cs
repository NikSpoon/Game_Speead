 using UnityEngine;

public class InputServis : MonoBehaviour
{
    public Vector3 Direction { get; set; } 
    public float verticalInput { get; set; }
    public float horizontalInput { get; set; }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Direction = new Vector3(verticalInput, 0, horizontalInput);
    }
}
