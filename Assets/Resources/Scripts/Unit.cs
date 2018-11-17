using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : TypeObject
{
    [SerializeField]
    private GameObject parent;

    public Enemy enemy;

    public int lives = 1;

    [HideInInspector]
    public int livesMax;

    public float speed = 1.0F;

 //   [SerializeField]
  //  public float scale = 1.0F;

    private GameObject heart;

  //  protected Type type;
    private MonsterLivesBar monsterLivesBar;
    //protected GameObject player;

    //  protected virtual void Awake()
    //  {
    ////      player = GameObject.FindGameObjectWithTag("Player");
    //  //    type = this.GetComponent<Type>();
    //      //   Debug.Log("123");

    //  }

    protected virtual void Awake()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        // type = GetComponent<Type>();
        livesMax = lives;
     //  transform.localScale = new Vector3(transform.localScale.x * scale, transform.localScale.y * scale, transform.localScale.z);
    }

    private void Start()
    {
      //  transform.localScale = new Vector3(10, transform.localScale.y * scale, transform.localScale.z);
        //type = this.GetComponent<Type>();
        //Debug.Log("123");
    }
    //public void Awake()
    //{
    //    heart = Resources.Load("Heart") as GameObject;
    //    Debug.Log("Utit");
    //}

    public enum Enemy
    {
        your,
        enemy
    }

    public virtual void ReceiveDamage()
    {
        // Тут надо переделать
        //   type = this.GetComponent<Type>();

        monsterLivesBar = FindObjectOfType<MonsterLivesBar>();


        lives--;
        monsterLivesBar.Refresh(lives, livesMax);

        if (lives <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Тут надо все переделать
        heart = Resources.Load("Prefabs/Heart") as GameObject;
        GameObject newHeart= Instantiate(heart);
        newHeart.transform.position = gameObject.transform.position;

        GameObject splash = Resources.Load("Prefabs/items/Splash") as GameObject;
        GameObject newSplash = Instantiate(splash);
        newSplash.transform.position = gameObject.transform.position;

        Destroy(parent);
//        Destroy(gameObject);
    }
}
