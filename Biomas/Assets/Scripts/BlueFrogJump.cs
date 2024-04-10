using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFrogJump : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;
    public Animator frogAnimator;
    public float bounce = 20f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            frogAnimator.SetBool("Jumping", true);
            src.clip = sfx;
            src.Play();
        } 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            frogAnimator.SetBool("Jumping", false);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }

}
