using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceItensGato : MonoBehaviour
{
    public Image item1, item2, item3;
    private bool teste = true; //mudar depois para public script

    void Start ()
    {
        //Instanciar script referente aos booleanos dos itens ao adquiri-los
    }
    void Update()
    {
        if(teste = true)
        {
            item1.color = Color.white; 
            item2.color = Color.white;  
        }

        
        
    }
}
