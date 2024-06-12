using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextItens : MonoBehaviour
{
    public GameObject dialogue;
    private Dialogue dialogueScript;
    public AudioSource src;
    public AudioClip sfx;
    private bool entrou = false;
    public GameObject trigger;
    public string nomeDoTriggerItem; //Peixe, Leite ou Bola
    public GameObject player;
    private PlayerMovement playerMovement;

    void Start()
    {
        dialogueScript = dialogue.GetComponent<Dialogue>();
        playerMovement = player.GetComponent<PlayerMovement>();

        if(trigger != null){
            if(playerMovement.hasPeixe && nomeDoTriggerItem == "Peixe")
            {
                trigger.SetActive(false);
            }
            if(playerMovement.hasLeite && nomeDoTriggerItem == "Leite")
            {
                trigger.SetActive(false);
            }
            if(playerMovement.hasBola && nomeDoTriggerItem == "Bola")
            {
                trigger.SetActive(false);
            }
        }
        if (dialogueScript == null)
        {
            Debug.LogError("DialogueScript não encontrado no objeto com a tag 'Player'");
        }
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {
            
            if(entrou == false)
            {
                if(dialogueScript != null)
                {
                    dialogueScript.gameObject.SetActive(true);
                    dialogueScript.StartDialogue();
                }
                Invoke("QuebraBox", 5.0f);
                src.clip = sfx;
                src.Play();
                //Debug.Log("chegouAqui");
                entrou = true;
            }  
        }
    }

    public void QuebraBox()
    {
        Debug.Log("Chamou");
        dialogue.SetActive(false);
    }
}
