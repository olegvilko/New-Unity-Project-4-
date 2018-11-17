using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;
using UnityEngine.UI;

public class Monster : Unit
{
    //[SerializeField]
    //private float scale = 1;

    //  private MonsterLivesBar monsterLivesBar;

    //   protected GameObject player;

    int way = 1;

    //protected virtual void Awake()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //   // type = GetComponent<Type>();
    //    transform.localScale = new Vector3(transform.localScale.x*scale,transform.localScale.y*scale,transform.localScale.z);
    //}

    //protected override void Awake()
    //{
    //    base.Awake();
    //    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

    protected virtual void Start()
    {
        ////      animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponent<Unit>();

        if (unit && unit is PlayerController)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.1F)
            {
                ReceiveDamage();
            }
            else
            {
                unit.ReceiveDamage();
            }
        }
    }

    public void RotationToPlayer()
    {
        if (transform.position.x - LinksManager.player.transform.position.x < 0)
        {

            //    if (transform.localScale.x > 0)
            if (way == -1)
            {
                way = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
        }
        else
        {

            //        if (transform.localScale.x < 0)
            if (way == 1)
            {
                way = -1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
        }
    }

    public void Move(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right * way, speed * Time.deltaTime);
        //  transform.position += Vector3.forward;
    }

    public enum CharState
    {
        Idle,
        Run,
        Jump,
        Attack,
        Shield
    }
}
