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

    private GameObject heart;

    private MonsterLivesBar monsterLivesBar;

    protected virtual void Awake()
    {
        livesMax = lives;
    }

    public enum Enemy
    {
        your,
        enemy
    }

    public virtual void ReceiveDamage()
    {
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
    }
}
