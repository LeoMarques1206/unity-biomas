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


    }
    void Update()
    {
        if(playerMovement.hasPeixe == true)
        {
            item1.color = Color.white;  
        } else 
        {
            item1.color = Color.black;    
        }
        
        if(playerMovement.hasBola == true)
        {
            item2.color = Color.white;  
        } else 
        {
            item2.color = Color.black;    
        }
        
        if(playerMovement.hasLeite == true)
        {
            item3.color = Color.white;  
        } else 
        {
            item3.color = Color.black;    
        }
        
    }
}
