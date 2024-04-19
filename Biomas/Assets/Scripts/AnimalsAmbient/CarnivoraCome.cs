using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivoraCome : MonoBehaviour
{
    public Animator animator;
    private GameObject planta;
    
    void Start()
    {
        //
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("Come", true);
            animator.SetBool("Idle", true);
            
        } 

        
    }
}
