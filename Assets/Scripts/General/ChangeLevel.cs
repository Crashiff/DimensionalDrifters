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
            if (player1Counter && player2Counter)
            {
                player1Counter = false;
                player2Counter = false;
                Invoke("LoadLevel", delayTime);
            }
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(sceneName: nextSceneName);
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("TriggerEnter " + collider);
        if (collider.gameObject.CompareTag("Player1") && player1Counter)
        {
            isTriggered = false;
            player1Counter = false;
        }
        if (collider.gameObject.CompareTag("Player2") && player2Counter)
        {
            isTriggered = false;
            player2Counter = false;
        }
    }
}
