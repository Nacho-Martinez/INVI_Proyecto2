using UnityEngine;

public class RotateCilinder : MonoBehaviour
{
    [SerializeField] private float ForceRotation;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.up *ForceRotation , ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
