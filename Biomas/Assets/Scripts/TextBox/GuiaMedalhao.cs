using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaMedalhao : MonoBehaviour
{
    public GameObject dialogue;
    private Dialogue dialogueScript;
    private PlayerMovement playerSkills;
    public float espera = 2f;
    public GameObject player;
    private Skill skill;
    private bool entrou;

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
        
             if(!entrou)
            {
                playerSkills.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                playerSkills.canDash = false;
                entrou = true;
                if(espera > 0){
                    Invoke("WaitTime", espera);
                } else {
                    playerSkills.rb.constraints = RigidbodyConstraints2D.None;
                    playerSkills.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    playerSkills.canDash = true;
                }
            }

            if(playerSkills.MedalhaoSapo == false && skill.skillName == "Medalhao do sapo")
            {   
                skill.GiveItem();
                playerSkills.saveSkillsData(1);
                playerSkills.MedalhaoSapo = true;
            }

            if(playerSkills.MedalhaoCobra == false && skill.skillName == "Medalhão da Cobra")
            {   
                skill.GiveItem();
                playerSkills.saveSkillsData(2);
                playerSkills.MedalhaoCobra = true;
            }

            if(playerSkills.MedalhaoMico == false && skill.skillName == "Medalhão do Mico")
            {
                skill.GiveItem();
                playerSkills.saveSkillsData(3);
                playerSkills.MedalhaoMico = true;
            }

            Invoke("Load", 0.1f);
        }
    }

    public void Load()  
    {   
        playerSkills.LoadSkillsData();
    }
    void WaitTime()
    {
        playerSkills.canMove = true;
        playerSkills.canDash = true;
        playerSkills.rb.constraints = RigidbodyConstraints2D.None;
        playerSkills.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            dialogue.SetActive(false);
        }
    }
}
