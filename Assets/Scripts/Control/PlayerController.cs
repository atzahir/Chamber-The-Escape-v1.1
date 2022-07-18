using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
    public FallingObject objectRespawn;
    public StaminaController stamina;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gameRespawn = FindObjectOfType<RespawnController>();

        if (PlayerPrefs.GetInt("from_next") == 1)
        {
            transform.position = GameObject.Find("SpawnFromNext").transform.position;
            PlayerPrefs.DeleteKey("from_next");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hInput * speed, body.velocity.y);

        if (Input.GetButtonDown("Jump") && landed)
        {
            body.velocity = Vector2.up * jump;
            landed = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
    }


    private void Run()
    {
        
        stamina = GetComponent<StaminaController>();
        if(stamina.Stamina > 0)
        {
            float hInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(hInput * runSpeed, body.velocity.y);
        }
        else if(stamina.Stamina == 0)
        {

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            landed = true;
        }

        if (collision.gameObject.tag == "Deadly" || collision.gameObject.tag == "Enemy")
        {
            gameRespawn.Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.name.Equals("KeyOne"))
        {
            PlayerPrefs.SetInt("KeyFall", 1);
            GameObject.Find("KeyOne").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("KeyOne").GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (target.gameObject.name.Equals("KeyTwo"))
        {
            PlayerPrefs.SetInt("KeyFall", 2);
            GameObject.Find("KeyTwo").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("KeyTwo").GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (target.gameObject.name.Equals("KeyThree"))
        {
            PlayerPrefs.SetInt("KeyFall", 3);
            GameObject.Find("KeyThree").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("KeyThree").GetComponent<CircleCollider2D>().enabled = false;
        }

        if (target.gameObject.tag == "Checkpoint")
        {
            respawnPoint = target.transform.position;
        }
    }
}