using UnityEngine;
using System.Collections;

public class MudarIntensidadeLuz : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D luz;
    public float intervalo = 1f;

    void Start()
    {
        // Obtém o componente de luz do objeto filho
        luz = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();

        // Inicia a rotina para alterar a intensidade da luz a cada intervalo
        StartCoroutine(AlterarIntensidade());
    }

    IEnumerator AlterarIntensidade()
    {
        while (true)
        {
            // Define a intensidade da luz para 0
            luz.intensity = 0f;
            
            // Aguarda o intervalo especificado
            yield return new WaitForSeconds(intervalo);

            // Define a intensidade da luz para 1
            luz.intensity = 1.5f;
            yield return new WaitForSeconds(intervalo);
        }
    }
}