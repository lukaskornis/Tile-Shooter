using UnityEngine;

public class Movement : MonoBehaviour
{
    public LayerMask groundLayer;
    public float groundDistance;
    public float moveSpeed;
    public float jumpSpeed;
    public bool grounded;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast( transform.position, Vector2.down,groundDistance,groundLayer);
        grounded = hit.collider != null;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }

        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }
}