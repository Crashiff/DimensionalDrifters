using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change2DPlayerOnCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private Camera player1Camera;
    [SerializeField]
    private Camera player2Camera;
    [SerializeField]
    private Material p1OuterColor;
    [SerializeField]
    private Material p2OuterColor;
    [SerializeField]
    private Material p1InnerColor;
    [SerializeField]
    private Material p2InnerColor;



    private CharacterController ccPlayer1;
    private CharacterController ccPlayer2;
    private string player1Tag;
    private string player2Tag;

    private bool player1Turn = true;

    private void Start()
    {
        ccPlayer1 = player1.GetComponent<CharacterController>();
        ccPlayer2 = player2.GetComponent<CharacterController>();
        player1Tag = player1.tag;
        player2Tag = player2.tag;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player1" && player1Turn)
        {
            Debug.Log("p1");
            handleColission(1);
        }
        else if (collider.gameObject.tag == "Player2" && !player1Turn)
        {
            Debug.Log("p2");
            handleColission(2);
        }
    }

    void handleColission(int option)
    {
        player1Turn = option == 1 ? false : true;
        switchPositions(option);
        switchColors(option);
        switchMovement(option);
        //switchCameras();
        switchTags(option);
    }

    void switchMovement(int option)
    {
        switch(option)
        {
            case 1:
                {
                    player1.GetComponent<P1Movement_3D>().enabled = false;
                    player1.GetComponent<P2Movement_3D>().enabled = true;
                    player2.GetComponent<P2Movement>().enabled = false;
                    player2.GetComponent<P1Movement>().enabled = true;
                    break;
                }
            case 2:
                {
                    player1.GetComponent<P2Movement_3D>().enabled = false;
                    player1.GetComponent<P1Movement_3D>().enabled = true;
                    player2.GetComponent<P1Movement>().enabled = false;
                    player2.GetComponent<P2Movement>().enabled = true;
                    break;
                }
        }

    }

    void switchTags(int option)
    {
        switch(option)
        { 
            case 1: 
            {
                player1.tag = player2Tag;
                player2.tag = player1Tag;
                break;
            }
            case 2:
            {
                 player1.tag = player1Tag;
                 player2.tag = player2Tag;
                 break;
            }
        }
    }

    void switchPositions(int option)
    {
        ccPlayer1.enabled = false;
        ccPlayer2.enabled = false;
        Vector3 playerPosition1 = player1.transform.position;
        Vector3 playerPosition2 = player2.transform.position;
        int zValueOffset = option == 1 ? 2 : -2;
        Debug.Log("hi " + playerPosition2.z);
        player1.transform.position = new Vector3(playerPosition2.x, playerPosition2.y, playerPosition2.z + zValueOffset);
        Debug.Log("hi2 " + playerPosition2.z);
        player2.transform.position = new Vector3(playerPosition1.x, playerPosition1.y + 0.3f, playerPosition2.z);
        float differenceZ = player2.transform.position.z - playerPosition2.z;

        Debug.Log("hi3 " + playerPosition2.z);

        ccPlayer1.enabled = true;
       ccPlayer2.enabled = true;
    }





    void switchColors(int option)
    {
        Debug.Log("Colors swithed");
        GameObject player1Color2D = player1.transform.Find("Cube_2D_3D_Orange").gameObject.transform.Find("Color2D").gameObject;
        GameObject player1Element3D = player1.transform.Find("Cube_2D_3D_Orange").transform.Find("Element3D").gameObject;
        GameObject player2Color2D = player2.transform.Find("Cube_2D_3D_Blue").transform.Find("Color2D").gameObject;
        GameObject player2Element3D = player2.transform.Find("Cube_2D_3D_Blue").transform.Find("Element3D").gameObject;

        switch(option)
        {
            case 1:
                {
                    player1Color2D.GetComponent<MeshRenderer>().material = p2InnerColor;
                    player2Color2D.GetComponent<MeshRenderer>().material = p1InnerColor;
                    player1Element3D.GetComponent<MeshRenderer>().material = p2OuterColor;
                    player2Element3D.GetComponent<MeshRenderer>().material = p1OuterColor;
                    break;
                }
            case 2:
                {
                    player1Color2D.GetComponent<MeshRenderer>().material = p1InnerColor;
                    player2Color2D.GetComponent<MeshRenderer>().material = p2InnerColor;
                    player1Element3D.GetComponent<MeshRenderer>().material = p1OuterColor;
                    player2Element3D.GetComponent<MeshRenderer>().material = p2OuterColor;
                    break;
                }
        }

    }

    void switchCameras()
    {
        Rect camera1Rect = player1Camera.rect;
        Rect camera2Rect = player2Camera.rect;

        player1Camera.rect = camera2Rect;
        player2Camera.rect = camera1Rect;
    }
}
