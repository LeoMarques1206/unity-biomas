using UnityEngine;

public class circularMovement : MonoBehaviour
{
    public float speed = 5.0f; // Velocidade do movimento circular
    public float radius = 3.0f; // Raio do movimento circular

    private Vector3 centerPosition; // Posição central do movimento circular
    private float angle; // Ângulo atual do objeto

    void Start()
    {
        centerPosition = transform.position; // Define a posição inicial como o centro
    }

    void Update()
    {
        angle += speed * Time.deltaTime; // Incrementa o ângulo de acordo com a velocidade e o tempo

        // Calcula a nova posição do objeto usando funções trigonométricas
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Atualiza a posição do objeto
        transform.position = new Vector3(centerPosition.x + x, centerPosition.y + y, transform.position.z);
    }
}