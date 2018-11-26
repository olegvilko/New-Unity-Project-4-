using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableMonster : Monster {

    public int rotationX;

    protected override void Awake()
    {  

    }

    protected override void Start()
    {

    }

    protected override void Update()
    {
      //  RotationToPlayer();
         Rotation();   
    }

    void Rotation()
    {
        if (transform.position.x - LinksManager.player.transform.position.x < 0)
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        else
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
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
}
