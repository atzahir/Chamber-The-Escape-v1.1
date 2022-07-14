using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb;
    private Vector3 start;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall() // Or DropPlatform ()
    {
        rb.isKinematic = false;
        GetComponent<Collider2D>().enabled = false;
    }

    void Respawn()
    {
        transform.position = start;
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = true;
        rb.velocity = Vector3.zero;
    }
}

