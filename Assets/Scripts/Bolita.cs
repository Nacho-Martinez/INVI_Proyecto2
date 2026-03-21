using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]


public class Bolita : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float moveForce = 5f;
    [SerializeField] private Transform cameraTransfrom;
    
    [Header("Sats")] 
    [SerializeField]private int hp = 3;

    [SerializeField] private float maxTime = 200;
    

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip portal;

    [Header("Control")] 
    [SerializeField] private bool hastime;
    [SerializeField] private bool hashp;
    
    private Vector3 movementDirection;
    private Rigidbody rb;
    private Vector3 actualposition;
    private float offsetraycast = 0.1f;

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
      


    }

    private void Start()
    {
        if (hashp)
        {
            UIManager.Instance.ScoreText.SetText("Lives:" + hp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            float hInput = Input.GetAxisRaw("Horizontal");
            float vInput = Input.GetAxisRaw("Vertical");
            Vector3 forward = cameraTransfrom.forward;
            Vector3 right = cameraTransfrom.right;
            forward.Normalize();
            right.Normalize();
            movementDirection = (forward * vInput + right * hInput).normalized;
            Jump();

            if (hastime)
            {
                maxTime -= Time.deltaTime;
                UIManager.Instance.ScoreText.SetText("Time :" + maxTime);
                if (maxTime <= 0)
                {
                    SceneManager.LoadScene("Main Menu");
                    MenuManager.Instance.ShowLoseMenu();
                }
            }
        
        
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.AudioInstance.PlaySoud(jumpSound);
            //Se lanza un rayo para ver si estoy en suelo 
            if (Physics.Raycast(transform.localPosition, Vector3.down, transform.localScale.y + offsetraycast))
            {
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
        if (other.gameObject.CompareTag("BaseSegundoNivel")|| other.gameObject.CompareTag("Lvl2Tp"))
        {
            AudioManager.AudioInstance.PlaySoud(portal);
            gameObject.transform.position = new Vector3(28.62f,84.56f,-91.52f);
        }
        if (other.gameObject.CompareTag("ChangeLvl"))
        {
            AudioManager.AudioInstance.PlaySoud(portal);
            SceneManager.LoadScene("Scenes/SegundoNivel");
        }

        if (other.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene("Main Menu");
            MenuManager.Instance.ShowWinMenu();
        }
        
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BotonLaverinto"))
        {
            UIManager.Instance.InteractText.SetText("Presiona E");
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
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.TryGetComponent(out Bala bala))
        {
            hp--; 
            UIManager.Instance.ScoreText.SetText("Lives:" + hp);
            if (hp <= 0)
            {
                MenuManager.Instance.ShowLoseMenu();
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
