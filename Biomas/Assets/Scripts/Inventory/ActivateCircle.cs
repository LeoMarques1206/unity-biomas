using UnityEngine;

public class ActivateCircle : MonoBehaviour
{
    public GameObject circle; 

    void Start(){
        circle.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            circle.SetActive(true); 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            circle.SetActive(false); 
        }
    }
}
