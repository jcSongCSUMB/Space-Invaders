using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;
    public delegate void EnemyDestroyed(int pointWorth);
    public static event EnemyDestroyed OnEnemyDestroyed;
    
    public delegate void EnemySpeedUp();
    public static event EnemySpeedUp OnEnemySpeedUp;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        switch (gameObject.tag)
        {
            case "Enemy Type 1":
                points = 30;
                break;
            case "Enemy Type 2":
                points = 20;
                break;
            case "Enemy Type 3":
                points = 10;
                break;
            case "Enemy Type 4":
                points = 40;
                break;
            default:
                points = 0;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetTrigger("Enemy Destroy");

        Debug.Log("Ouch!");
        Destroy(collision.gameObject);
        
        OnEnemyDestroyed?.Invoke(points);
        gameManager.AddPoints(points);
        gameManager.EnemyDestroyed(); // Notify GameManager that an enemy is destroyed
        
        OnEnemySpeedUp?.Invoke();
        
        StartCoroutine(DestroyAfterDelay(0.25f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Enemy died.");
        Destroy(gameObject);
    }
}