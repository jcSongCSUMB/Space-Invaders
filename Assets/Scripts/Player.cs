using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;

    private Rigidbody2D rBody;
    private float movementPerSecond = 5.0f;

    private void Start()
    {
        Enemy.OnEnemyDestroyed += EnemyOnOnEnemyDestroyed;
        rBody = GetComponent<Rigidbody2D>();
    }


    private void OnDestroy()
    {
        Enemy.OnEnemyDestroyed -= EnemyOnOnEnemyDestroyed;
    }


    void EnemyOnOnEnemyDestroyed(int pointWorth)
    {
        Debug.Log($"Player received 'EnemyDied'. It worth {pointWorth} points.");
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Shoot Trigger");
          
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");

            Destroy(shot, 3f);
        }

        float movementAxis = Input.GetAxis("Horizontal");
        if (movementAxis != 0)
        {
            Vector2 force = new Vector2(movementAxis, 0);
            if (rBody)
            {
                rBody.MovePosition(rBody.position + force * Time.fixedDeltaTime * movementPerSecond);
            }
        }
        else
            rBody.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
