using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCameraBlocked : MonoBehaviour
{
    [SerializeField]
    private Transform player;  // Reference to the player's Transform.
    [SerializeField]
    private float moveSpeed = 5f;  // Speed at which the camera moves.
    [SerializeField]
    private float maxDistance = 1f;  // Maximum distance between the camera and player.

    [SerializeField]
    private float maxDistanceBehind = 1f; 

    [SerializeField]
    private Vector3 InitiatedPosition;

    private void Start()
    {
        InitiatedPosition = transform.position;
    }
    private void Update()
    {
        
        moveTowardsPlayer();
    }

    private void moveTowardsPlayer()
    {

        if (BlockedFromBehind())
        {
            return;
        }
        //Calculate the direction from the camera to the player.
        Vector3 directionToPlayer = player.position - transform.position;
        //Debug.Log(player.position - directionToPlayer.normalized * maxDistance);

        //Create a ray from the camera towards the player.
        float offsetDistance = 2f;
        Vector3 rayStartOffset = -directionToPlayer.normalized * offsetDistance;
        Ray ray = new Ray(transform.position + rayStartOffset, directionToPlayer);
        //Debug.DrawRay(transform.position, directionToPlayer, Color.red); //Used this for Debug mode, showing a red line for the raycast

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            //Debug.Log(hit.collider.gameObject);
            //Check by tag (all child obbjects were given the same taG)
            if (!hit.collider.gameObject.CompareTag("Player1") || BlockedFromBehind())
            {
                //Debug.Log("if (Physics.Raycast(ray, out hit, maxDistance)) inside if");
                //Calculate the new camera position closer to the player.
                Vector3 newCameraPosition = player.position - directionToPlayer.normalized * maxDistance;
                if (Vector3.Distance(transform.position, player.position) > Vector3.Distance(newCameraPosition, player.position))
                {
                    transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
                }
            }
            else 
            {
                //Debug.Log("if (Physics.Raycast(ray, out hit, maxDistance)) inside else");
                Vector3 newCameraPosition = player.position - directionToPlayer.normalized * 20f;

                //Move the camera towards the new position smoothly.
                transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
                //Debug.Log("else");
                Vector3 newCameraPosition = player.position - directionToPlayer.normalized * 20f;

                //Lerp makes the transition smooth and not immidiately.
                transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
                //Vector3 newCameraPosition = player.position - directionToPlayer.normalized * maxDistance;
                //transform.position = Vector3.Lerp(transform.position, newCameraPosition, moveSpeed * Time.deltaTime);
        }
    }

    private bool BlockedFromBehind()
    {
        //Calculate the direction from the camera to the player.
        Vector3 directionToPlayer = (player.position - transform.position);
        //Debug.Log(player.position - directionToPlayer.normalized * maxDistance);

        //Create a ray from the camera towards the player.
        float offsetDistance = 2f;
        Vector3 rayStartOffset = -directionToPlayer.normalized * offsetDistance;

        Ray ray = new Ray(transform.position + rayStartOffset, directionToPlayer);
        Debug.DrawRay(transform.position, directionToPlayer.normalized * maxDistanceBehind, Color.blue); //Used this for Debug mode, showing a red line for the raycast

        RaycastHit hit;

        Ray ray2 = new Ray(transform.position + rayStartOffset, -directionToPlayer);
        Debug.DrawRay(transform.position, -directionToPlayer.normalized * maxDistanceBehind, Color.green); //Used this for Debug mode, showing a red line for the raycast

        RaycastHit hit2;

        if (Physics.Raycast(ray, out hit, maxDistanceBehind) || Physics.Raycast(ray2, out hit2, maxDistanceBehind))
        {
            //Debug.Log(hit.collider.gameObject);
            Debug.Log("Blocked From Behind");
            return true;
        }
        else{
            //Debug.Log(hit.collider.gameObject);
            return false;
        }
    }
}
