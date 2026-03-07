using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]


public class Bolita : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float moveForce = 5f;
    
    [Header("Checkers")]
    [SerializeField] private LayerMask whatIsInteractable;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    
    
    // [SerializeField] private AudioClip jumpSound;
    private Vector3 movementDirection;
    private Rigidbody rb;
    private Vector3 actualposition;
    private float offsetraycast = 0.1f;
    // private AudioSource _audioSource;
    private int score = 0;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
      // _audioSource= GetComponent<AudioSource>();


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
        
        Interact();
        Jump();
    }

    private void Interact()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     
        // }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.AudioInstance.PlaySoud(jumpSound);
            //Se lanza un rayo para ver si estoy en suelo 
            if (Physics.Raycast(transform.localPosition, Vector3.down, transform.localScale.y + offsetraycast))
            {
                // _audioSource.clip = jumpSound;
                // _audioSource.Play();
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    //Para ejecutar fisicas cuyo cálculo sea acumulable en el tiempo
    private void FixedUpdate() //Cada 0.02 segundos
    {
        rb.AddForce(movementDirection*moveForce,ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other) //Cuando de produce un evento de trigger (atravesar)
    {
        if (other.gameObject.TryGetComponent(out Coin coinScript))
        {
            score += coinScript.CoinScore;
           UIManager.Instance.ScoreText.SetText("Score: " + score);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BotonLaverinto"))
        {
            UIManager.Instance.InteractText.SetText("Presiona E");
            // transform.SetParent(other.gameObject.transform);
            if (Input.GetKeyDown(KeyCode.E))
            {
            PrimeraSala.Instance.Rotate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BotonLaverinto"))
        {
            UIManager.Instance.InteractText.SetText("");
            // transform.SetParent(null);
        }
    }
}
