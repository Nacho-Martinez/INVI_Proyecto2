using System.Collections;
using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{
    //Con un timer hacer que este game object se active y se descative cada 1.5 segundos.
    
    private MeshRenderer mr;
    private BoxCollider bc;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Cada 1.5 se desactiva el mesh renderar y se activa el boxcollider
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
        bc = GetComponent<BoxCollider>();

        //StartCoroutine(Semaforo());
        StartCoroutine(SwitchStates());
    }

    // Update is called once per frame
    void Update()
    {
      
            //activeSelf : Comprueba estado de activación
            //SetActive : Modifica el estado de activación
            // this.gameObject.SetActive(!gameObject.activeSelf);
            // mr.enabled = !mr.enabled;
            // bc.enabled = !bc.enabled;
   
                
        
    }

    private IEnumerator SwitchStates()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            mr.enabled = !mr.enabled;
            bc.enabled = !bc.enabled;
        }
    }
    //Corrutina:
    // private IEnumerator Semaforo()
    // {
    //     while (true)
    //     {
    //         Debug.Log("Verde");
    //         yield return new WaitForSeconds(2f);
    //         Debug.Log("Amarillo");
    //         yield return new WaitForSeconds(1.5f); 
    //         Debug.Log("Rojo");
    //         yield return new WaitForSeconds(1f); 
    //         
    //     }
    // }
}
