using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private bool onDoor = false;
    private void Update()
    {
        if (onDoor == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            onDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onDoor = false;
    }
}
