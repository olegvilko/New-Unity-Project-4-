using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gayser : MonoBehaviour
{
    [SerializeField]
    private float impulse = 3.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * impulse, ForceMode2D.Impulse);
    }
}
