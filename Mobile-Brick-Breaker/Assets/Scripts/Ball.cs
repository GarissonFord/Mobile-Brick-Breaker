using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private float initialForce;
    [SerializeField] private Vector2 randomStartDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ApplyInitialForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyInitialForce()
    {
        randomStartDirection = new Vector2(Random.Range(0.25f, 0.75f), -1.0f);
        rigidbody2D.AddForce(randomStartDirection * initialForce);
    }
}
