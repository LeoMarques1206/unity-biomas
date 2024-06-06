using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSnake : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
    }
    void Start()
    {
        

    }

    void Update()
    {
        if(playerMovement.MedalhaoCobra == true)
        {
            gameObject.SetActive(false);
        } else 
        {
            gameObject.SetActive(true);
        }
    }

    
}
