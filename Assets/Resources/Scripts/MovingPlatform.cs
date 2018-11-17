using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : TypeObject
{

    [SerializeField]
    private Vector3 radius = new Vector2(1, 0);

    [SerializeField]
    private float speed = 1.0f;

    private Vector2 centre;

    private Vector3 direction;
    // Use this for initialization
    void Start()
    {
        direction = radius;
        centre.x = transform.position.x;
        centre.y = transform.position.y;
    }

    //// Update is called once per frame
    void Update()
    {
        Move();
        if (Mathf.Abs(transform.position.x - centre.x) > radius.x)
        {
            direction.x = -direction.x;
        }

        if (Mathf.Abs(transform.position.y - centre.y) > radius.y)
        {
            direction.y = -direction.y;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position+direction, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    //    Debug.Log(collision.transform.parent.gameObject);
        //if (collision.transform.parent.gameObject.tag!=null)
        //{
        //    collision.transform.parent.gameObject.transform.parent = gameObject.transform;
        //}
        //else
        //{
            collision.transform.parent = transform;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}
