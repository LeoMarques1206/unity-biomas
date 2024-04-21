using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContaLixo : MonoBehaviour
{
    public int numLixo = 0;
    public int lixoTotal;
    public GameObject portalFinal;
    public Image portalHUD;
    void Update()
    {
        if(numLixo == 3)
        {
            portalFinal.SetActive(true);
            portalHUD.color = Color.white;

        }
    }
}

