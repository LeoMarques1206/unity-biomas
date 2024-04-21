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

    private bool fading = false;
    private float fadeDuration = 1f; // Duração do fade (em segundos)
    private Color corInicial;
    private float fadeStartTime;

    public void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        speedAtual = playerMovement.speed;
        corInicial = corNormal;
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

        if (fading)
        {
            float t = (Time.time - fadeStartTime) / fadeDuration;
            Color corAtual = Color.Lerp(corInicial, corNormal, t);
            MudarCorJogador(corAtual);

            if (t >= 1f)
            {
                fading = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.speed = 1.5f;
            isPlayerInside = true;
            MudarCorJogador(novaCor);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            corInicial = player.GetComponent<SpriteRenderer>().color;
            tempoDecorrido = 0f;
            playerMovement.speed = speedAtual;
            StartFade();
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

    void StartFade()
    {
        fading = true;
        fadeStartTime = Time.time;
    }
}
