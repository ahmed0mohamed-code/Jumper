using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D body;
    public float speed ;
    public float JumpPower;
    public float gravityScale;
    public GameObject ground;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public LayerMask groundLayer;
    public LayerMask land;
    private float WallJumpCoolDown;
    private float horizontalinput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");

        if(horizontalinput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalinput < 0.01f)
        {
            transform.localScale = new Vector3( -1, 1, 1);
        }

        anim.SetBool("Run", horizontalinput != 0);
        anim.SetBool("Jump", !isGrounded() && !islayerd());

        body.linearVelocity = new Vector2(horizontalinput * speed, body.linearVelocityY);

        if (Input.GetKey(KeyCode.Space))
        {
            if (WallJumpCoolDown > 0.2f)
            {
                jump();
            }
        }
        if (WallJumpCoolDown <= 0.2f)
        {
            WallJumpCoolDown += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (islayerd())
        {
            ground.transform.position = new Vector2(0, 10);
        }
    }
    private void jump()
    {
        if (isGrounded() || islayerd())
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, JumpPower);
            anim.SetTrigger("Jump");
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,Vector2.down, 0.1f, groundLayer);
        return rayCastHit.collider != null;
    }
    private bool islayerd()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, land);
        return rayCastHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("loser"))
        {
            Object.FindFirstObjectByType<gameManager>().Gameover();
        }
        else if (collision.CompareTag("scoringland"))
        {
            Object.FindFirstObjectByType<gameManager>().Increascore();
            Destroy(collision.gameObject);
        }
    }
}
