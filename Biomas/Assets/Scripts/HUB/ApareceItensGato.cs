using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceItensGato : MonoBehaviour
{
    public Image item1, item2, item3;
    public GameObject player;
    private PlayerMovement playerMovement;
    public GameObject portalFinal;
    public Animator catAnimator;
    
    void Start ()
    {
       playerMovement = player.GetComponent<PlayerMovement>();

       //TESTANDO
      // playerMovement.hasPeixe = true;
      // playerMovement.hasBola = true;
      // playerMovement.hasLeite = true;

    }
    void Update()
    {
        if(playerMovement.hasPeixe == true)
        {
            item1.color = Color.white;  
        } 
        if(playerMovement.hasBola == true)
        {
            item1.color = Color.white;  
        } 
        if(playerMovement.hasLeite == true)
        {
            item1.color = Color.white;  
        } 

        
        
    }
}
