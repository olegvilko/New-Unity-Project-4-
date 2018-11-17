using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;
using UnityEngine.UI;

public class Monster : Unit
{
    int way = 1;

    protected virtual void Start()
    {
       
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
            if (way == -1)
            {
                way = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
        }
        else
        {
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
