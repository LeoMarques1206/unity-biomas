using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float sinkDistance = 0.5f; // Distância que a plataforma afunda
    public float sinkSpeed = 0.1f; // Velocidade de afundamento

    private Vector3 originalPosition;
    private bool playerOnPlatform = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            // Afundar a plataforma
            Vector3 targetPosition = originalPosition - new Vector3(0, sinkDistance, 0);
            transform.position = Vector3.Lerp(transform.position, targetPosition, sinkSpeed * Time.deltaTime);
        }
        else
        {
            // Voltar a plataforma para a posição original
            transform.position = Vector3.Lerp(transform.position, originalPosition, sinkSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }
}