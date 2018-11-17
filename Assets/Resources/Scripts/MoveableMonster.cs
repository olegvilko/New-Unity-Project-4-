using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster
{
   // public Enemy enemy = Enemy.enemy;

  //  [SerializeField]
 //   protected float speed = 1.0F;

  //  private SpriteRenderer sprite;

    protected Vector3 direction;

    //private void Start()
    //{
    //    direction = -transform.right;
    //}

    protected override void Start()
    {
        base.Start();
        direction = -transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.2F + transform.right * direction.x * 0.2F, 0.01F);
        if (colliders.Length == 0)
        {
            Turn();
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
   //     Debug.Log("test");
        base.OnTriggerEnter2D(collision);

        TypeObject typeObject = collision.GetComponent<TypeObject>();

        if (typeObject && typeObject.obj == Obj.terrain)
        {
            //direction = -direction;
            //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                 Turn();
        }

    }

    protected void Turn()
    {
        direction = -direction;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    //private void Move()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.14F + transform.right * direction.x * 0.2F, 0.01F);

    //    if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<PlayerController>()))
    //    {
    //        direction *= -1.0F;
    //    }

    //    colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.2F + transform.right * direction.x * 0.2F, 0.01F);
    //    if (colliders.Length == 0)
    //    {
    //        direction *= -1.0F;
    //    }

    //    transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    //}
}
