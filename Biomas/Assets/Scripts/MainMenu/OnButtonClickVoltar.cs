using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClickVoltar : MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup cena;
    public CanvasGroup cenaDicas;
    public GameObject cat;
    
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Clicou);
    }

    public void Clicou()
    {
        cena.alpha = 0f;
        mainMenu.alpha = 1f;
        cenaDicas.alpha = 0f;
        Debug.Log("Clicou");
        cat.SetActive(true);
    }
}
