using UnityEngine;
using UnityEngine.SceneManagement;

public class TextDescend : MonoBehaviour
{
    public float descendSpeed = 1f; // Velocidade de descida do texto
    public bool fim;

    void Update()
    {
        // Movimenta o objeto descendo ao longo do eixo Y
        transform.Translate(Vector3.down * descendSpeed * Time.deltaTime);
        
        // Verifica se o objeto saiu da tela (opcional: você pode ajustar isso de acordo com sua cena)
        if (transform.position.y < -10f)
        {
            // Destroi o objeto quando ele estiver fora da tela
            Destroy(gameObject);
        }

        if (transform.position.y < -2f && fim)
        {
            descendSpeed = 0f;
            Invoke("MudaCena", 1.5f);
        }
    }

    void MudaCena ()
    {
        SceneManager.LoadScene("Menu");
    }
}