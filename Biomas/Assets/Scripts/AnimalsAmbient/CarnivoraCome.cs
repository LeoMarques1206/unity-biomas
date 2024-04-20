using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoraCome : MonoBehaviour
{
    public Animator animatorPlanta;
    private GameObject planta;
    public GameObject libelula;
    private bool destroi = true;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && destroi)
        {
            animatorPlanta.SetBool("Come", true);
            Invoke("SomeLibelula", 0.2f);
           // Destroy(gameObject);
            destroi = false;
            
        } 
    }

    void SomeLibelula()
    {
        Debug.Log("Entrou");
        animatorPlanta.SetBool("Come", false);
        libelula.SetActive(false);
    }
}
