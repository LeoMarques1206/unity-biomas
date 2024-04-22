using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caindo : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private PlayerMovement playerMovement;
    private bool ativo = true;
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && ativo)
        {
            animator.SetBool("Caindo", true);
            Invoke("False", 1.1f);
            
            
        }
    }

    void False()
    {
        gameObject.SetActive(false);
        ativo = false;
        animator.SetBool("Caindo", false);
        
    }
    
}
