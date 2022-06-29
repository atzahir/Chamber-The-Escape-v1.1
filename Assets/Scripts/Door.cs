using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private PlayerMovement thePlayer;

    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;

    public bool doorOpen, waitingToOpen;

    public string nextlevel;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingToOpen)
        {
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) <0.1f )
            {
                waitingToOpen = false;
                doorOpen = true;

                theSR.sprite = doorOpenSprite;

                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }
        }

        if(doorOpen && Vector3.Distance(thePlayer.transform.position, transform.position) < 1f && Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(nextlevel);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(thePlayer.followingKey != null)
            {
                thePlayer.followingKey.followTarget = transform;
                waitingToOpen = true;
            }
        }
    }
}
