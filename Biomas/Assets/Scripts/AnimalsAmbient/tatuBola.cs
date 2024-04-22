using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tatuBola : MonoBehaviour
{
    public Animator animator;
    public NPCMovement npcMovement;
    public GameObject tatu;
    
    void Start()
    {
        npcMovement =  tatu.GetComponent<NPCMovement>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Bola", true);
            npcMovement.moveSpeed = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Bola", false);
            npcMovement.moveSpeed = 0.7f;
        }
    }
}
