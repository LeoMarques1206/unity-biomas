using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager.Requests;
using System;

public class RequestTrash : MonoBehaviour
{
    public GameObject request;
    public ContaLixo contaLixo;
    private TextMeshProUGUI score;

    void Start() 
    {
        score = request.GetComponent<TextMeshProUGUI>();

    }
    void Update()
    {   
        score.text = contaLixo.numLixo.ToString();
    }

}
 