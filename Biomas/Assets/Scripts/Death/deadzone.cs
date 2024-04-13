using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadzone : MonoBehaviour
{
    public Animator animator;
    PlayerMovement playerMovement;
    public GameObject player;


     void Start()
    {
        
        playerMovement = player.GetComponent<PlayerMovement>();
       
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement não encontrado no objeto com a tag 'Player'");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerMovement.Death();
            Debug.Log("Morreu");
        } 
    }

    
}
