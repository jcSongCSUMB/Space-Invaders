using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float speedIncreaseAmount = 0.1f; // Amount to increase speed

    void Start()
    {
        // Subscribe to the OnEnemySpeedUp event
        Enemy.OnEnemySpeedUp += IncreaseSpeed;
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(currentPos.x, currentPos.y - 0.2f, currentPos.z);
            moveSpeed *= -1;
        }
    }

    // Method to increase the movement speed
    private void IncreaseSpeed()
    {
        moveSpeed = Mathf.Sign(moveSpeed) * (Mathf.Abs(moveSpeed) + speedIncreaseAmount);
        Debug.Log("Enemy group speed increased to: " + moveSpeed);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnEnemySpeedUp event to avoid memory leaks
        Enemy.OnEnemySpeedUp -= IncreaseSpeed;
    }
}