using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public GameObject impactEffect;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject );
    }
}