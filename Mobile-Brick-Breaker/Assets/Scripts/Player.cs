using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction touchAction;

    Powerup.PowerUpType currentPowerUp;

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

    private void OnCollisionEnter2D(Collider2D collision)
    {
        GameObject objectCollidedWith = collision.gameObject;

        if (objectCollidedWith.CompareTag("Power-Up"))
        {
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
                currentPowerUp = powerUpType;
                break;
            default:
                Debug.Log("This type hasn't been implemented yet");
                break;
        }
    }
}
