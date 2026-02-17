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
        powerUpType = (PowerUpType) Random.Range(1, 1);
        Debug.Log("I am a spawning power up, this is what I am: " + powerUpType.ToString());
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
