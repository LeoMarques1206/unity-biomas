using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectaIA : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TMP_Text conteudo;
    public string nomeDoTrigger; // Nome do GameObject que representa o trigger específico
    public string nome;

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            // Obtém a posição do clique do mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cria um raio a partir da posição do clique do mouse na direção Z
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Verifica se o raio atingiu um Collider2D
            if (hit.collider != null)
            {
                // Verifica se o Collider2D atingido é o trigger desejado
                if (hit.collider.isTrigger && hit.collider.gameObject.name == nomeDoTrigger)
                {
                    // Exibe uma mensagem no console quando o trigger específico é clicado
                    Debug.Log("Trigger " + nomeDoTrigger + " clicado: " + hit.collider.gameObject.name);
                    
                    // Define o conteúdo do texto para indicar o nome do trigger
                    conteudo.text = "Isto é " +nome;

                    // Torna o canvas visível
                    canvasGroup.alpha = 1;

                    // Invoca o método para esconder o canvas após 5 segundos
                    Invoke("SaiAlpha", 5f);
                }
            }
        }
    }

    void SaiAlpha()
    {
        // Esconde o canvas
        canvasGroup.alpha = 0;
    }
}
