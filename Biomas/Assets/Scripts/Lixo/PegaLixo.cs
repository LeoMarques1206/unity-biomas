using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class PegaLixo : MonoBehaviour
{
    public GameObject key;
    public GameObject lixo;
    private String lixoNome;
    public ContaLixo contaLixo;
    public GameObject lixoManagement;
    private bool apertou = false;
    public Image imageLixo;

    public AudioSource src;
    public AudioClip sfx;

    void Start()
    {
        contaLixo = lixoManagement.GetComponent<ContaLixo>();
        key.SetActive(false);
    }

    void Update()
    {
        apertou = false;

        if(Input.GetButtonDown("Submit"))
        {
            Debug.Log("Apertou");
            apertou = true;
            Debug.Log("Nome do item: " + lixoNome);
        } 
        if (apertou && lixoNome == lixo.name)
        {
            src.clip = sfx;
            src.Play();
            Debug.Log("PegouLixo");
            Destroy(gameObject);
            Destroy(key);
            contaLixo.numLixo++; // Incrementa o número de lixos
            imageLixo.color = Color.white;

            if(contaLixo.biomaAtual == "Amazonia")
            {
                PlayerPrefs.SetInt("NumLixosAmazonia", contaLixo.numLixo);
            }
            
        }
        // Debug.Log(contaLixo.numLixo);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EntrouLixo");
        if (other.CompareTag("Player"))
        {
            key.SetActive(true);
            lixoNome = lixo.name;
            Debug.Log(lixoNome);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            key.SetActive(false);
            lixoNome = null;
        }
    }
}
