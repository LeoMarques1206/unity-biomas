using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrigger : MonoBehaviour
{
    public Animator birdAnimator;
    public Animator birdAnimator2;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            birdAnimator.SetBool("Fly", true);
            birdAnimator2.SetBool("Fly", true);
            Debug.Log("Entrou");
        }
    }

    void update()
    {
        birdAnimator.SetBool("Fly", false);
        birdAnimator2.SetBool("Fly", false);
    }
}
