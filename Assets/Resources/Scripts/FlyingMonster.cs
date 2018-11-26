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

    protected override void Update()
    {
        Move();
        if (Mathf.Abs(transform.position.x - centre) > radius)
        {
            Turn();
        }
    }

    protected override void Move()
    {
        // transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        parent.transform.position = Vector3.MoveTowards(transform.position, transform.position - direction, speed * Time.deltaTime);
    }
}
