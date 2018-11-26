using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Entities;


public class MoveableMonster : Monster
{
   // public TestMoveAll testMoveAll;

    protected Vector3 direction;

    protected override void Start()
    {
  //      LinksManager.testMoveAll.gameObjects.Add(parent);

        base.Start();
        direction = transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.2F + transform.right * direction.x * 0.2F, 0.01F);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(parent.transform.position + parent.transform.up * -0.2F + parent.transform.right * direction.x * 0.2F, 0.01F);
        if (colliders.Length == 0)
        {
            Turn();
        }

        parent.transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        TypeObject typeObject = collision.GetComponent<TypeObject>();

        if (typeObject && typeObject.obj == Obj.terrain)
        {
            Turn();
        }

    }

    protected void Turn()
    {
        direction = -direction;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    //    parent.transform.localScale = new Vector3(-parent.transform.localScale.x, parent.transform.localScale.y, parent.transform.localScale.z);
    }


    //class RotatorSystem : ComponentSystem
    //{
    //    protected Vector3 direction;

    //    struct Components
    //    {
    //        //public ECSMove rotator;
    //        public Transform transform;
    //        public MoveableMonster moveableMonster;
    //    }

    //    protected override void OnUpdate()
    //    {
    //        Debug.Log("2134");
    //        //  throw new System.NotImplementedException();
    //        float deltaTime = Time.deltaTime;

    //        foreach (var e in GetEntities<Components>())
    //        {
    //            // e.transform.Rotate(e.rotator.speed * deltaTime,0f, 0f);
    //            // parent.transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    //            direction = e.moveableMonster.parent.transform.right;
    //            e.moveableMonster.parent.transform.position = Vector3.MoveTowards(e.moveableMonster.parent.transform.position, e.moveableMonster.parent.transform.position + direction, e.moveableMonster.speed * Time.deltaTime);
    //        }
    //    }

    //}
}
