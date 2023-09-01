using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class resetLevel : MonoBehaviour
{
    public float mark = -10;
    public GameObject gameOverImage;
    public TextMeshProUGUI countDownText;
    private int countDown;
    bool isCoroutineRunning = false;


    private void Start()
    {
        countDown = 5;
    }

    void Update()
    {
        if (this.transform.position.y < mark)
        {
            ActivateGameOverScreen();
            if (!isCoroutineRunning)
            {
                StartCoroutine(SpawnTimer());

            }
        }

    }

    void ActivateGameOverScreen()
    {
        gameOverImage.SetActive(true);
    }

    private IEnumerator SpawnTimer()
    {
        isCoroutineRunning = true;

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            countDown--;
            if (countDown == 0)
            {
                DeactivateGameOverScreen();
            }
            countDownText.text = "Restarting in " + countDown + " seconds";
        }
    }


        void DeactivateGameOverScreen()
        {
            gameOverImage.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
}