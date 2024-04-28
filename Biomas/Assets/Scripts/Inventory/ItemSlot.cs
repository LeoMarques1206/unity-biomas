using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //INICIO DOS DADOS DO ITEM
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    //FIM DOS DADOS DO ITEM

    //INICIO DO SLOT DO ITEM
    [SerializeField]
    public Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;
    //FIM DO SLOT DO ITEM

    //INICIO DA DESCRICAO DO SLOT DE ITEM
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    //FIM DA DESCRICAO DO SLOT DE ITEM

    private InventoryManager inventoryManager;

    public void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        UpdateUI();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots(); //deseleciona todos para deixar apenas o que eu quero selecionado
        selectedShader.SetActive(true);
        thisItemSelected = true;
        
        // if(itemName != null && itemDescription != null)     //tirar depois de implementar a foto entre cenas 
        // {
        //     ItemDescriptionNameText.text = itemName;
        //     ItemDescriptionText.text = itemDescription;
        //     itemDescriptionImage.sprite = itemSprite;
        //     itemDescriptionImage.enabled = true;
        // } 
        Debug.Log("item sprite: " + itemSprite + " item name: " + itemName);
        if(itemSprite != null && itemName != null && itemDescription != null) 
        {
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            itemDescriptionImage.enabled = true;
        } 
        else if(itemSprite == null) 
        {
            Debug.Log("entrou");
            ItemDescriptionNameText.text = "";
            ItemDescriptionText.text = "";
            itemDescriptionImage.enabled = false;

        }
        
        // if (itemSprite != null)
        // {
        //     itemDescriptionImage.sprite = itemSprite;
        // }
    }

    public void OnRightClick()
    {

    }

    public void UpdateUI()
    {
        itemImage.sprite = itemSprite;
        itemImage.enabled = isFull;
        // ItemDescriptionNameText.text = itemName;
        // ItemDescriptionText.text = itemDescription;

        // if (itemSprite != null)
        // {
        //     itemDescriptionImage.sprite = itemSprite;
        // }
    }
}
