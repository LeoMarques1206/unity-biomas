using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectViolet : MonoBehaviour
{
    public Animator animator;
    private bool seeWally;

    public GameObject player;
    private PlayerMovement playerMovement;

    public GameObject dialogue;
    private Dialogue dialogueScript;
    public GameObject dialogue2;
    private Dialogue dialogueScript2;
    public GameObject Wally;
    private bool flagWally;

    private bool flagViolet;


    public float speed = 5f; // Velocidade de movimento
    public Vector2 direction = new Vector2(1, 1); // Direção de movimento
    public bool podeVoar = false;

    void Start()
    {
        
        dialogueScript = dialogue.GetComponent<Dialogue>();
        playerMovement = player.GetComponent<PlayerMovement>();
        dialogueScript2 = dialogue2.GetComponent<Dialogue>();
       
        if (dialogueScript == null)
        {
            Debug.LogError("DialogueScript não encontrado no objeto com a tag 'Player'");
        }
    }

    void Update()
    {
        if(podeVoar == true){
            Wally.transform.Translate(direction.normalized * speed * Time.deltaTime);
            // Debug.Log("Voando");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && playerMovement.hasViolet)
        {
            dialogueScript.gameObject.SetActive(true);
            dialogueScript.StartDialogue();
            //playerMovement.canMove = false;
            playerMovement.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            playerMovement.canDash = false;
            playerMovement.hasViolet = false;
            Invoke("MoveWally", 2f);
            Invoke("DestroyBox", 5f);
            flagWally = true;
        }
    }

    public void MoveWally()
    {
        animator.SetBool("detected", true);
        Invoke("FlyWally", 2f);
        dialogueScript2.gameObject.SetActive(true);
        dialogueScript2.StartDialogue();
        
    }

    public void FlyWally()
    {
        animator.SetBool("fly", true);
        podeVoar = true;
        Invoke("DestroyBox2" , 1.5f);
    }

    public void DestroyBox()
    {
        Destroy(dialogue);
    }

    public void DestroyBox2()
    {
        Destroy(dialogue2);
        //playerMovement.canMove = true;
        playerMovement.canDash = true;
        playerMovement.rb.constraints = RigidbodyConstraints2D.None;
        playerMovement.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
