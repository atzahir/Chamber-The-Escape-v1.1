using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpike : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float fallDelay;
    private float respawnDelay = 3;

    private Vector3 start;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start = transform.position;
        rb.gravityScale *= 20;
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
        float vibrate = fallDelay*0.8f+1;
        for (int i = 0; i <= vibrate; i++)
        {
            transform.localPosition += new Vector3(.2f, 0, 0);
            yield return new WaitForSeconds(0.1f);
            transform.localPosition -= new Vector3(.2f, 0, 0);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(fallDelay-(vibrate-1));   
        rb.isKinematic = false;
        /*rb.gravityScale *= 5;*/
        StartCoroutine(RespawnCoroutine());
    }
    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        rb.isKinematic = true;
        /*rb.gravityScale /= 5;*/
        transform.position = start;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.tag.Equals("Ground"))
        {
            StartCoroutine(RespawnCoroutine());
        }*/

        if (collision.gameObject.tag.Equals("Player"))
        {
            StartCoroutine(RespawnCoroutine());
        }
    }
}

