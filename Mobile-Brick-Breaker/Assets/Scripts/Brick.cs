using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(gameObject);
        }
    }
}
