using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorByCollidingPlayer : MonoBehaviour
{
    public float xDest = 19.9f;
    private bool didChange = false;
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

        if (collision.gameObject.tag == "Player1" && !didChange)
        {
            platformToChange.GetComponent<MeshRenderer>().material = player1Color;
            didChange = true; 
            checkColors();

        }
        else if (collision.gameObject.tag == "Player2" && !didChange)
        {

            platformToChange.GetComponent<MeshRenderer>().material = player2Color;
            didChange = true;
            checkColors();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        var cubeRenderer = GetComponent<Renderer>();

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            this.GetComponent<MeshRenderer>().material = original;
            didChange = false;
        }
    }

    private void checkColors()
    {
        Material platform1_color = platform1.GetComponent<MeshRenderer>().material;
        Material platform2_color = platform2.GetComponent<MeshRenderer>().material;
        Material platform3_color = platform3.GetComponent<MeshRenderer>().material;
        Material platform4_color = platform4.GetComponent<MeshRenderer>().material;
        Material platform5_color = platform5.GetComponent<MeshRenderer>().material;
        if (platform1_color == player2Color && platform2_color == player1Color && platform3_color == player2Color && platform4_color == player1Color && platform5_color == player2Color)
        {
            Debug.Log("yay1");
        }

        else if (platform1_color == player2Color && platform2_color == player1Color && platform3_color == original && platform4_color == player2Color && platform5_color == player1Color)
        {
            Debug.Log("yay2");
        }

    }

}

