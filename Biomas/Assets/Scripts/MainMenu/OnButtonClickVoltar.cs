using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClickVoltar : MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup cena;
    public GameObject cat;
    
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Clicou);
    }

    public void Clicou()
    {
        mainMenu.alpha = 1f;
        cena.alpha = 0f;
        Debug.Log("Clicou");
        cat.SetActive(true);
    }
}
