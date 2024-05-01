using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class SkillSlot : MonoBehaviour, IPointerClickHandler
{
    //INICIO DOS DADOS DA SKILL
    public string skillName;
    public Sprite skillSprite;
    public bool isFull;
    public string skillDescription;
    //FIM DOS DADOS DA SKILL

    //INICIO DO SLOT DA SKILL
    [SerializeField]
    public Image skillImage;
    public GameObject selectedShader;
    public bool thisSkillSelected;
    //FIM DO SLOT DA SKILL

    //INICIO DA DESCRICAO DO SLOT DA SKILL
    public Image skillDescriptionImage;
    public TMP_Text SkillDescriptionNameText;
    public TMP_Text SkillDescriptionText;

    //FIM DA DESCRICAO DO SLOT DA SKILL

    private InventoryManager inventoryManager;
    
    public void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddSkill(string skillName, Sprite skillSprite, string skillDescription)
    {
        this.skillName = skillName;
        this.skillSprite = skillSprite;
        this.skillDescription = skillDescription;
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
        thisSkillSelected = true;
        // Debug.Log("Sprite da skill" + skillSprite);

        if (skillSprite != null && skillName != null && skillDescription != null)
        {
            SkillDescriptionNameText.text = skillName;
            SkillDescriptionText.text = skillDescription;
            skillDescriptionImage.sprite = skillSprite;
            skillDescriptionImage.enabled = true;
            // Debug.Log("skill description" + skillDescriptionImage.sprite);
        } 
        else if(skillSprite == null)
        {          
            SkillDescriptionNameText.text = "";
            SkillDescriptionText.text = "";
            skillDescriptionImage.enabled = false;
        }
    }

    public void OnRightClick()
    {

    }

    public void UpdateUI()
    {
        skillImage.sprite = skillSprite;
        skillImage.enabled = isFull;
        Debug.Log(isFull);
        // SkillDescriptionNameText.text = skillName;
        // SkillDescriptionText.text = skillDescription;

        // if (skillSprite != null)
        // {
        //     skillDescriptionImage.sprite = skillSprite;
        // }
    }
}
