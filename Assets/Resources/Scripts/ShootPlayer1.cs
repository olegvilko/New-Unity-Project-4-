using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer1 : Shoot {

    protected override void Start()
    {
        bullet = Resources.Load<Bullet>("Prefabs/items/BulletPlayer2");
    }

    protected override void Update()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetButton("Fire1"))
    //    {
    //        Shooting();
    //    }
    //}
}
