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

    private CharacterController ccPlayer1;
    private CharacterController ccPlayer2;

    private bool player1Turn = true;

    private void Start()
    {
        ccPlayer1 = player1.GetComponent<CharacterController>();
        ccPlayer2 = player2.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider collider)
    {


        if (collider.gameObject.tag == "Player1" && player1Turn)
        {
            player1Turn = false;
            switchColors();
            switchCameras();
            switchPositions();
        }
        else if (collider.gameObject.tag == "Player2" && !player1Turn)
        {
            player1Turn = true;
            switchColors();
            switchCameras();
            switchPositions();
        }
    }

    void switchPositions()
    {
        ccPlayer1.enabled = false;
        ccPlayer2.enabled = false;
        Vector3 playerPosition1 = player1.transform.position;
        Vector3 playerPosition2 = player2.transform.position;

        player1.transform.position = new Vector3(playerPosition2.x, playerPosition2.y, playerPosition2.z + 1);
        player2.transform.position = new Vector3(playerPosition1.x, playerPosition1.y, playerPosition2.z);

        ccPlayer1.enabled = true;
        ccPlayer2.enabled = true;
    }

    void switchColors()
    {
        Debug.Log("Colors swithed");
        GameObject player1Color2D = player1.transform.Find("Cube_2D_3D_Orange").gameObject.transform.Find("Color2D").gameObject;
        GameObject player1Element3D = player1.transform.Find("Cube_2D_3D_Orange").transform.Find("Element3D").gameObject;
        GameObject player2Color2D = player2.transform.Find("Cube_2D_3D_Blue").transform.Find("Color2D").gameObject;
        GameObject player2Element3D = player2.transform.Find("Cube_2D_3D_Blue").transform.Find("Element3D").gameObject;

        Material tempPlayer1Color2D = player1Color2D.GetComponent<Renderer>().sharedMaterial;
        Material tempPlayer1Element3D = player1Element3D.GetComponent<Renderer>().sharedMaterial;

        player1Color2D.GetComponent<Renderer>().material = player2Color2D.GetComponent<Renderer>().sharedMaterial;
        player1Element3D.GetComponent<Renderer>().material = player2Element3D.GetComponent<Renderer>().sharedMaterial;

        player2Color2D.GetComponent<Renderer>().material = tempPlayer1Color2D;
        player2Element3D.GetComponent<Renderer>().material = tempPlayer1Element3D;
    }

    void switchCameras()
    {
        Rect camera1Rect = player1Camera.rect;
        Rect camera2Rect = player2Camera.rect;

        player1Camera.rect = camera2Rect;
        player2Camera.rect = camera1Rect;
    }
}
