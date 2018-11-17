using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

    [SerializeField]
    float posY = 1;
    [SerializeField]
    float posZ = -10.0F;
	
	void Update () {
        transform.position = new Vector3(LinksManager.player.transform.position.x, LinksManager.player.transform.position.y+posY,posZ);
	}
}
