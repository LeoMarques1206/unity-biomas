using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContaLixo : MonoBehaviour
{
    public String biomaAtual = " ";
    public int numLixo;
    public int lixoTotal;
    public GameObject portalFinal;
    public Image portalHUD;

    public GameObject[] listaLixos;

    void Start()
    {
        biomaAtual = SceneManager.GetActiveScene().name;

        if(biomaAtual == "Amazonia")
        {
            numLixo = PlayerPrefs.GetInt("NumLixosAmazonia");
        
        } 
        else if(biomaAtual == "Caatinga")
        {
            numLixo = PlayerPrefs.GetInt("NumLixosCaatinga");

        }

        for(int i = 0; i < numLixo; i++)
        {
            listaLixos[i].SetActive(false);
        }

    }

    void Update()
    {

        if(numLixo == 3)
        {
            portalFinal.SetActive(true);
            portalHUD.color = Color.white;

        }
    }
}

