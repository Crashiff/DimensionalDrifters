using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorByCollidingPlayer : MonoBehaviour
{
    public float xDest = 19.9f;
    [SerializeField]
    private Material original;
    [SerializeField]
    private Material player1Color;
    [SerializeField]
    private Material player2Color;
    [SerializeField]
    private GameObject platformToChange;
    private GameObject platform1;
    private GameObject platform2;
    private GameObject platform3;
    private GameObject platform4;
    private GameObject platform5;
    public CheckColors checkColorsScript;

    private void Start()
    {
        platform1 = GameObject.FindGameObjectsWithTag("platform1")[0];
        platform2 = GameObject.FindGameObjectsWithTag("platform2")[0];
        platform3 = GameObject.FindGameObjectsWithTag("platform3")[0];
        platform4 = GameObject.FindGameObjectsWithTag("platform4")[0];
        platform5 = GameObject.FindGameObjectsWithTag("platform5")[0];

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player1")
        {
            platformToChange.GetComponent<MeshRenderer>().material = player1Color;
            gameObject.GetComponent<MeshRenderer>().material = player1Color;
            updateCheckColorScript(1);
            Invoke("resetToOriginalColor", 35f);
        }
        else if (collision.gameObject.tag == "Player2")
        {

            platformToChange.GetComponent<MeshRenderer>().material = player2Color;
            gameObject.GetComponent<MeshRenderer>().material = player2Color;
            updateCheckColorScript(2);
            Invoke("resetToOriginalColor", 45f);
        }
    }
    private void updateCheckColorScript(int color)
    {
        string tag = platformToChange.tag;
        int platform = tag[tag.Length - 1] - '0';
        Debug.Log("plat is " + platform);
        switch(platform)
        {
            case 1:
                {
                    checkColorsScript.platform1_color = color;
                    break;
                }
            case 2:
                {
                    checkColorsScript.platform2_color = color;
                        break;  
                }
            case 3:
                {
                    checkColorsScript.platform3_color = color;
                    break;
                }
            case 4:
                {
                    checkColorsScript.platform4_color = color;
                    break;
                }
            case 5:
                {
                    checkColorsScript.platform5_color = color;
                    break;
                }
        }
    }

    public void resetToOriginalColor()
    {
        platformToChange.GetComponent<MeshRenderer>().material = original;
        gameObject.GetComponent<MeshRenderer>().material = original;
        updateCheckColorScript(0);
    }
}

