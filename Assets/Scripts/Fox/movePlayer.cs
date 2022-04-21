using UnityEngine;

public class movePlayer : MonoBehaviour
{
    [SerializeField] private float speed =  2;
    [SerializeField] private float jumpPower = 6.5f;
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float croundSpeed = 0.5f;
    [SerializeField] private int totalJumps;
    int availableJumps;


    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform overheadCheckCollider;
    
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Collider2D standingCollider;
    Rigidbody2D rb;
    Animator animator;
    

    const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    float horizontalValue;

    bool isGround = true;
    bool facingRight = true;
    bool isRunning ;
    bool isCround ;
    bool multipleJump;
    bool isDead;

    void Awake()
    {
        availableJumps = totalJumps;

        animator =GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("yVelocity", rb.velocity.y);

        // bật nút shilft là chạy nhanh
        #region shift run
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;
        #endregion

        #region jump
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        #endregion

        #region cround
        if (Input.GetButtonDown("Cround"))
        {
            isCround = true;
        }
        if (Input.GetButtonUp("Cround"))
        {
            isCround = false;
        }
        #endregion
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, isCround);
    }

    void GroundCheck()
    {
        #region groundcheck
        bool wasGround = isGround;
        isGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);

        if(colliders.Length > 0)
        {
            isGround = true;
            if (!wasGround)
            {
                availableJumps = totalJumps;
            }

            foreach(var c in colliders)
            {
                if(c.tag == "MovingPlatform")
                {
                    transform.parent = c.transform;
                }
            }
        }
        else
        {
            transform.parent=null;
        }


        animator.SetBool("Jump", !isGround);

        #endregion
    }

    private void Jump()
    {
        if (isGround)
        {
            multipleJump = true;
            availableJumps--;

            rb.velocity = Vector2.up * jumpPower;
            animator.SetBool("Jump", true);
        }
        else
        {
            if (multipleJump && availableJumps>0)
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
            }
        }
    }
    void Move(float dir ,bool croundFlag)
    {
        #region Cround

        if (!croundFlag)
        {
            if (Physics2D.OverlapCircle(overheadCheckCollider.position,overheadCheckRadius,groundLayer))
            {
                croundFlag = true;
            }
        }

        animator.SetBool("Cround", croundFlag);
        standingCollider.enabled = !croundFlag;

        #endregion
        #region walk and run
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;

        if (isRunning)
        {
            xVal *= runSpeed;
        }
        if (croundFlag)
        {
            xVal *= croundSpeed;
        }


        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;


        if(facingRight && dir <0)
        {
            transform.localScale = new Vector3(-1,1,1)*3;
            facingRight = false;
        }
        else if(!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1,1,1)*3;
            facingRight =true;
        }
        //Debug.Log(rb.velocity.x);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }

    public void Die()
    {
        isDead = true;
        FindObjectOfType<LevelManager>().Restart();
    }

    public void ResetPlayer()
    {

    }

}
