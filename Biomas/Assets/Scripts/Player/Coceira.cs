using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coceira : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerMovement playerMovement;
    [SerializeField] private Color novaCor; 
    [SerializeField] private Color corNormal;
    [SerializeField] private Color corForte;
    private bool isPlayerInside = false;
    private float tempoDecorrido = 0f;
    private float speedAtual;

    public void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        speedAtual = playerMovement.speed;
    }

    void Update()
    {
        
        if (isPlayerInside)
        {
            tempoDecorrido += Time.deltaTime; 

           
            if (tempoDecorrido >= 3f)
            {
                MudarCorJogador(corForte); 
                Invoke("Morreu", 0.3f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerMovement.speed = 1.5f;
            isPlayerInside = true; 
            MudarCorJogador(novaCor); 
        } 
    }

    void OnTriggerExit2D(Collider2D other)
    {
         if(other.CompareTag("Player"))
        {
            isPlayerInside = false; 
            MudarCorJogador(corNormal); 
            tempoDecorrido = 0f; 
            playerMovement.speed = speedAtual;
        } 
    }

    void MudarCorJogador(Color cor)
    {
        SpriteRenderer jogadorSpriteRenderer = player.GetComponent<SpriteRenderer>();
        
        if (jogadorSpriteRenderer != null)
        {
            jogadorSpriteRenderer.color = cor; 
        }
        else
        {
            Debug.LogWarning("O GameObject do jogador não possui um componente SpriteRenderer.");
        }
    }

    void Morreu()
    {
       // playerMovement.Death();
    }
}
