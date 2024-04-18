using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextTempo : MonoBehaviour
{
    public GameObject dialogue;
    private Dialogue dialogueScript;
    public float timePass; //tempo para escolher
    private float time;
    public GameObject player;
    private PlayerMovement playerMovement;
    private bool entrar = false;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        dialogueScript = dialogue.GetComponent<Dialogue>();
       
        if (dialogueScript == null)
        {
            Debug.LogError("DialogueScript não encontrado no objeto com a tag 'Player'");
        }

        Debug.Log(entrar);
    }

    void Update()
    {
        if(entrar){
            time = time + 0.1f;
            Debug.Log(time);
        }
        
        
        if(time >= timePass)
            {
                playerMovement.canMove = true;
            }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            entrar = true;
            dialogueScript.gameObject.SetActive(true);
            dialogueScript.StartDialogue();
            playerMovement.canMove = false;
            
                
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {
            time = 0;
            entrar = false;
            dialogue.SetActive(false);
        }
    }
}
