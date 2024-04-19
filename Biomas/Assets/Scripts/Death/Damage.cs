using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject player;

    private int testBranch;

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
            
            if (playerMovement != null)
            {
                playerMovement.Death();
                
            }
        }
    }
}
