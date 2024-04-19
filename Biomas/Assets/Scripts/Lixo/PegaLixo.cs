using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaLixo : MonoBehaviour
{
    public GameObject key;
    public GameObject lixo;
    private bool pegou = false;
    public ContaLixo contaLixo;
    public GameObject lixoManagement;
    private bool apertou = false;

    void Start()
    {
        contaLixo = lixoManagement.GetComponent<ContaLixo>();
        key.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            Debug.Log("Apertou");
            apertou = true;
        }
        if (apertou)
            {
                pegou = true;
                Debug.Log("PegouLixo");
                lixo.SetActive(false);
                key.SetActive(false);
                contaLixo.numLixo++; // Incrementa o número de lixos
            }
        Debug.Log(contaLixo.numLixo);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EntrouLixo");
        if (other.CompareTag("Player"))
        {
            key.SetActive(true);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            key.SetActive(false);
        }
    }
}
