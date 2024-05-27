using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float speed = 2.5f;
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.down * speed; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
