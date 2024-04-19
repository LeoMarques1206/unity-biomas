using UnityEngine;

public class LixoFlutuando : MonoBehaviour
{
    public float floatDistance = 0.5f; // Distância de flutuação
    public float floatSpeed = 1.0f; // Velocidade de flutuação
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calcula a posição de destino com base na altura inicial e na distância de flutuação
        Vector3 targetPos = startPos + Vector3.up * floatDistance;

        // Usa a função seno para gerar um movimento de vaivém suave
        float offset = Mathf.Sin(Time.time * floatSpeed) * 0.5f + 0.5f;

        // Interpola suavemente entre a posição inicial e a posição de destino
        Vector3 newPosition = Vector3.Lerp(startPos, targetPos, offset);

        // Define a nova posição do objeto
        transform.position = newPosition;
    }
}
