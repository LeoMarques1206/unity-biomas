using System.Collections;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator catAnimator;
    public Animator playerAnimator;
    public GameObject objectToFlip;
    public GameObject Exclamation;
    public float fadeDuration = 1.0f;

    void Start()
    {
        Exclamation.SetActive(false);

        StartCoroutine(ActivateScaryAfterDelay(3.5f));
        StartCoroutine(FlipAfterDelay(3.8f));
        StartCoroutine(ActivateJumpAfterDelay(4.5f));
        StartCoroutine(FadeOutCatAfterDelay(5.4f));
        StartCoroutine(SurpriseEmoteAfterDelay(6.2f));
        StartCoroutine(SurpriseOutAfterDelay(6.6f));
    }

    IEnumerator ActivateScaryAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        catAnimator.SetBool("Scary", true);
    }

    IEnumerator ActivateJumpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        catAnimator.SetBool("Scary", false);
        catAnimator.SetBool("Jump", true);
    }

    IEnumerator FadeOutCatAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SpriteRenderer catSpriteRenderer = GetComponent<SpriteRenderer>();
        if (catSpriteRenderer != null)
        {
            Color originalColor = catSpriteRenderer.color;
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / fadeDuration);
                catSpriteRenderer.color = Color.Lerp(originalColor, Color.clear, t);
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }

    IEnumerator FlipAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToFlip.transform.localScale = new Vector3(-objectToFlip.transform.localScale.x, objectToFlip.transform.localScale.y, objectToFlip.transform.localScale.z);
    }

    IEnumerator SurpriseEmoteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Exclamation.SetActive(true);
    }

    IEnumerator SurpriseOutAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Exclamation.SetActive(false);
        Debug.Log("oi");
    }
}
