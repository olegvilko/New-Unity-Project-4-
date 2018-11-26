using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

 //   public int maxParticles=10;

 //   private ParticleSystem particleSystem;

    [SerializeField]
    private float timeDestroy = 0.1F;

    void Start () {
 //       particleSystem = GetComponentInChildren<ParticleSystem>();
 //       particleSystem.maxParticles = maxParticles;

        Destroy(gameObject, timeDestroy);
    }
	
	
}
