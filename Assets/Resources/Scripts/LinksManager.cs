using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksManager : MonoBehaviour
{
    public static LinksManager instance = null;

    public static GameObject player;

    public static Bullet bullet;
    public static GameObject explosion;

    public static float hideDistance = 6;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitializeManager();
    }

    private void InitializeManager()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        bullet = Resources.Load<Bullet>("Prefabs/items/Bullet");
        explosion = Resources.Load("Prefabs/items/Particles/particle1") as GameObject;
    }
}
