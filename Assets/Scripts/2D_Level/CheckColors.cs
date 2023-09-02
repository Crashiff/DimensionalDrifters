using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColors : MonoBehaviour
{
    [SerializeField]
    private GameObject platform1;
    [SerializeField]
    private GameObject platform2;
    [SerializeField]
    private GameObject platform3;
    [SerializeField]
    private GameObject platform4;
    [SerializeField]
    private GameObject platform5;
    [SerializeField]
    private Material player1Color;
    [SerializeField]
    private Material player2Color;
    [SerializeField]
    private Material original;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
