using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    public float runSpeed;
    public float jump;
    private bool landed;
    public Vector3 respawnPoint;


    public Transform keyfollowPoint;
    public Key followingKey;

    public RespawnController gameRespawn;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gameRespawn = FindObjectOfType<RespawnController>();
        /*if (PlayerPrefs.GetInt("from_next") == 1)
        {
            transform.position = GameObject.Find("SpawnFromNext").transform.position;
            PlayerPrefs.DeleteAll();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hInput * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && landed)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        landed = false;
    }

    private void Run()
    {
        float hInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hInput * runSpeed, body.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            landed = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy")
        {
            gameRespawn.Respawn();
        }
        else if (target.gameObject.tag == "Checkpoint")
        {
            respawnPoint = target.transform.position;
        }
    }
}
