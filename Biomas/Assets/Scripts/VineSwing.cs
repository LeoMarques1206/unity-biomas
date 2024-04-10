using UnityEngine;

public class VineSwing : MonoBehaviour
{
    public float swingForce = 5f;
    public Transform characterHoldPoint;
    public Rigidbody2D characterRigidbody;
    private bool isSwinging = false;
    private float swingDirection = 1f; // Direção inicial do balanço

    void Update()
    {
        if (isSwinging)
        {
            // Aplica uma força lateral ao personagem para balançá-lo
            Vector2 force = Vector2.right * swingDirection * swingForce;
            characterRigidbody.AddForce(force, ForceMode2D.Force);

            // Atualiza a posição do personagem para mantê-lo agarrado ao cipó
            characterRigidbody.MovePosition(characterHoldPoint.position);

            // Inverte a direção do balanço se atingir os limites
            if (transform.position.x >= characterHoldPoint.position.x + 0.5f)
            {
                swingDirection = -1f;
            }
            else if (transform.position.x <= characterHoldPoint.position.x - 0.5f)
            {
                swingDirection = 1f;
            }

            // Verifica se o jogador deseja soltar o cipó
            if (Input.GetButtonDown("Jump"))
            {
                isSwinging = false;
                characterRigidbody.velocity = Vector2.zero;
                characterRigidbody.angularVelocity = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Se o jogador entrar em contato com o cipó, comece a balançar
            isSwinging = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Se o jogador sair do cipó, pare de balançar
            isSwinging = false;
        }
    }
}
