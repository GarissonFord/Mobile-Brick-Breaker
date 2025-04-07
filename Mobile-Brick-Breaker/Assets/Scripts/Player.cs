using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // It's actually the look action, but it's a default so I'll change that up later
    InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = new Vector2(moveAction.ReadValue<Vector2>().x, 0.0f);
        transform.Translate(moveVector * Time.deltaTime);
    }
}
