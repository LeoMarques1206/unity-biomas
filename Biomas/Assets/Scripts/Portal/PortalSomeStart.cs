using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSomeStart : MonoBehaviour
{
    public float fadeDuration = 3f; 
    public Renderer objectRenderer; 

    private void Start()
    {
        
        StartCoroutine(FadeObject());
    }

    private IEnumerator FadeObject()
    {
        
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
            if (objectRenderer == null)
            {
                Debug.LogError("Renderer não encontrado.");
                yield break;
            }
        }

        // Obter a cor inicial do material
        Color startColor = objectRenderer.material.color;

        // Loop até que a opacidade seja zero
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calcular a nova opacidade com base no tempo decorrido
            float alpha = Mathf.Lerp(startColor.a, 0f, elapsedTime / fadeDuration);

            // Definir a nova cor com a opacidade ajustada
            Color newColor = new Color(startColor.r, startColor.g, startColor.b, alpha);
            objectRenderer.material.color = newColor;

            // Incrementar o tempo decorrido
            elapsedTime += Time.deltaTime;

            // Aguardar até o próximo frame
            yield return null;
        }

        // Garantir que a cor final seja completamente transparente
        objectRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }
}
