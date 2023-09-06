using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() 
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Resume();
        GameObject[] audioSources = GameObject.FindGameObjectsWithTag("music");
        foreach(GameObject obj in audioSources)
        {
           // if (obj.name != "AudioSource1")
          //  {
                Destroy(obj);
          //  }
        }
        ActivateMusic.ClearPlaying();
        SceneManager.LoadScene(sceneName: "mainMenu");
    }
}