using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //dados do item
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;

    //item slot 
    [SerializeField]
    private Image itemImage;
    
    public void AddItem(string itemName, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;

        itemImage.enabled = true;
        itemImage.sprite = itemSprite;
    }
}
