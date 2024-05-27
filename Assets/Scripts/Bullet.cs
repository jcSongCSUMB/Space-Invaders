using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public float speed = 5;
  public GameObject collisionFX;

  void Start()
  {
    myRigidbody2D = GetComponent<Rigidbody2D>();
    Fire();
  }

  private void Fire()
  {
    myRigidbody2D.velocity = Vector2.up * speed;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "Enemy Type 1" 
        || other.gameObject.tag == "Enemy Type 2" || other.gameObject.tag == "Enemy Type 3")
    {
      Instantiate(collisionFX, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
  }
}

