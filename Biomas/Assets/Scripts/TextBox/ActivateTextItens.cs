using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextItens : MonoBehaviour
{
    public GameObject dialogue;
    private Dialogue dialogueScript;

    public AudioSource src;
    public AudioClip sfx;

    void Start()
    {
        
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
            src.clip = sfx;
            src.Play();
            Invoke("DestroyBox", 5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(dialogue);
    }
}
