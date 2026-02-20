using System;
using UnityEngine;

public class ComeAndBackPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 direccion;
    private Rigidbody rb;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direccion * 5; //Va medida en m/s
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
           direccion *= -1;
           timer = 0;
        }
    }
}
