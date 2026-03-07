using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//INSTANCE : TRONO
public class UIManager : MonoBehaviour
{
    //1. Existe solo una ùnica instancia de esta clase
    //2. Es accesible desde cualquier punto del programa (script)
    
    //Un campo automaticamente encapsulado y está serializado 
    [field: SerializeField] public TMP_Text ScoreText { get; private set; }
    [field: SerializeField] public TMP_Text InteractText { get; private set; }
    public static UIManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            //Aquel que reclama el trono no se destruye entre escenasField
            DontDestroyOnLoad(this.gameObject); 
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
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     SceneManager.LoadScene("Ejemplo");
        // }
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     SceneManager.LoadScene("SampleScene");
        // }
    }
}
