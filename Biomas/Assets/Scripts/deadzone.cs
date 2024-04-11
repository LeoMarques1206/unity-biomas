using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour
{
    public Animator animator;
    //public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("Dead", true);
            Debug.Log("Morreu");
        } 
    }

    
}
