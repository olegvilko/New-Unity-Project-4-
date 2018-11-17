using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Unit
{
   // Type type;

  //  public Vector3 Direction { set { direction = value; } }
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

 //   public float speed = 4.0F;
    private SpriteRenderer sprite;

    private GameObject explosion;
 //   private Vector3 direction;

    //private void Awake()
    //{
    //    sprite = GetComponentInChildren<SpriteRenderer>();
    //    type = GetComponent<Type>();
    //}

    protected override void Awake()
    {
        base.Awake();
    //    type = GetComponent<Type>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //   explosion = Resources.Load("Prefabs/items/Particles/particle1") as GameObject;
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
        //  OnDestroy1();

        //  transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        //   transform.localScale = new Vector3(transform.localScale.x + scaleAdd, transform.localScale.y + Mathf.Abs(scaleAdd), transform.localScale.z + scaleAdd);
        transform.localScale = new Vector3(transform.localScale.x + scaleAdd*direction, transform.localScale.y + scaleAdd*direction,0);
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

        //if (collision.tag == "shield")
        //{
        //    // Debug.Log(collision.tag);
        //    Destroy(gameObject);
        //}
        //else
        //{
        TypeObject typeObject = collision.GetComponent<TypeObject>();   

           

            // if(type.enemy != typeCollision.enemy)
            //Debug.Log(typeCollision.enemy);
        //    Debug.Log(typeCollision.obj);

            if (typeObject && typeObject.obj == Obj.terrain)
            {
                Destroy(gameObject);
            }
            else
            {

            
         //   Type typeCollision = collision.GetComponent<Type>();
     //    Unit unit = collision.GetComponent<Unit>();
            Unit unit = collision.GetComponent<Unit>();

            //if (collision.tag == "bullet2")
            //{
            //    Debug.Log("123");
            //}
                if (unit && unit.gameObject != parent && unit.enemy != enemy)
                {
                    unit.ReceiveDamage();
                    Destroy(gameObject);
                }
            }
        }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position,transform.rotation);
    }
    //  //  Debug.Log("Destroy");
    //    float radius = 5.0F;
    //    float power = 100.0F;
    //    Vector3 explosionPos = transform.position;
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius); //OverlapSphere2D(explosionPos, radius);
    //   // Debug.Log(colliders.Length);
    //    foreach (Collider2D hit in colliders)
    //    {
    //    //    Debug.Log(hit.transform.tag);
    //        Rigidbody rb = hit.GetComponent<Rigidbody>();

    //        if (rb != null)
    //            rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
    //    }
    //}
    // }
}
