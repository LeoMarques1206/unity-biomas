using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoItensUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup.alpha = 0;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canvasGroup.alpha = 1;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canvasGroup.alpha = 0;
        }
    }
}
