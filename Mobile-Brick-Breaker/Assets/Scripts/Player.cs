using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction touchAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        touchAction = InputSystem.actions.FindAction("Touch");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touchAction.ReadValue<Vector2>());
        transform.position = new Vector2(touchPosition.x, transform.position.y);
    }
}
