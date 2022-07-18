using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float fallDelay = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name.Equals("Player"))
        {
            StartCoroutine(FallingCoroutine());
        }
    }

    IEnumerator FallingCoroutine()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        rb.gravityScale *= 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}

