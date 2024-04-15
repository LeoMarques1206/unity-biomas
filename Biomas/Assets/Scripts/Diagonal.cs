using UnityEngine;

public class Diagonal : MonoBehaviour
{
    public bool podeVoar = false;
    public bool podeVoarWally = false;
    public float speed = 5f; // Velocidade de movimento
    public Vector2 direction = new Vector2(1, 1); // Direção de movimento

    void Update()
    {
        if(podeVoar == true || podeVoarWally == true){
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        
    }
}