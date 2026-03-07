using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraSala : MonoBehaviour
{
    [SerializeField] private float rotationDuration = 2f;
    private float rotationAmount = 90f;
    private bool isRotating = false;
    private Rigidbody rb;
    
    public static PrimeraSala Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            //Aquel que reclama el trono no se destruye entre escenasField
            DontDestroyOnLoad(this.gameObject);
            rb = GetComponent<Rigidbody>();

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateSmoothly());
        }
    }

    IEnumerator RotateSmoothly()
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(rotationAmount, 0, 0);
        float time = 0;

        while (time < rotationDuration)
        {
            Quaternion newRotation = Quaternion.Lerp(startRotation, endRotation, time / rotationDuration);
            rb.MoveRotation(newRotation);
            time += Time.deltaTime;
            
            yield return null;
        }

        rb.MoveRotation(endRotation);
        isRotating = false;
    }
}
