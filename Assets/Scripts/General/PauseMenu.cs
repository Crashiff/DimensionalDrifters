using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

    void Start()
    {
        GameObject borderObject = transform.Find("Border").gameObject;

        CheckForMultipleCameras(borderObject);
    }

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
    void CheckForMultipleCameras(GameObject borderObject)
    {
        Camera[] cameras = FindObjectsOfType<Camera>();

        // If there is more than one camera in the scene
        if (cameras.Length > 1)
        {
            // Activate the 'Border' object
            borderObject.SetActive(true);
        }
        else
        {
            // Deactivate the 'Border' object
            borderObject.SetActive(false);
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