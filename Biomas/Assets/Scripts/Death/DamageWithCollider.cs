using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWithCollider : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject player;


    void Start()
    {
        
        playerMovement = player.GetComponent<PlayerMovement>();
       
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement não encontrado no objeto com a tag 'Player'");
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerMovement != null)
            {
                playerMovement.Death();
            }
        }
    }
}