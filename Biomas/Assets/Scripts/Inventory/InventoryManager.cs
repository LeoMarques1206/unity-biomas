using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public SkillSlot[] skillSlot;
    // Start is called before the first frame update


    void Start()
    {
        LoadSlotData();

    }

    void OnDestroy()
    {
        SaveSlotData();
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

    public void AddItem(string itemName, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(itemName, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void AddSkill(string skillName, Sprite skillSprite, string skillDescription)
    {
         for (int i = 0; i < skillSlot.Length; i++)
        {
            if (!skillSlot[i].isFull)
            {
                skillSlot[i].AddSkill(skillName, skillSprite, skillDescription);
                return;
            }
        }
    }

    //DESELECIONA TODOS OS SLOTS QUE ESTAO ATIVADOS NO MOMENTO
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for(int i = 0; i < skillSlot.Length; i++)
        {
            skillSlot[i].selectedShader.SetActive(false);
            skillSlot[i].thisSkillSelected = false;
        }
    }

    private void SaveSlotData()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            PlayerPrefs.SetString("ItemName_" + i, itemSlot[i].itemName);
            PlayerPrefs.SetString("ItemDescription_" + i, itemSlot[i].itemDescription);
        }
        for(int i = 0; i < skillSlot.Length; i++)
        {
            PlayerPrefs.SetString("SkillName_" + i, skillSlot[i].skillName);
            PlayerPrefs.SetString("SkillDescription_" + i, skillSlot[i].skillDescription);
        }
        PlayerPrefs.Save();

        Debug.Log("entrou no save");
        Debug.Log("item name: " + PlayerPrefs.GetString("ItemName_0"));
    }

    private void LoadSlotData()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].itemName = PlayerPrefs.GetString("ItemName_" + i);
            Debug.Log("itemSlot[i].itemName" + itemSlot[i].itemName);
            itemSlot[i].itemDescription = PlayerPrefs.GetString("ItemDescription_" + i);
        }
        for (int i = 0; i < skillSlot.Length; i++)
        {
            skillSlot[i].skillName = PlayerPrefs.GetString("SkillName_" + i);
            skillSlot[i].skillDescription = PlayerPrefs.GetString("SkillDescription_" + i);
        }

        Debug.Log("entrou no load");
        Debug.Log("item name: " + PlayerPrefs.GetString("ItemName_0"));

    }

}
