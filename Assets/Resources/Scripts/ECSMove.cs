using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ECSMove : MonoBehaviour
{
    public GameObject parent;

    public float speed;


    //void Update () {
    //       transform.Rotate(0f, speed*Time.deltaTime, 0f);
    //}
}

class RotatorSystem : ComponentSystem
{
    protected Vector3 direction;

    struct Components
    {
        public ECSMove rotator;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
   //     Debug.Log("2134");
        //  throw new System.NotImplementedException();
        float deltaTime = Time.deltaTime;

        foreach (var e in GetEntities<Components>())
        {
            // e.transform.Rotate(e.rotator.speed * deltaTime,0f, 0f);
            // parent.transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            direction = e.rotator.parent.transform.right;
            e.rotator.parent.transform.position = Vector3.MoveTowards(e.rotator.parent.transform.position, e.rotator.parent.transform.position + direction, e.rotator.speed * Time.deltaTime);
        }
    }

}