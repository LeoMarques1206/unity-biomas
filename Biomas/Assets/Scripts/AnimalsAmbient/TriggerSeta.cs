using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSeta : MonoBehaviour
{
    public GameObject seta;

    void Start()
    {
        seta.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) 
        {
          seta.SetActive(true);  
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) 
        {
          seta.SetActive(false);  
        }
    }
}
