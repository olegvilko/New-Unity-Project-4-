﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Unit
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    public float timeDestroy = 0.1F;

    public Vector2 scale;

    public float scaleAdd;

    private float direction;

    public Color color
    {
        set { sprite.color = value; }
    }

    private SpriteRenderer sprite;

    private GameObject explosion;

    protected override void Awake()
    {
        base.Awake();
        sprite = GetComponentInChildren<SpriteRenderer>();
        explosion = LinksManager.explosion;

    }

    private void Start()
    {

        transform.localScale = new Vector3(transform.localScale.x * scale.x, transform.localScale.y * scale.y, transform.localScale.z);
        direction = SetDirection();
        Destroy(gameObject, timeDestroy);
    }

    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + scaleAdd * direction, transform.localScale.y + scaleAdd * direction, 0);
    }

    private int SetDirection()
    {
        if (transform.localScale.x < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TypeObject typeObject = collision.GetComponent<TypeObject>();

        if (typeObject && typeObject.obj == Obj.terrain)
        {
            Destroy(gameObject);
        }
        else
        {

            Unit unit = collision.GetComponent<Unit>();

            if (unit && unit.gameObject != parent && unit.enemy != enemy)
            {
                unit.ReceiveDamage();
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
