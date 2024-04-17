using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatControllerRoom : MonoBehaviour
{
    public Animator catAnimator;
    public Animator playerAnimator;
    public GameObject objectToFlip;
    public GameObject Exclamation;
    public float fadeDuration = 1.0f;
    public GameObject textBox;
    private Dialogue dialogueScript;
    public GameObject player;
    private PlayerMovement playerScript;

    public GameObject seta;
    void Start()
    {
        dialogueScript = textBox.GetComponent<Dialogue>();
        playerScript = player.GetComponent<PlayerMovement>();
        Exclamation.SetActive(false);
        textBox.SetActive(false);
        seta.SetActive(false);
        playerScript.canMove = false;
        StartCoroutine(ActivateScaryAfterDelay(3.5f));
        StartCoroutine(FlipAfterDelay(3.8f));
        StartCoroutine(ActivateJumpAfterDelay(4.5f));
        StartCoroutine(FadeOutCatAfterDelay(5.4f));
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
        Invoke("SurpriseEmoteAfterDelay", 3f);
    }

    void SurpriseEmoteAfterDelay()
    {
        //Exclamation.SetActive(true);
        textBox.SetActive(true);
        dialogueScript.StartDialogue();
        playerScript.canMove = true;
        seta.SetActive(true);
    }
}
