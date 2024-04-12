using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade de movimento do NPC
    public float leftLimit = -5f; // Limite esquerdo
    public float rightLimit = 5f; // Limite direito

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
            transform.localScale = new Vector3(1f, 1f, 1f); // Olhando para a direita
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Olhando para a esquerda
        }
    }
}
