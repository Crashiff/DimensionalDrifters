using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollider : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public float xDest = 19.9f;
    private CharacterController ccPlayer1;
    private CharacterController ccPlayer2;


    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        ccPlayer1 = player1.GetComponent<CharacterController>();
        ccPlayer2 = player2.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider collision)
    {


        if (collision.gameObject.tag == "Player1" && (player2.transform.position.x > xDest + 1 || player2.transform.position.x < xDest - 1))
        {
            Debug.Log("Player1 coll");
            ccPlayer1.enabled = false;
            player1.transform.position = new Vector3(xDest, 0.54f, 8.02f); // (where you want to teleport)
            ccPlayer1.enabled = true;

        }
        else if (collision.gameObject.tag == "Player2" && (player1.transform.position.x > xDest + 1 || player1.transform.position.x < xDest - 1))
        {
            Debug.Log("Player2 coll");
            ccPlayer2.enabled = false;
            player2.transform.position = new Vector3(xDest, 0.54f, 8.02f); // (where you want to teleport)
            ccPlayer2.enabled = true;
            
        }
    }
}
