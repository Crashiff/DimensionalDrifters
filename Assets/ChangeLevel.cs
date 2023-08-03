using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    static int counter = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            counter++;
            if (counter == 1)
            {
                Debug.Log("asdf");
                //SceneManager.LoadScene("Level 1 - Push box 1");
            }
        }
    }
}
