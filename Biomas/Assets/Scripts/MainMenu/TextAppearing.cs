using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearing : MonoBehaviour
{
    public GameObject pedro;
    public GameObject violeta;
    public GameObject pedroText, violetaText;
    private Dialogue dialoguePedro;
    private Dialogue dialogueVioleta;
    void Start()
    {
        dialoguePedro = pedroText.GetComponent<Dialogue>();
        dialogueVioleta = violetaText.GetComponent<Dialogue>();

        dialoguePedro.gameObject.SetActive(true);
        

        pedro.SetActive(false);
        violeta.SetActive(false);
        
        Invoke("PedroText", 1f);
        Invoke("VioletaText", 2f);
    }

    void PedroText()
    {
        pedro.SetActive(true);
        dialoguePedro.StartDialogue();
    }

    void VioletaText()
    {
        dialogueVioleta.gameObject.SetActive(true);
        violeta.SetActive(true);
        dialogueVioleta.StartDialogue();
    }
    
}
