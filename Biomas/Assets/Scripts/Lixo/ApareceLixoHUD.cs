using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceLixoHUD : MonoBehaviour
{
    public bool apareceLata = false;
    private bool apareceSacoLixo = false;
    private bool apareceSacoPlastico = false;
    public Image lata;

    void Update()
    {
        if(apareceLata)
            {
                lata.color = Color.white;
            }
    }
    
}
