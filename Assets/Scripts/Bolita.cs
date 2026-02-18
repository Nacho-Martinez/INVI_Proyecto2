using System;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float moveForce = 5f;
    private Vector3 movementDirection;
    private Rigidbody rb;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tomar la lectura de los imputs WASD y/0 flechas.
        //Aplicar una fuerza continua hacia donde indiquen los inputs
        //para poder mover la bola.

        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(hInput, 0, vInput).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
     
    //Para ejecutar fisicas cuyo cálculo sea acumulable en el tiempo
    private void FixedUpdate() //Cada 0.02 segundos
    {
        rb.AddForce(movementDirection*moveForce,ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other) //Cuando de produce un evento de trigger (atravesar)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) //Se produce una colision (un choque)
    {
        if (other.gameObject.CompareTag("DestructibleBloque"))
        {
            Destroy(other.gameObject);
        }
    }
}
