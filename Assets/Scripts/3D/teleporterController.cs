using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterController : MonoBehaviour
{
    [SerializeField]
    private GameObject targetTeleporter;
    public bool isBusy = false;
    private GameObject player1;
    private GameObject player2;
    public bool player1Teleporting = false;
    public bool player2Teleporting = false;
    [SerializeField]
    private int delay = 1;



    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!isBusy && !targetTeleporter.GetComponent<teleporterController>().isBusy)
        {
            if (collision.gameObject.tag == "Player1")
            {
                isBusy = true;
                StartCoroutine(Activate(player1));
            }
            else if (collision.gameObject.tag == "Player2")
            {
                isBusy = true;
                StartCoroutine(Activate(player2));
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            isBusy = false;
        }
    }

    private IEnumerator Activate(GameObject player)
    {
        Debug.Log("Teleporting...");
        yield return new WaitForSeconds(delay);

        player.transform.position = new Vector3(
            targetTeleporter.transform.position.x,
            targetTeleporter.transform.position.y + 1,
            targetTeleporter.transform.position.z);
            targetTeleporter.GetComponent<teleporterController>().isBusy = true;
        Debug.Log("Teleportation complete!");
    }
}
