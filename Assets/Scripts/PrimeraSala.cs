using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PrimeraSala : MonoBehaviour
{
    [SerializeField] private float rotationDuration = 2f;
    [SerializeField] private CinemachineCamera mainCamera;
    [SerializeField] private CinemachineCamera rotationCamera;
    [SerializeField]  private AudioClip gearSound;
    private float rotationAmount = 90f;
    public bool IsRotating { get; private set; } = false;
    private Rigidbody rb;
    
    public static PrimeraSala Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        if (!IsRotating)
        {
            StartCoroutine(RotateSmoothly());
        }
    }

    IEnumerator RotateSmoothly()
    {
        IsRotating = true;
        mainCamera.Priority = 5;
        rotationCamera.Priority = 20;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(rotationAmount, 0, 0);
        float time = 0;
        AudioManager.AudioInstance.PlaySoud(gearSound);

        while (time < rotationDuration)
        {
            Quaternion newRotation = Quaternion.Lerp(startRotation, endRotation, time / rotationDuration);
            rb.MoveRotation(newRotation);
            time += Time.deltaTime;
            
            yield return null;
        }

        rb.MoveRotation(endRotation);
        mainCamera.Priority = 20;
        rotationCamera.Priority = 5;
        IsRotating = false;
    }
}
