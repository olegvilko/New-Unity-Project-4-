using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer2 : Shoot {

    //protected override void Start()
    //{
    //    Debug.Log("explo");
    //    explosion = LinksManager.explosion2;
    //}

    protected override void Update()
    {
        
    }

    public override void Shooting()
    {
        base.Shooting();
        newBullet.explosion = LinksManager.explosion2;
      //  newBullet.blastRadius = ;
    }
}
