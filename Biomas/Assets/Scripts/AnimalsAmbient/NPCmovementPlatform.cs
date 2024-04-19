using UnityEngine;

public class NPCMovementPlatform : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade de movimento do NPC
    public float leftLimit = -5f; // Limite esquerdo
    public float rightLimit = 5f; // Limite direito
    public GameObject player; // Referência ao jogador
    public SpriteRenderer npcSpriteRenderer; // Referência ao SpriteRenderer da Onça_0

    private bool movingRight = true; // Flag para controlar a direção

    private void Update()
    {
        // Movimento horizontal
        Vector3 movement = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        if (movingRight)
        {
            transform.Translate(movement); // Move para a direita
        }
        else
        {
            transform.Translate(-movement); // Move para a esquerda
        }

        // Verifica se atingiu os limites
        if (transform.position.x >= rightLimit)
        {
            movingRight = false;
        }
        else if (transform.position.x <= leftLimit)
        {
            movingRight = true;
        }

        // Inverte a direção
        if (movingRight)
        {
            npcSpriteRenderer.flipX = false; // Não vira horizontalmente
        }
        else
        {
            npcSpriteRenderer.flipX = true; // Vira horizontalmente
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
