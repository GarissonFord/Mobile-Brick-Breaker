using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float initialForce;
    [SerializeField] private Vector2 randomStartDirection;

    public event Action BallEnteredDeadZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ApplyInitialForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyInitialForce()
    {
        randomStartDirection = new Vector2(UnityEngine.Random.Range(0.25f, 0.75f), -1.0f);
        rb2D.AddForce(randomStartDirection * initialForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Trigger entered");
        GameObject triggerEntered = collision.gameObject;

        if (triggerEntered.CompareTag("Dead Zone"))
        {
            // Debug.Log("Dead Zone tag confirmed");
            BallEnteredDeadZone?.Invoke();
            Destroy(gameObject);
        }
    }
}
