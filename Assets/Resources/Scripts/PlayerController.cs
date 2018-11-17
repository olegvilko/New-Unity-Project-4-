﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Unit
{
    public RollBack rollBack1;
    public RollBack rollBack2;
    public RollBack rollBack3;



    private ShootPlayer1 shootPlayer1;
    private ShootPlayer2 shootPlayer2;
    //   [SerializeField]
    //  public float speed = 3f;
    public float jump = 4f;
    //  private int lives = 7;
    public float speedMount = 0.001F;

    // [SerializeField]
    //    private GameObject respawn;

    Vector3 respawnPos;

    float veryBottom = -3.0F;

    //  public Enemy enemy = Enemy.your;

    //   public BackgroundHelper backgroundHelper;

    public RawImage rawImage;

//    private bool animationStatus;

    //  public Collider2D colliderObstracle;

    public GameObject shield;

    int scaleAttack;

//    private bool jumpTrigger = true;
    // Type type;

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
    //   private MonsterLivesBar monsterLivesBar;

    //  [SerializeField]
    //  private GameObject bullet;

    private Rigidbody2D rb;
    //    private bool faceRight = true;
    private Animator animator;
    private bool isGrounded;
    private SpriteRenderer sprite;
    new private Rigidbody2D rigidbody;

    // [SerializeField]
    private Bullet bullet;

    float pos = 0;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    //private void Awake()
    //{
    //    //GameObject panel2;
    //    //panel2=GameObject.Find("UpPanel");
    //    //panel2.gameObject.SetActive(true);

    //    //  respawn = GameObject.Find("Respawn");
    //    //  transform.position = respawn.transform.position;
    ////    respawnPos = transform.position;

    //  //  type = GetComponent<Type>();
    //  //  type.enemy = Enemy.your;


    //    livesBar = FindObjectOfType<LivesBar>();
    //    sprite = GetComponentInChildren<SpriteRenderer>();
    //    rigidbody = GetComponent<Rigidbody2D>();
    //    bullet = Resources.Load<Bullet>("Prefabs/items/BulletPlayer2");
    //    //  monsterLivesBar = FindObjectOfType<MonsterLivesBar>();
    //}

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
            //   if (animationStatus == false)


            if (Input.GetButton("Fire2"))
            {

                State = CharState.Shield;

                shield.SetActive(true);

                if (Input.GetButton("Fire1"))
                {

                   
                    Debug.Log("123");
                    if (rollBack3.timeout)
                    {
                        //shootPlayer1.timeDestroy = 1;
                        //shootPlayer1.Shooting();
                        rollBack3.RollbackStart(0.03f);
                        rigidbody.AddForce(transform.right * transform.localScale.x * -6f, ForceMode2D.Impulse);
                       // shootPlayer1.Shooting();
                    }
                }

            }
            else
            {
                shield.SetActive(false);


                if (isGrounded && !(Input.GetButton("Fire1")))
                {
                    //    if (animationStatus == false)
                    {
                        State = CharState.Idle;
                    }
                }


                if (Input.GetButton("Horizontal"))
                    Run();

                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    Jump();
                }

             //   if (animationStatus == false)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Shoot1();
                    }
                    else if (Input.GetButton("Fire3"))
                    {
                        Shoot2();
                    }
                }
            }

            //  Shield();

            CheckVeryBottom();
        }
    }

    private void CheckVeryBottom()
    {
        if (transform.position.y < veryBottom)
            ReceiveDamage();

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //Unit unit = collision.gameObject.GetComponent<Unit>();
    //    //Type typeCollision = collision.GetComponent<Type>();
    //    //if (type.enemy != typeCollision.enemy)
    //    //{
    //    //  //  ReceiveDamage();
    //    //}


    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // tag = collision.gameObject.tag;
        //      Debug.Log(collision.gameObject.name);
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

    //IEnumerator ShootCoroutine1()
    //{
    //    rollBack.RollbackStart(shootPlayer1.interval);
    //    yield return new WaitForSeconds(shootPlayer1.interval);
    //    animationStatus = false;
    //    yield return null;
    //}

    private void Shoot2()
    {
        //StartCoroutine(ShootCoroutine2());
        //State = CharState.Attack;
        //animationStatus = true;
        //shootPlayer2.Shooting();
        if (rollBack2.timeout)
        {
            rollBack2.RollbackStart(shootPlayer2.interval);
            State = CharState.Attack;
            shootPlayer2.Shooting();
        }
    }

    //IEnumerator ShootCoroutine2()
    //{
    //    yield return new WaitForSeconds(shootPlayer2.interval);
    //    animationStatus = false;
    //    yield return null;
    //}

    //void Attack()
    //{

    //Vector3 position = transform.position;
    //position.y += 0.25F;
    //position.x -= 0.15F * scaleAttack;

    //Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation);
    //Unit unit = newBullet.GetComponent<Unit>();
    //unit.enemy = Enemy.your;

    //newBullet.Direction = newBullet.transform.right * scaleAttack * -1;
    //newBullet.Parent = gameObject;

    //newBullet.transform.localScale = new Vector3(scaleAttack * -1, 1, 1);
    //newBullet.scaleAdd = -0.3F * scaleAttack;
    //newBullet.timeDestroy = 0.1F;
    //  }

    private void FixedUpdate()
    {
        CheckGround();

        //Vector3 pos=transform.position;
        //pos.x -= 0.1F;
        //pos.y += 0.3F;
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, 0.1f);
        //isGrounded = colliders.Length > 2;
        //if (!isGrounded)
        //{
        //    Debug.Log("23423");
        //}
    }

    void Run()
    {
        float right = Input.GetAxis("Horizontal");
        Vector3 direction = transform.right * right;
        float run = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, run);

        // sprite.flipX = direction.x < 0.0F;

        if (right > 0) scaleAttack = -1;
        else scaleAttack = 1;

        transform.localScale = new Vector3(scaleAttack, 1, 1);



        if (isGrounded)
            State = CharState.Run;

        // float sp = 0.0003F;        
        pos += speedMount * right * Time.deltaTime;
        if (pos > 1.0F)
            pos -= 1.0F;
        rawImage.uvRect = new Rect(pos, 0, 1, 1);
    }

    void Jump()
    {
        //   jumpTrigger=false;
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }

    void CheckGround()
    {
        //  Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.02f);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector3(transform.position.x - 0.02F, transform.position.y - 0.02F, transform.position.z), 0.02f);

        isGrounded = colliders.Length > 0;

        if (!isGrounded)
        {
            //        jumpTrigger = false;
            State = CharState.Jump;
        }
        else
        {
            //        jumpTrigger = true;
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
            //   transform.position = respawn.transform.position;
            transform.position = respawnPos;
        }
        //   Debug.Log(lives);

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 3.0F, ForceMode2D.Impulse);

    }
}
