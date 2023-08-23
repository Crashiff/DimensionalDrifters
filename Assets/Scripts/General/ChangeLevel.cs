using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    static int player1Counter = 0;
    static int player2Counter = 0;
    public string nextSceneName;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1" && player1Counter == 0)
        {
            player1Counter++;
        }
        if (collider.gameObject.tag == "Player2" && player2Counter == 0)
        {
            player2Counter++;
        }
        if (player1Counter == 1 && player2Counter == 1)
        {
            player1Counter = 0;
            player2Counter = 0;
            SceneManager.LoadScene(sceneName: nextSceneName);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player1" && player1Counter == 1)
        {
            player1Counter--;

            Debug.Log("P1 exited");
        }
        if (collider.gameObject.tag == "Player2" && player2Counter == 1)
        {
            player2Counter--;
            Debug.Log("P2 exited");

        }
    }
}
