using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private float moveSpeed = 12f; // Adjust the speed of the arrow as needed
    private Rigidbody2D rb;
    private float lifeTime = 3f; // Time in seconds before the arrow is destroyed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
