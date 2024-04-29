using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextAppearing : MonoBehaviour
{
    //Quadro 1
    public GameObject pedro;
    public GameObject violeta;
    public GameObject pedroText, violetaText;
    private Dialogue dialoguePedro;
    private Dialogue dialogueVioleta;

    //Quadro 2
    public GameObject pedro2;
    public GameObject violeta2;
    public GameObject text2;
    private Dialogue dialogue2;

    //Quadro 3
    public GameObject pedro3;
    public GameObject violeta3;
    public GameObject text3;
    private Dialogue dialogue3;

    //Quadro 4
    public GameObject text4;
    private Dialogue dialogue4;

    //Clique
    public GameObject text5;
    private Dialogue dialogue5;
    private bool podeClicar = false;

    void Start()
    {
        dialoguePedro = pedroText.GetComponent<Dialogue>();
        dialogueVioleta = violetaText.GetComponent<Dialogue>();
        dialogue2 = text2.GetComponent<Dialogue>();
        dialogue3 = text3.GetComponent<Dialogue>();
        dialogue4 = text4.GetComponent<Dialogue>();
        dialogue5 = text5.GetComponent<Dialogue>();

        dialoguePedro.gameObject.SetActive(true);
        
        // Quadro 1
        pedro.SetActive(false);
        violeta.SetActive(false);

        // Quadro 2
        violeta2.SetActive(false);
        pedro2.SetActive(false);

        // Quadro 3
        violeta3.SetActive(false);
        pedro3.SetActive(false);

        //Quadro 4
        //Quadro 5
        
        //Invocando as funções
        Invoke("PedroText", 1f);
        Invoke("VioletaText", 2f);
        Invoke("Text2", 5f);
        Invoke("Text3", 9f);
        Invoke("Text4", 13f);
        Invoke("Text5", 15f);
    }
    void Update()
    {
        if(podeClicar)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("StartRoom");
            }
        }
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
    void Text2()
    {
        dialogue2.gameObject.SetActive(true);
        violeta2.SetActive(true);
        pedro2.SetActive(true);
        dialogue2.StartDialogue();
    }
    void Text3()
    {
        dialogue3.gameObject.SetActive(true);
        violeta3.SetActive(true);
        pedro3.SetActive(true);
        dialogue3.StartDialogue();
    }
    void Text4()
    {
        dialogue4.gameObject.SetActive(true);
        dialogue4.StartDialogue();
    }
    void Text5()
    {
        dialogue5.gameObject.SetActive(true);
        dialogue5.StartDialogue();
        podeClicar = true;
    }
    
}
