using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Pause_Menu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject hud;

    void awake()
    {
        pauseMenuUI.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume(); 
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        hud.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f; 
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
