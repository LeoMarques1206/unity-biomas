using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] //faz a variavel ser visivel e editavel na unity
    private string skillName;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string skillDescription;

    public GameObject player;
    private PlayerMovement playerMovement;

    // public AudioSource src;
    // public AudioClip sfx;

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        inventoryManager = GameObject.Find("Player").transform.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void GiveItem()
    {
        if(playerMovement.MedalhaoSapo == false)
        {
            inventoryManager.AddSkill(skillName, sprite, skillDescription);
        }
    }
}
