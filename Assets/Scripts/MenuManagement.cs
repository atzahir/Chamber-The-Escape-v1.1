using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    [SerializeField] GameObject obcejtMenu;

    public void Pause()
    {
        obcejtMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        obcejtMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
    public void Options()
    {
        obcejtMenu.SetActive(true);
    }

    public void Back()
    {
        obcejtMenu.SetActive(false);
    }

    public void QuitGame()
    {

    }

}
