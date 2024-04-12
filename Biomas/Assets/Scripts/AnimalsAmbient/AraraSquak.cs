using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AraraSquak : MonoBehaviour
{
    public Animator araraAnimator;
    public float intervaloSquak = 5f;

    public AudioSource src;
    public AudioClip sfx;

    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!IsInvoking("ActivateSquak"))
            {
                InvokeRepeating("ActivateSquak", 0f, intervaloSquak);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            CancelInvoke("ActivateSquak");
        }
    }

    void ActivateSquak()
    {
        if (playerInRange)
        {
            araraAnimator.SetBool("squak", true);
            src.clip = sfx;
            src.Play();
            StartCoroutine(ResetSquak());
        }
    }

    IEnumerator ResetSquak()
    {
        yield return new WaitForSeconds(0.1f);
        araraAnimator.SetBool("squak", false);
    }
}
