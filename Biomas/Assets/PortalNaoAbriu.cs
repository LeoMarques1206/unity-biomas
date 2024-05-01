using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNaoAbriu : MonoBehaviour
{
    public CanvasGroup texto;
    private ContaLixo contaLixo;
    public GameObject lixoManager;

    void Start()
    {
        contaLixo = lixoManager.GetComponent<ContaLixo>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && contaLixo.numLixo <= 2)
        {
            texto.alpha = 1;
        } else if (other.CompareTag("Player") && contaLixo.numLixo == 3)
        {
            texto.alpha = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            texto.alpha = 0;
        }
    }
}
