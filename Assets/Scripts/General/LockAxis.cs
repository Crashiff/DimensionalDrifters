using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAxis : MonoBehaviour
{
    [SerializeField]
    private bool X = false;
    [SerializeField]
    private bool Y = false;
    [SerializeField]
    private bool Z = false;

    private CharacterController playerController;
    private Vector3 startingPoint;


    void Start()
    {
        playerController = GetComponent<CharacterController>();
        startingPoint.x = GetComponent<Transform>().position.x;
        startingPoint.y = GetComponent<Transform>().position.y;
        startingPoint.z = GetComponent<Transform>().position.z;
    }

    void Update()
    {
        playerController.enabled = false;
        Vector3 mask = new Vector3(X ? 0 : 1, Y ? 0 : 1, Z ? 0 : 1); //0 to mask
        Vector3 lockedPosition = new Vector3(X ? startingPoint.x : 0, Y ? startingPoint.y : 0, Z ? startingPoint.z : 0); //original value to add into 0

        Vector3 curr = transform.position;
        Vector3 final = Vector3.Scale(curr, mask) + lockedPosition;
        transform.position = new Vector3(final.x, final.y, final.z);
        playerController.enabled = true;
    }
}
