using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    PlayerMovement playerMovement;
   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.CompareTag("Player")) 
        {
            playerMovement.Death();
        }
   }
}
