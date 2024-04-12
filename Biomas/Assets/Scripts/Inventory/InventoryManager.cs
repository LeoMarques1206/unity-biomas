using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
           
        }

        else if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
    }

    public void AddItem(string itemName, Sprite itemSprite)
    {
        for(int i = 0; i < itemSlot.Length; i++) 
        {
            if(!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(itemName, itemSprite);
                return;
            }    
        }
    }
}
