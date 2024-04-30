using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetBool("Sorriu", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
