using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MoveableMonster
{
    [SerializeField]
    private float radius = 1;

    private float centre;

    protected override void Start()
    {
        base.Start();
        centre = transform.position.x;
    }
    //private void Start()
    //{
    //    centre = transform.position.x;
    //}

    protected override void Update()
    {
        //  base.Update();
        Move();
        if (Mathf.Abs(transform.position.x - centre) > radius)
        {
            Turn();
        }
    }
    //protected override void Update()
    //{

    //   // Move();
    //}

    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}
