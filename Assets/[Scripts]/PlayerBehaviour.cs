using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [Header("PlayerMovement")]
    [Range(0.0f, 100.0f)]
    public float horizontalForce;
    [Range(0.0f, 1.0f)]
    public float decay;

    public Bounds bounds;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rb.AddForce(new Vector2(x * horizontalForce, 0.0f));

        rb.velocity *= (1.0f - decay);
    }

    private void CheckBounds()
    {
        // Left Boundary
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }


        // Right Boundary
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }
}
