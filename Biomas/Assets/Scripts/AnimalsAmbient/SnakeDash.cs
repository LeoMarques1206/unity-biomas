using UnityEngine;

public class SnakeDash : MonoBehaviour
{
    public float dashSpeed = 10f; // Velocidade do dash
    public float dashDistance = 3f; // Distância fixa do dash
    public float dashDuration = 0.5f; // Duração do dash
    private bool playerTriggered = false;
    private bool isDashing = false; // Flag para controlar se a cobra está no meio de um dash
    private Vector3 dashTarget; // Alvo do dash
    public Animator animator;

    private float playerXAtTrigger; // Posição X do jogador no momento do trigger

    void Update()
    {
        if (playerTriggered && isDashing)
        {
            // Move a cobra em direção ao alvo do dash
            float step = dashSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, dashTarget, step);

            // Verifica se a cobra chegou ao alvo do dash
            if (Mathf.Abs(transform.position.x - dashTarget.x) < 0.001f)
            {
                isDashing = false;
                animator.SetBool("Dash", false);
            }
        }

        // Atualiza a direção da cobra em relação ao jogador
        if (playerTriggered)
        {
            UpdateFacingDirection();
        }

        // Verifica se a cobra está colidindo com algo e para o movimento se estiver no meio de um dash
        if (isDashing && IsColliding())
        {
            isDashing = false;
            animator.SetBool("Dash", false);
        }
    }

    private bool IsColliding()
    {
        // Checa se a cobra está colidindo com algo usando um círculo de colisão
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isDashing)
        {
            playerTriggered = true;
            animator.SetBool("Dash", true);
            playerXAtTrigger = other.transform.position.x; // Armazena a posição X do jogador no momento do trigger
            Invoke("StartDash", 0.8f);
        }
    }

    private void StartDash()
    {
        // Define o alvo do dash baseado na posição X do jogador no momento do trigger e mantendo a posição Y atual da cobra
        dashTarget = new Vector3(playerXAtTrigger, transform.position.y, transform.position.z);

        // Inicia o dash
        isDashing = true;
    }

    private void UpdateFacingDirection()
{
    // Calcula a direção do jogador em relação à cobra
    Vector3 playerDirection = new Vector3(playerXAtTrigger - transform.position.x, 0f, 0f);

    // Define a escala da transformação da cobra de acordo com a direção do jogador
    if (playerDirection.x > 0f)
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        // Define a escala do trigger para que também esteja olhando na direção do jogador
        animator.transform.localScale = new Vector3(Mathf.Abs(animator.transform.localScale.x), animator.transform.localScale.y, animator.transform.localScale.z);
    }
    else if (playerDirection.x < 0f)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        // Define a escala do trigger para que também esteja olhando na direção do jogador
        animator.transform.localScale = new Vector3(-Mathf.Abs(animator.transform.localScale.x), animator.transform.localScale.y, animator.transform.localScale.z);
    }
}

}
