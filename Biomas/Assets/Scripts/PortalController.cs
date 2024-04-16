using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public float fadeDuration = 1f; // Duração do fade em segundos
    public float delayBeforeFade = 5f; // Atraso antes de começar o fade em segundos
    private SpriteRenderer portalRenderer;
    private Color initialColor;
    private bool fadeInStarted = false;
    private float fadeInStartTime;

    void Start()
    {
        // Obtém o componente SpriteRenderer do Portal
        portalRenderer = GetComponent<SpriteRenderer>();

        // Salva a cor inicial do portal
        initialColor = portalRenderer.color;

        // Esconde o portal
        portalRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        // Começa a contagem regressiva para o fade in com o atraso especificado
        Invoke("StartFadeIn", delayBeforeFade);
    }

    void StartFadeIn()
    {
        // Começa a contagem regressiva para o fade in
        fadeInStarted = true;
        fadeInStartTime = Time.time;
    }

    void Update()
    {
        // Verifica se já começou o fade in
        if (fadeInStarted)
        {
            // Calcula o progresso do fade in
            float elapsedTime = Time.time - fadeInStartTime;
            float alpha = Mathf.Lerp(0f, initialColor.a, elapsedTime / fadeDuration);

            // Define a nova cor com o alpha ajustado
            portalRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);

            // Verifica se o fade in está completo
            if (elapsedTime >= fadeDuration)
            {
                // Se o fade in estiver completo, para de atualizar e define fadeInStarted como false
                fadeInStarted = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("IntroAmazonia");
        }
    }

}
