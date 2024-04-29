using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unifor.Biomas.AI;

public class DetectaIA : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TMP_Text conteudo;
    public string nomeDoTrigger; // Nome do GameObject que representa o trigger específico
    public string nome;
    public string bioma;
    public GameObject IA;
    private BiomasAIManager scriptIA;
    private bool flag = false;

    void Start()
    {
        scriptIA = IA.GetComponent<BiomasAIManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !flag)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Verifica se o raio atingiu um Collider2D
            if (hit.collider != null)
            {
                // Verifica se o Collider2D atingido é o trigger desejado
                if (hit.collider.isTrigger && hit.collider.gameObject.name == nomeDoTrigger)
                {
                    Debug.Log("Trigger " + nomeDoTrigger + " clicado: " + hit.collider.gameObject.name);

                    OnWildLifeButtonClicked(bioma, nome);
                    // conteudo.text = "Isto é " + nome;

                    canvasGroup.alpha = 1;

                    Invoke("ResetFlag", 0.1f);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && flag)
        {
            Debug.Log("entrou na saida ");
            canvasGroup.alpha = 0;
            flag = false;
        }

    }
    void ResetFlag()
    {
        flag = true;
    }

    void SaiAlpha()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canvasGroup.alpha = 0;
        }
    }


    void OnWildLifeButtonClicked(string biome, string wildlife)
    {
        if (biome == string.Empty || wildlife == string.Empty)
        {
            conteudo.text = "Erro";
        }

        scriptIA.DescribeWildlife(biome, wildlife, FillDescription);
    }

    void FillDescription(string description)
    {
        conteudo.text = description;
    }
}
