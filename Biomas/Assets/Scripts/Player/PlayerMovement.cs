using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 7f;
    private bool isFacingRight = true;
    public Animator animator;

    public AudioSource src;
    public AudioClip sfx;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

       
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            if(IsGrounded()){
                CreateDust();
            }
        }
    }

    private void UpdateAnimator()
    {
        bool isWalking = Mathf.Abs(horizontal) > 0.1f;
        animator.SetBool("Walk", isWalking);
    }

    void CreateDust(){
        dust.Play();
    }

    public void Death()
    {
        animator.SetBool("Dead", true);
        Debug.Log("Morreu");
        rb.bodyType = RigidbodyType2D.Static;
        Invoke("sceneReset", 1.2f);
        src.clip = sfx;
        src.Play();
        
    }

    public void sceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
