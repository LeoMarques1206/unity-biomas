using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool medalhaoSapoAtual;
    private bool medalhaoCobraAtual;
    private bool medalhaoMicoAtual;

    void Start()
    {
        dialogueScript = dialogue.GetComponent<Dialogue>();
        playerMovement = player.GetComponent<PlayerMovement>();

        medalhaoSapoAtual = playerMovement.MedalhaoSapo;
        medalhaoCobraAtual = playerMovement.MedalhaoCobra;
        medalhaoMicoAtual = playerMovement.MedalhaoMico;

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
                Debug.Log(SceneManager.GetActiveScene().name);
                if(SceneManager.GetActiveScene().name == "Amazonia")
                {
                    if(!medalhaoSapoAtual && dialogueScript != null)
                    {
                        dialogueScript.gameObject.SetActive(true);
                        dialogueScript.StartDialogue();
                    }

                    if(!medalhaoSapoAtual)
                    {
                        Debug.Log("som");
                        src.clip = sfx;
                        src.Play();
                    }

                }
                else if(SceneManager.GetActiveScene().name == "Caatinga")
                {
                    if(!medalhaoCobraAtual && dialogueScript != null)
                    {
                        dialogueScript.gameObject.SetActive(true);
                        dialogueScript.StartDialogue();
                    }

                    if(!medalhaoCobraAtual)
                    {
                        src.clip = sfx;
                        src.Play();
                    }
                }
                else if(SceneManager.GetActiveScene().name == "MataAtlantica")
                {
                    if(!medalhaoMicoAtual && dialogueScript != null)
                    {
                        dialogueScript.gameObject.SetActive(true);
                        dialogueScript.StartDialogue();
                    }

                    if(!medalhaoMicoAtual)
                    {
                        src.clip = sfx;
                        src.Play();
                    }
                }
                Invoke("QuebraBox", 5.0f);
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
