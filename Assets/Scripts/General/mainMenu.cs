using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void startGame()
    {
        SceneManager.LoadScene(sceneName: "firstLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
