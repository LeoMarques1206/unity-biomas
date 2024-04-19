using UnityEngine;
using System.Collections;

public class LizardMove : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidade de movimento do NPC
    public float maxXLimit = 10f; // Limite máximo no eixo X que o NPC pode alcançar
    public float fadeOutDuration = 2f; // Duração da animação de fade out
    public SpriteRenderer spriteRenderer; // Referência ao componente SpriteRenderer
    private bool reachedLimit = false; // Flag para controlar se o NPC alcançou o limite
    private bool fadingOut = false; // Flag para controlar se o fade out está ocorrendo
    private bool playerTriggered = false; // Flag para controlar se o trigger do jogador foi ativado
    public Animator animator;

    void Update()
    {
        if (!reachedLimit && playerTriggered)
        {
            // Movimento do NPC apenas se ele ainda não alcançou o limite e o jogador ativou o trigger
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Verifica se o NPC alcançou o limite
            if (transform.position.x >= maxXLimit)
            {
                reachedLimit = true;
                // Inicia o fade out quando o NPC alcança o limite
                StartCoroutine(FadeOut());
            }
        }
    }

    private IEnumerator FadeOut()
    {
        fadingOut = true;
        // Calcula o alpha inicial do sprite
        float startAlpha = spriteRenderer.color.a;
        // Tempo decorrido
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            // Interpola entre o alpha inicial e 0 ao longo do tempo
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeOutDuration);
            // Atualiza o alpha do sprite
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Desativa o gameObject após o fade out completar
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o trigger é ativado pelo jogador
        if (other.CompareTag("Player") && !fadingOut)
        {
            animator.SetBool("Run", true);
            // Ativa o flag indicando que o trigger do jogador foi ativado
            playerTriggered = true;
            // Inicia o fade out quando o jogador entra no trigger
            StartCoroutine(FadeOut());
        }
    }
}
