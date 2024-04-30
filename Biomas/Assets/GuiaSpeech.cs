using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuiaSpeech : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx;
    private bool flag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !flag)
        {
            // Debug.Log("entrou no audio");
            src.clip = sfx;
            src.Play();
            flag = true;
        } 
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
