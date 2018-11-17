using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Unit
{
    public RollBack rollBack1;
    public RollBack rollBack2;
    public RollBack rollBack3;



    private ShootPlayer1 shootPlayer1;
    private ShootPlayer2 shootPlayer2;
    public float jump = 4f;
    public float speedMount = 0.001F;
    Vector3 respawnPos;

    float veryBottom = -3.0F;

    public RawImage rawImage;

    public GameObject shield;

    int scaleAttack;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 8) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private SpriteRenderer sprite;
    new private Rigidbody2D rigidbody;

    private Bullet bullet;

    float pos = 0;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    void Start()
    {
        shootPlayer1 = GetComponent<ShootPlayer1>();
        shootPlayer2 = GetComponent<ShootPlayer2>();

        respawnPos = transform.position;

        livesBar = FindObjectOfType<LivesBar>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        bullet = Resources.Load<Bullet>("Prefabs/items/BulletPlayer2");

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {


            if (Input.GetButton("Fire2"))
            {

                State = CharState.Shield;

                shield.SetActive(true);

                if (Input.GetButton("Fire1"))
                {


                    Debug.Log("123");
                    if (rollBack3.timeout)
                    {
                        rollBack3.RollbackStart(0.03f);
                        rigidbody.AddForce(transform.right * transform.localScale.x * -6f, ForceMode2D.Impulse);
                    }
                }

            }
            else
            {
                shield.SetActive(false);


                if (isGrounded && !(Input.GetButton("Fire1")))
                {
                    State = CharState.Idle;
                }


                if (Input.GetButton("Horizontal"))
                    Run();

                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    Jump();
                }
                if (Input.GetButton("Fire1"))
                {
                    Shoot1();
                }
                else if (Input.GetButton("Fire3"))
                {
                    Shoot2();
                }
            }

            CheckVeryBottom();
        }
    }

    private void CheckVeryBottom()
    {
        if (transform.position.y < veryBottom)
            ReceiveDamage();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "vertical")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

    void Log()
    {
        Debug.Log("Test");
    }

    void Shield()
    {
        shield.SetActive(true);
    }

    private void Shoot1()
    {
        if (rollBack1.timeout)
        {
            rollBack1.RollbackStart(shootPlayer1.interval);
            State = CharState.Attack;
            shootPlayer1.Shooting();
        }
    }

    private void Shoot2()
    {
        if (rollBack2.timeout)
        {
            rollBack2.RollbackStart(shootPlayer2.interval);
            State = CharState.Attack;
            shootPlayer2.Shooting();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Run()
    {
        float right = Input.GetAxis("Horizontal");
        Vector3 direction = transform.right * right;
        float run = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, run);

        if (right > 0) scaleAttack = -1;
        else scaleAttack = 1;

        transform.localScale = new Vector3(scaleAttack, 1, 1);

        if (isGrounded)
            State = CharState.Run;
        
        pos += speedMount * right * Time.deltaTime;
        if (pos > 1.0F)
            pos -= 1.0F;
        rawImage.uvRect = new Rect(pos, 0, 1, 1);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector3(transform.position.x - 0.02F, transform.position.y - 0.02F, transform.position.z), 0.02f);

        isGrounded = colliders.Length > 0;

        if (!isGrounded)
        {
            State = CharState.Jump;
        }
    }

    public enum CharState
    {
        Idle,
        Run,
        Jump,
        Attack,
        Shield
    }

    public override void ReceiveDamage()
    {
        Lives--;

        if (Lives <= 0)
        {
            Lives = 7;
            transform.position = respawnPos;
        }
    
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 3.0F, ForceMode2D.Impulse);

    }
}
