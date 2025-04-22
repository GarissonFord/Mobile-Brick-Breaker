using UnityEngine;
using System;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float powerUpDropRate;

    [SerializeField] private GameObject powerup;

    public event Action BrickDestroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objectCollidedWith = collision.gameObject;

        if (objectCollidedWith.CompareTag("Ball"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            DestroyThisBrick();
        }
    }

    private void DestroyThisBrick()
    {
        float randomNumber = UnityEngine.Random.Range(0.0f, 1.0f);

        if (randomNumber >= powerUpDropRate)
        {
            // Debug.Log("Power up drop " + randomNumber);
            InstantiatePowerUp();
        }

        Destroy(gameObject);
        BrickDestroyed?.Invoke();
    }

    private void InstantiatePowerUp()
    {
        Instantiate(powerup, transform.position, transform.rotation);
    }
}
