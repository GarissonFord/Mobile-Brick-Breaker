using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerUpType
    {
        None,
        Sticky,
        Multiplier,
        Lasers
    }

    public PowerUpType powerUpType;

    private void Awake()
    { 
        powerUpType = (PowerUpType) Random.Range(0, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectCollidedWith = collision.gameObject;
        if (objectCollidedWith.CompareTag("Dead Zone"))
        {
            Debug.Log("Power up going bye bye now");
            Destroy(gameObject);
        }
        else if (objectCollidedWith.CompareTag("Player"))
        {
            Debug.Log("Powerup collided with player.");
            Destroy(gameObject);
        }
    }
}
