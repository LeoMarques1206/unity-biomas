using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GatoItensUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject portalFinal;
    private PlayerMovement playerMovement;
    public GameObject player;
    public GameObject livro;
    public GameObject pc;
    public string scene;

    public AudioSource src;
    public AudioClip sfx;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        canvasGroup.alpha = 0;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canvasGroup.alpha = 1;

            if(playerMovement.hasLeite  && playerMovement.hasBola && playerMovement.hasPeixe)
            {
                canvasGroup.alpha = 0;
                portalFinal.SetActive(true);
                playerMovement.canMove = false;
                playerMovement.canDash = false;
                Invoke("Fim", 2f);
                
            }
        }

        
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canvasGroup.alpha = 0;
        }
    }

    void Fim() //metodo para invocar a cena de fim de jogo.
    {
        player.SetActive(false);
        gameObject.SetActive(false);
        livro.SetActive(false);
        pc.SetActive(false);
        src.clip = sfx;
        src.Play();
        Invoke("SceneTransition", 1f);
    }

    void SceneTransition()
    {
        SceneManager.LoadScene(scene);
    }


}
