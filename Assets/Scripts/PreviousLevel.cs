using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousLevel : MonoBehaviour
{
    private bool onDoor = false;
    private void Update()
    {
        if (onDoor == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlayerPrefs.SetInt("from_next", 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            onDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onDoor = false;
    }
}
