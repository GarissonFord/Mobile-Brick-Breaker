using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction touchAction;

    [SerializeField] Powerup.PowerUpType currentPowerUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        touchAction = InputSystem.actions.FindAction("Touch");
        currentPowerUp = Powerup.PowerUpType.None;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touchAction.ReadValue<Vector2>());
        transform.position = new Vector2(touchPosition.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("I am the player and I have collided with *something*");
        GameObject objectCollidedWith = collider.gameObject;

        if (objectCollidedWith.CompareTag("Power-Up"))
        {
            Debug.Log("I the player have indeed collided with a power-up");
            Powerup powerUp = objectCollidedWith.GetComponent<Powerup>();
            Powerup.PowerUpType powerUpType = powerUp.powerUpType;
            PowerUp(powerUpType);
        }
    }

    private void PowerUp(Powerup.PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case Powerup.PowerUpType.Sticky:
                Debug.Log("I am the player and I just touched a sticky power up");
                currentPowerUp = powerUpType;
                break;
            default:
                Debug.Log("This type hasn't been implemented yet");
                break;
        }

        Debug.Log("This is the power up I have set now: " + currentPowerUp.ToString());
    }
}
