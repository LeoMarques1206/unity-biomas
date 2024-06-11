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

    void Start()
    {
        Debug.Log("Timescale atual: " + Time.timeScale);
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
            
            if(entrou == false)
            {
                if(dialogueScript != null)
                {
                    dialogueScript.gameObject.SetActive(true);
                    dialogueScript.StartDialogue();
                }
                
                src.clip = sfx;
                src.Play();
                Invoke("DestroyBox", 5.0f);
                //Debug.Log("chegouAqui");
                entrou = true;
            }  
        }
    }

    public void DestroyBox()
    {
        Debug.Log("Chamou");
        dialogue.SetActive(false);
    }
}
