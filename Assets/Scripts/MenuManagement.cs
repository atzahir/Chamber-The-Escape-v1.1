using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    [SerializeField] GameObject objectMenu;
    /*public GameObject Canvas;
    *//*public GameObject Camera;*/
    bool Paused = false;

    void Start()
    {
        /*Canvas.gameObject.SetActive(false);*/
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown("escape"))
            {
                if (Paused == true)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        objectMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        objectMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
        
    public void OpenAnotherMenu()
    {
        objectMenu.SetActive(true);
    }

    public void Back()
    {
        objectMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
