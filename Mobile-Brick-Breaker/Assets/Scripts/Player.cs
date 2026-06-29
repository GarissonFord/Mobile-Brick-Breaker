using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction pressAction, positionAction;

    [SerializeField] private Vector2 pointerPosition;

    [SerializeField] Powerup.PowerUpType currentPowerUp;

    public bool isSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressAction = InputSystem.actions.FindAction("Press");
        positionAction = InputSystem.actions.FindAction("Position");

        currentPowerUp = Powerup.PowerUpType.None;
    }

    // Update is called once per frame
    void Update()
    {

        isSelected = checkIfPlayerIsSelected();

        if (isSelected)
        {
            pointerPosition = positionAction.ReadValue<Vector2>();

            float z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, 0.0f) + new Vector3(0, 0, z));

            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
    }

    private bool checkIfPlayerIsSelected()
    {
        pointerPosition = positionAction.ReadValue<Vector2>();

        if (pressAction.IsPressed())
        {
            Ray ray = Camera.main.ScreenPointToRay(pointerPosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pointerPosition), Vector2.zero);

            if (hit)
            {
                // Debug.Log("RaycastHit hit: " + hit.ToString());

                if (hit.transform == transform)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // Debug.Log("RaycastHit hit nothing");
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log("I am the player and I have collided with *something*");
        GameObject objectCollidedWith = collider.gameObject;

        if (objectCollidedWith.CompareTag("Power-Up"))
        {
            // Debug.Log("I the player have indeed collided with a power-up");
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
                // Debug.Log("I am the player and I just touched a sticky power up");
                currentPowerUp = powerUpType;
                break;
            default:
                // Debug.Log("This type hasn't been implemented yet");
                break;
        }

        // Debug.Log("This is the power up I have set now: " + currentPowerUp.ToString());
    }
}
