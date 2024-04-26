using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] //faz a variavel ser visivel e editavel na unity
    private string itemName;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    //public AudioSource src;
    //public AudioClip sfx;

    private InventoryManager inventoryManager;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Player").transform.Find("InventoryCanvas").GetComponent<InventoryManager>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemName, sprite, itemDescription);
            if(itemName == "Bola de lã")
            {
                player.hasBola = true;
            }
            else if(itemName == "Peixe")
            {
                player.hasPeixe = true;
            }
            else if(itemName == "Leite")
            {
                player.hasLeite = true;
            }

            Destroy(gameObject);
            //src.clip = sfx;
            //src.Play();
        
        }
    }

}
