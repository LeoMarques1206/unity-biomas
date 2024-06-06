using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 7f;
    private bool isFacingRight = true;
    public Animator animator;

    //Death
    public Transform respawnPoint;
    public SpriteRenderer deadFadeRenderer;

    //Medalhoes
    public bool MedalhaoSapo = false;
    public bool MedalhaoCobra = false;
    public bool MedalhaoMico = false;
    //Dash
    public bool canDash = true;
    private bool isDashing;
    public float dashingPower = 2f;
    public float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    //Itens adquiridos 
    public bool hasPeixe = false;
    public bool hasBola = false;
    public bool hasLeite = false;

    public AudioSource src;
    public AudioClip sfx;

    public bool canMove = true;
    //se o wally esta na cena
    public bool hasWally = true;

    private int remainingJumps = 2; // Contador para pulos restantes

    //WallJump
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;
    public float wallJumpDuration;
    public Vector2 wallJumpForce;
    bool wallJumping;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    void Start() 
    {
        // Debug.Log("Tem o peixe? " + hasPeixe);
        LoadSkillsData();
        LoadItensData();
        
    }

    void OnDestroy()
    {
        saveItensData();
    }

    void Update()
    {           
        //Debug.Log("Tem o peixe? " + hasPeixe); 
        //Debug.Log(rb.velocity.y);
        if(isDashing)
        {
            return;
        }

        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && (IsGrounded() || (remainingJumps > 0 && MedalhaoSapo)))
        {
            if (IsGrounded())
            {
                remainingJumps = 1; // Se estiver no chão, resete os pulos restantes para 1
            }
            else if (MedalhaoSapo)
            {
                remainingJumps--; // Se não estiver no chão e tiver o medalhão do sapo, use um pulo restante
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        } else if (Input.GetButtonDown("Jump") && isSliding)
        {
            wallJumping = true;
            Invoke("StopWallJump", wallJumpDuration);
        }
        
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.1f, 0.55f), 0, groundLayer);
        
        if(isWallTouch && !IsGrounded() && horizontal != 0)
        {
            isSliding = true;
        }
        else{
            isSliding = false;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if(Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }

        if(rb.velocity.y > 0)
        {
            animator.SetBool("Jump", true);
        }

        if(rb.velocity.y < 0)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }

        if(rb.velocity.y == 0)
        {
            animator.SetBool("Fall", false);
        }

        if(IsGrounded())
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }

        Flip();
        UpdateAnimator();
    }

    void StopWallJump()
    {
        wallJumping = false;
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            animator.SetBool("Walk", false);
            return;
        }

        if(isDashing)
        {
            animator.SetBool("Dash", true);
            return;
        }else
        {
            animator.SetBool("Dash", false); 
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(MedalhaoMico)
        {
            if(isSliding)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlidingSpeed, float.MaxValue));
            }

            if(wallJumping)
            {
                rb.velocity = new Vector2(-horizontal * wallJumpForce.x, wallJumpForce.y);
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
        }
            
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
            if (IsGrounded())
            {
                CreateDust();
            }
        }
    }

    private void UpdateAnimator()
    {
        if (canMove)
        {
            bool isWalking = Mathf.Abs(horizontal) > 0.1f;
            animator.SetBool("Walk", isWalking);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

    }

    void CreateDust()
    {
        dust.Play();
    }

    public void Death()
    {
        canMove = false;
        animator.SetBool("Dead", true);
        //Debug.Log("Morreu");
        //Invoke("StaticBody", 0.2f);
        Invoke("RespawnPlayer", 0.7f);
        src.clip = sfx;
        src.Play();

        // Iniciar o fade in
        StartFadeIn();
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector2.zero;
        canMove = true;
        animator.SetBool("Dead", false);
        rb.bodyType = RigidbodyType2D.Dynamic;

        // Iniciar o fade out
        StartFadeOut();
    }

    void StartFadeIn()
    {
        StartCoroutine(Fade(deadFadeRenderer, 0f, 1f, 0.2f));
    }

    void StartFadeOut()
    {
        StartCoroutine(Fade(deadFadeRenderer, 1f, 0f, 0.2f));
    }

    IEnumerator Fade(SpriteRenderer renderer, float startAlpha, float endAlpha, float duration)
    {
        Color color = renderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            renderer.color = color;
            yield return null;
        }

        color.a = endAlpha;
        renderer.color = color;
    }

    public void sceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Metodos de save
    public void saveSkillsData(int medalhao) 
    {
        if(medalhao == 1)
        {
            PlayerPrefs.SetInt("SkillSapo", 1);
        } 
        else if(medalhao == 2)
        {
            PlayerPrefs.SetInt("SkillCobra", 1);
        }
        else if(medalhao == 3)
        {
            PlayerPrefs.SetInt("SkillMico", 1);
        }
        PlayerPrefs.Save();
    }

    public void saveItensData()
    {
        if(hasBola)
        {
            PlayerPrefs.SetInt("Bola", 1);
        } 
         
        if(hasPeixe)
        {
            //Debug.Log("Entrou no save peixe");
            PlayerPrefs.SetInt("Peixe", 1);
        } 
        
        if(hasLeite)
        {
            PlayerPrefs.SetInt("Leite", 1);
        }
        
        if(!hasWally)  //Nao ter o wally ao voltar no bioma
        {   
            PlayerPrefs.SetInt("Wally", 1);
        }

        PlayerPrefs.Save();
    }

    //Metodos de load 
    public void LoadSkillsData()
    {
        if(PlayerPrefs.GetInt("SkillSapo") == 1)
        {
            MedalhaoSapo = true;
        }

        if(PlayerPrefs.GetInt("SkillCobra") == 1)
        {
            MedalhaoCobra = true;
        }

        if(PlayerPrefs.GetInt("SkillMico") == 1)
        {
            MedalhaoMico = true;
        }
    }

    public void LoadItensData()
    {

        // Debug.Log("load debug bola " + PlayerPrefs.GetInt("Bola"));
        // Debug.Log("load debug peixe " + PlayerPrefs.GetInt("Peixe"));
        // Debug.Log("load debug leite " + PlayerPrefs.GetInt("Leite"));
        if(PlayerPrefs.GetInt("Bola") == 1)
        {
           // Debug.Log("entro");
            hasBola = true;
        }

        if(PlayerPrefs.GetInt("Peixe") == 1)
        {
           // Debug.Log("ENTROU NESSA PARTE DO CODIGO(PEIXE)");
            hasPeixe = true;
        }

        if(PlayerPrefs.GetInt("Leite") == 1)
        {
            //Debug.Log("ENTROU NESSA PARTE DO CODIGO(LEITE)");
            hasLeite = true;
        }

        if(PlayerPrefs.GetInt("Wally") == 1)
        {
            hasWally = false;
        }
    }

    private IEnumerator Dash()
    {
        if(MedalhaoCobra == true){
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        } 
        
    }
}