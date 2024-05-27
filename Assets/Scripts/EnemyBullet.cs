using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;

    public float speed = 2.5f;
    public GameObject collisionFX;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "Player")
        {
            Instantiate(collisionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

