using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetLevel : MonoBehaviour
{
    public float mark = -10;

    void Update()
    {
        if(this.transform.position.y < mark)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
