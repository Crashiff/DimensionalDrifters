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

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player1" && !didChange)
        {
            this.GetComponent<MeshRenderer>().material = player1Color;

            didChange = true;
        }
        else if (collision.gameObject.tag == "Player2" && !didChange)
        {
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
            didChange = false;
        }
    }
}
