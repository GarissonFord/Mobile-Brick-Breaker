using UnityEngine;
using System;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float powerUpDropRate;

    [SerializeField] private GameObject powerup;

    public event Action BrickDestroyed;

    private void Start()
    {
        UpdateBrickColor();
    }

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
        } else
        {
            UpdateBrickColor();
        }
    }

    private void UpdateBrickColor()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        switch (health)
        {
            case 3:
                sr.color = Color.gray3;
                break;
            case 2:
                sr.color = Color.gray2;
                break;
            case 1:
                sr.color = Color.red;
                break;
            default:
                Debug.Log("Invalid health value for this brick");
                break;
                
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
