using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPortal : MonoBehaviour
{
    public string cenaParaInstanciar;
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(cenaParaInstanciar);
        } 
    }
}
