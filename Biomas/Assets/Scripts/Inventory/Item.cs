using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] //faz a variavel ser visivel e editavel na unity
    private string itemName;

    [SerializeField]
    private Sprite sprite;

    public AudioSource src;
    public AudioClip sfx;

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Player").transform.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemName, sprite);
            Destroy(gameObject);
            src.clip = sfx;
            src.Play();
        
        }
    }

}
