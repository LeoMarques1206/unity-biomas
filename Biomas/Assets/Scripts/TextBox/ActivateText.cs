using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateText : MonoBehaviour
{
    public GameObject dialogue;
    private Dialogue dialogueScript;
    public float espera = 2f;
    private PlayerMovement playerMovement;
    public GameObject player;
    private bool entrou;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        dialogueScript = dialogue.GetComponent<Dialogue>();
       
        if (dialogueScript == null)
        {
            Debug.LogError("DialogueScript não encontrado no objeto com a tag 'Player'");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueScript.gameObject.SetActive(true);
            dialogueScript.StartDialogue();

            if(!entrou)
            {
                //playerMovement.canMove = false;
                playerMovement.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                playerMovement.canDash = false;
                entrou = true;
                if(espera > 0){
                    Invoke("WaitTime", espera);
                } else {
                    playerMovement.rb.constraints = RigidbodyConstraints2D.None;
                    playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    playerMovement.canMove = true;
                    playerMovement.canDash = true;
                    //playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    
                }
            }

            
            
        }
    }

    void WaitTime()
    {
        playerMovement.canMove = true;
        playerMovement.canDash = true;
        playerMovement.rb.constraints = RigidbodyConstraints2D.None;
        playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogue.SetActive(false);
        }
    }
}
