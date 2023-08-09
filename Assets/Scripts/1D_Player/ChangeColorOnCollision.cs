using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    public float xDest = 19.9f;
    private bool didChange = false;
    [SerializeField]
    private Material original;
    [SerializeField]
    private Material player1Color;
    [SerializeField]
    private Material player2Color;

    void Start()
    {
       // player1 = GameObject.FindGameObjectWithTag("Player1");
       // player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void OnTriggerEnter(Collider collision)
    {
        //var cubeRenderer = GetComponent<Renderer>();

        if (collision.gameObject.tag == "Player1" && !didChange)
        {
            Debug.Log("Player1 coll");
            //cubeRenderer.material.SetColor("_Color", player1.GetComponent<Renderer>().material.GetColor("_Color"));
            this.GetComponent<MeshRenderer>().material = player1Color;

            didChange = true;
        }
        else if (collision.gameObject.tag == "Player2" && !didChange)
        {
            Debug.Log("Player2 coll");
            // cubeRenderer.material.SetColor("_Color", player2.GetComponent<Renderer>().material.GetColor("_Color"));
            this.GetComponent<MeshRenderer>().material = player2Color;
            didChange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        var cubeRenderer = GetComponent<Renderer>();

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            this.GetComponent<MeshRenderer>().material = original;
            //cubeRenderer.material.SetColor("_Color", original);
            didChange = false;
        }
    }
}
