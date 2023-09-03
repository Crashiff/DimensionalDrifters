using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameraBlocked : MonoBehaviour
{
    [SerializeField]
    private  Transform player;  // Reference to the player's Transform.
    [SerializeField]
    private  float moveSpeed = 5f;  // Speed at which the camera moves.
    [SerializeField]
    private  float maxDistance = 1f;  // Maximum distance between the camera and player.

    [SerializeField]
    private Vector3 InitiatedPosition;

    private void Start()
    {
        InitiatedPosition = transform.position;
    }
    private void Update()
    {
        //Calculate the direction from the camera to the player.
        Vector3 directionToPlayer = player.position - transform.position;
        //Debug.Log(player.position - directionToPlayer.normalized * maxDistance);

        //Create a ray from the camera towards the player.
        Ray ray = new Ray(transform.position, directionToPlayer);
        Debug.DrawRay(transform.position, directionToPlayer, Color.red); //Used this for Debug mode, showing a red line for the raycast

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.collider.gameObject);
            //Check by tag (all child obbjects were given the same taG)
            if (!hit.collider.gameObject.CompareTag("Player1"))
            {
                Debug.Log("if (Physics.Raycast(ray, out hit, maxDistance)) inside if");
                //Calculate the new camera position closer to the player.
                Vector3 newCameraPosition = player.position - directionToPlayer.normalized * maxDistance;

                //Move the camera towards the new position smoothly.
                transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
            }
            else 
            {
                Debug.Log("if (Physics.Raycast(ray, out hit, maxDistance)) inside else");
                Vector3 newCameraPosition = player.position - directionToPlayer.normalized * 20f;

                //Move the camera towards the new position smoothly.
                transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.Log("else");
            Vector3 newCameraPosition = player.position - directionToPlayer.normalized * 20f;

            //Lerp makes the transition smooth and not immidiately.
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
            //Vector3 newCameraPosition = player.position - directionToPlayer.normalized * maxDistance;
            //transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
        }
    }
}
