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
        for (int i = 0; i < skillSlot.Length; i++)
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
            if (itemSlot[i].itemSprite != null && itemSlot[i].itemSprite.texture != null)
            {
                Texture2D uncompressedTexture = new Texture2D(itemSlot[i].itemSprite.texture.width, itemSlot[i].itemSprite.texture.height, TextureFormat.RGBA32, false);
                uncompressedTexture.SetPixels(itemSlot[i].itemSprite.texture.GetPixels());
                uncompressedTexture.Apply();
                byte[] pngData = uncompressedTexture.EncodeToPNG();
                string spriteData = System.Convert.ToBase64String(pngData);
                PlayerPrefs.SetString("ItemSprite_" + i, spriteData);
            }
        }
        for (int i = 0; i < skillSlot.Length; i++)
        {
            PlayerPrefs.SetString("SkillName_" + i, skillSlot[i].skillName);
            PlayerPrefs.SetString("SkillDescription_" + i, skillSlot[i].skillDescription);
            if(skillSlot[i].skillSprite != null && skillSlot[i].skillSprite.texture != null)
            {
                Texture2D uncompressedTexture = new Texture2D(skillSlot[i].skillSprite.texture.width, skillSlot[i].skillSprite.texture.height, TextureFormat.RGBA32, false);
                uncompressedTexture.SetPixels(skillSlot[i].skillSprite.texture.GetPixels());
                uncompressedTexture.Apply();
                byte[] pngData = uncompressedTexture.EncodeToPNG();
                string spriteData = System.Convert.ToBase64String(pngData);
                PlayerPrefs.SetString("SkillSprite_" + i, spriteData);
            }
        }
        PlayerPrefs.Save();

        Debug.Log("entrou no save");
    }

    private void LoadSlotData()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].itemName = PlayerPrefs.GetString("ItemName_" + i);
            // Debug.Log("itemSlot[i].itemName" + itemSlot[i].itemName);
            itemSlot[i].itemDescription = PlayerPrefs.GetString("ItemDescription_" + i);

            string spriteData = PlayerPrefs.GetString("ItemSprite_" + i);
            if (!string.IsNullOrEmpty(spriteData))
            {
                byte[] textureData = System.Convert.FromBase64String(spriteData);
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(textureData);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                itemSlot[i].itemSprite = sprite;
                itemSlot[i].itemImage.sprite = sprite;
                itemSlot[i].isFull = true;
                itemSlot[i].itemImage.enabled = itemSlot[i].isFull;
            }
        }
        for (int i = 0; i < skillSlot.Length; i++)
        {
            skillSlot[i].skillName = PlayerPrefs.GetString("SkillName_" + i);
            skillSlot[i].skillDescription = PlayerPrefs.GetString("SkillDescription_" + i);

            string spriteData = PlayerPrefs.GetString("SkillSprite_" + i);
            if (!string.IsNullOrEmpty(spriteData))
            {
                byte[] textureData = System.Convert.FromBase64String(spriteData);
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(textureData);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                skillSlot[i].skillSprite = sprite;
                skillSlot[i].skillImage.sprite = sprite;
                skillSlot[i].isFull = true;
                skillSlot[i].skillImage.enabled = itemSlot[i].isFull;
            }
        }

        Debug.Log("entrou no load");
        Debug.Log("item name: " + PlayerPrefs.GetString("ItemName_0"));

    }

}
