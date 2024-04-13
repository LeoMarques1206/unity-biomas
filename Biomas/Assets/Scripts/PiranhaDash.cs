using UnityEngine;
using System.Collections;

public class PiranhaDash : MonoBehaviour
{
    public float retreatDistance = 1f;
    public float advanceDistance = 1f;
    public float retreatSpeed = 1f;
    public float advanceSpeed = 1f;
    public float returnSpeed = 1f;
    public float delayBeforeReturn = 1f;
    public Animator animator;

    private Vector3 initialPosition;
    private bool triggered = false;
    private bool reachedTop = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            StartCoroutine(Sequence());
        }
    }

    IEnumerator Sequence()
    {
        Vector3 retreatPosition = transform.position - new Vector3(0f, retreatDistance, 0f);
        while (Vector3.Distance(transform.position, retreatPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, retreatPosition, retreatSpeed * Time.deltaTime);
            yield return null;
            animator.SetBool("Dash", true);
        }

        yield return new WaitForSeconds(delayBeforeReturn);

        Vector3 advancePosition = transform.position + new Vector3(0f, advanceDistance, 0f);
        while (Vector3.Distance(transform.position, advancePosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, advancePosition, advanceSpeed * Time.deltaTime);
            if (transform.position.y >= advancePosition.y && !reachedTop)
            {
                reachedTop = true;
                FlipHorizontal();
            }
            yield return null;
        }

        while (Vector3.Distance(transform.position, initialPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
            yield return null;
        }

        triggered = false; // Resetar o gatilho
        reachedTop = false; // Resetar a flag de chegada ao topo
        ResetFlip(); // Resetar o flip 
        animator.SetBool("Dash", false);
    }

    void FlipHorizontal()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void ResetFlip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    
}
