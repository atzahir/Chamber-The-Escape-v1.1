using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private PlayerController gamePlayer;
    private BetterJump betterJumpScript;
    private Rigidbody2D playerRigidbody;
    List<int> lsKeyOrder = new List<int>();

    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("start", 1);
        PlayerPrefs.SetInt("KeyFall", 0);
    }
    private void Update()
    {
        if(lsKeyOrder.Count==3)
        {
            if ((lsKeyOrder[0] == 3) && (lsKeyOrder[1] == 1) && (lsKeyOrder[2] == 2))
            {
                GameObject.Find("LoopTeleporter").SetActive(false);
                playerRigidbody.mass = 1;
                playerRigidbody.gravityScale = 2.5f;
                betterJumpScript.enabled = true;
            }
            else
            {
                lsKeyOrder.Clear();
                Debug.Log("clear berhasil");
                GameObject.Find("KeyOne").transform.localScale = new Vector3(10, 10, 0);
                GameObject.Find("KeyTwo").transform.localScale = new Vector3(10, 10, 0);
                GameObject.Find("KeyThree").transform.localScale = new Vector3(10, 10, 0);
                GameObject.Find("KeyOne").GetComponent<CircleCollider2D>().enabled = true;
                GameObject.Find("KeyTwo").GetComponent<CircleCollider2D>().enabled = true;
                GameObject.Find("KeyThree").GetComponent<CircleCollider2D>().enabled = true;
                gamePlayer.transform.position = new Vector3(gamePlayer.transform.position.x, 130);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log(lsKeyOrder.Count);
            betterJumpScript = FindObjectOfType<BetterJump>();
            betterJumpScript.enabled = false;

            playerRigidbody.mass = 0.0001f;
            playerRigidbody.gravityScale = 0;
            
            if (PlayerPrefs.GetInt("start") == 1)
            {
                gamePlayer.transform.position = GameObject.Find("LoopingPoint").transform.position;
                PlayerPrefs.DeleteKey("start");
            }
            else
            {
                gamePlayer.transform.position = new Vector3(gamePlayer.transform.position.x, 130);
            }

            if (PlayerPrefs.GetInt("KeyFall") != 0)
            {
                lsKeyOrder.Add(PlayerPrefs.GetInt("KeyFall"));
                PlayerPrefs.SetInt("KeyFall",0);
            }
        }
    }
}
