using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   [SerializeField]
    protected Vector2 impulse;

    public float interval = 1.0F;

    public float timeDestroy = 3.0f;

    [SerializeField]
    Vector2 translation;

    [SerializeField]
    private Color bulletColor = Color.white;

    [SerializeField]
    protected Bullet bullet;

    public Vector2 scale = new Vector2(1,1);

    [SerializeField]
    protected float scaleAdd = 0;

   private Unit unit;

    private bool triggerShoot=true;

    void Awake()
    {
        if (bullet == null)
        {
            bullet = Resources.Load<Bullet>("Prefabs/items/Bullet");
        }
        unit = GetComponent<Unit>();
    }

    protected virtual void Start()
    {
        triggerShoot = true;
    }

    protected virtual void Update()
    {
        if (triggerShoot)
        {
            triggerShoot = false;
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(interval);
        Shooting();
        triggerShoot = true;
        yield return null;
    }

    private void OnDisable()
    {
        triggerShoot = true;
    }

    public virtual void Shooting()
    {
        int direction = SetDirection();
        Vector3 position = transform.position;
        position.x += translation.x*direction;
        position.y += translation.y;

        Bullet newBullet = Instantiate(bullet, position, transform.rotation);
        newBullet.Parent = gameObject;
        newBullet.color = bulletColor;
        newBullet.timeDestroy = timeDestroy;
        newBullet.enemy = unit.enemy;
        newBullet.scaleAdd = scaleAdd;
        newBullet.scale = scale*direction;

        Rigidbody2D rb;
        rb = newBullet.GetComponent<Rigidbody2D>();
        impulse.x =Mathf.Abs(impulse.x)*direction;
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }

    private int SetDirection()
    {
        if (transform.localScale.x < 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
