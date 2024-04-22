using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaMedalhao : MonoBehaviour
{
    public GameObject dialogue;
    private Dialogue dialogueScript;

    private PlayerMovement playerSkills;
    public GameObject player;
    private Skill skill;

    void Start()
    {
        dialogueScript = dialogue.GetComponent<Dialogue>();
        playerSkills = player.GetComponent<PlayerMovement>();
        skill = GetComponent<Skill>();
       
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
            skill.GiveItem();
            if(playerSkills.MedalhaoSapo == false)
            {   
                playerSkills.saveSkillsData(1);
            }
            Invoke("Load", 0.1f);
        }
    }

    public void Load()  
    {   
        if(playerSkills.MedalhaoSapo == false){
            playerSkills.LoadSkillsData();
        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogue.SetActive(false);
        }
    }
}
