using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColors : MonoBehaviour
{
 
    public int platform1_color;
    public int platform2_color;
    public int platform3_color;
    public int platform4_color;
    public int platform5_color;
    public FallingScript endLevelTarget1;
    public FallingScript endLevelTarget2;
    private bool row1Done = false;
    private bool row2Done = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platform1_color == 2 && platform2_color == 1 && platform3_color == 2 && platform4_color == 1 && platform5_color == 2 && !row1Done)
        {
            row1Done = true;
            Debug.Log("yay1");
            GameObject[] colorBlocks = GameObject.FindGameObjectsWithTag("colorRow1");
            foreach (GameObject obj in colorBlocks)
            {
                obj.SetActive(false);
            }
                endLevelTarget1.StartFalling();
        }

        else if (platform1_color == 2 && platform2_color == 1 && platform3_color == 0 && platform4_color == 2 && platform5_color == 1 && !row2Done)
        {
            row2Done = true;
            Debug.Log("yay2");
            GameObject[] colorBlocks = GameObject.FindGameObjectsWithTag("colorRow2");
            foreach (GameObject obj in colorBlocks)
            {
                obj.SetActive(false);
            }
                endLevelTarget2.StartFalling();
        }

    }
}