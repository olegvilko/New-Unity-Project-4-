using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    [SerializeField]
    private float timeDestroy = 0.1F;

    void Start () {
        Destroy(gameObject, timeDestroy);
    }
	
	
}
