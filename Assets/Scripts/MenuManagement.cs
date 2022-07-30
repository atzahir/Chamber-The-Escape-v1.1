using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    /*[SerializeField] GameObject objectMenu;*/
    private GameObject[] text;
    private GameObject pauseMenu;
    private GameObject optionsMenu;
    private GameObject quitMenu;
    private GameObject mainMenu;
    bool Paused = false;

    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("TextGuide") != null)
        {
            text = GameObject.FindGameObjectsWithTag("TextGuide");
        }

        optionsMenu = GameObject.Find("OptionsMenu");
        quitMenu = GameObject.Find("QuitConfirmation");

        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 6)
        {
            pauseMenu = GameObject.Find("PauseMenu");
            allMenuZero();
        }
        else if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainMenu = GameObject.Find("MainMenu");
            MainMenuBack();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 6)
        {
            if (Input.GetKeyDown("escape"))
            {
                if (Paused == true)
                {
                    Resume();
                }
                else 
                {
                    PauseMenu();
                }
            }
        }

    }

    void allMenuZero()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 6)
        {
            pauseMenu.transform.localScale = new Vector3(0, 0, 0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainMenu.transform.localScale = new Vector3(0, 0, 0);
        }
        
        optionsMenu.transform.localScale = new Vector3(0, 0, 0);
        quitMenu.transform.localScale = new Vector3(0, 0, 0);
    }

    void hideTextGuide()
    {
        if (text != null && Paused == true)
        {
            foreach (GameObject t in text)
                t.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void menuInitializer()
    {
        allMenuZero();
        PauseControl();
        hideTextGuide();
    }
   
    void PauseControl()
    {
        Time.timeScale = 0f;
        Paused = true;
    }
    public void Resume()
    {
        allMenuZero();
        Time.timeScale = 1f;
        Paused = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Resume();
    }
    public void PauseMenu()
    {
        /*objectMenu.SetActive(true);*/
        menuInitializer();
        pauseMenu.transform.localScale = new Vector3(1, 1, 0);
    }

    public void OptionsMenu()
    {
        /*objectMenu.SetActive(true);*/
        menuInitializer();
        optionsMenu.transform.localScale = new Vector3(3.39823f, 3.39823f, 0);
    }

    public void QuitMenu()
    {
        /*objectMenu.SetActive(true);*/
        menuInitializer();
        quitMenu.transform.localScale = new Vector3(3.39823f, 3.39823f, 0);
    }

    public void MainMenuBack()
    {
        menuInitializer();
        mainMenu.transform.localScale = new Vector3(3f, 3f, 0);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
