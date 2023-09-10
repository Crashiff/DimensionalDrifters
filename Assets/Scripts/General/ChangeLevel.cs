using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    static bool player1Counter = false;
    static bool player2Counter = false;
    public float delayTime = 2f;
    public string nextSceneName;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (!isTriggered) 
        {
            Debug.Log("Hello world");
            Debug.Log("TriggerEnter " + collider);

            if (collider.gameObject.CompareTag("Player1") && !player1Counter)
            {
                isTriggered = true;
                player1Counter = true;
            }
            if (collider.gameObject.CompareTag("Player2") && !player2Counter)
            {
                isTriggered = true;
                player2Counter = true;
            }
                        Debug.Log("Player 1 " + player1Counter);
            Debug.Log("Player 2 " + player2Counter);
            if (player1Counter && player2Counter)
            {
                Debug.Log("Loading level ");
                Invoke("TryLoadLevel", delayTime);
            }
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(sceneName: nextSceneName);
    }

    void TryLoadLevel()
    {
        if (player1Counter == true && player2Counter == true)
        {
            player1Counter = false;
            player2Counter = false;
            LoadLevel();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("TriggerExit " + collider);
        if (collider.gameObject.CompareTag("Player1") && player1Counter)
        {
            player1Counter = false;
        }
        if (collider.gameObject.CompareTag("Player2") && player2Counter)
        {
            player2Counter = false;
        }
        isTriggered = false;
    }
}
