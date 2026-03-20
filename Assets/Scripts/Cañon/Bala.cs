using System;
using UnityEngine;
using UnityEngine.Pool;

public class Bala : MonoBehaviour
{
    public ObjectPool<Bala> MyPool { get; set; }

    [SerializeField] private float bulletForce = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public void Shoot(Vector3 direction)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(direction * bulletForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Final"))
        {
            MyPool.Release(this);
        }
    }
}
