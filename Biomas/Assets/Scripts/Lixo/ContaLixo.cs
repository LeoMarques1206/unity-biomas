using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaLixo : MonoBehaviour
{
    public int numLixo = 0;
    public int lixoTotal;
    public GameObject portalFinal;
    void Update()
    {
        if(numLixo == 3)
        {
            portalFinal.SetActive(true);
        }
    }
}

