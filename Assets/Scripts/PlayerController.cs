using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    public float jumpHieght;
    public float moveSpeed;
    public float fallSpeed;
    //private GameObject player;
    private Rigidbody playerRidgidBody;
    private Transform cameraTransform;
    private Vector3 movementDirection;
    private bool canJump = true;
    [SerializeField]
    private float jumpMovement;

    void Start()
    {
        //player = GetComponent<GameObject>();
        playerRidgidBody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        movementDirection = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            movementDirection.z = moveSpeed;
        }
        if (Input.GetKeyUp("w")||Input.GetKeyUp("up"))
        {
            movementDirection.z = 0;
        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            movementDirection.x = -moveSpeed;
        }
        if (Input.GetKeyUp("a")||Input.GetKeyUp("left"))
        {
            movementDirection.x = 0;
        }
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            movementDirection.z = -moveSpeed;
        }
        if (Input.GetKeyUp("s")||Input.GetKeyUp("down"))
        {
            movementDirection.z = 0;
        }
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            movementDirection.x = moveSpeed;
        }
        if (Input.GetKeyUp("d")||Input.GetKeyUp("right"))
        {
            movementDirection.x = 0;
        }
        if (Input.GetKeyDown("space"))
        {
            if (playerRidgidBody.transform.position.y < jumpHieght && canJump)
            {
                jumpMovement = jumpSpeed;
            }            
        }

        if (Input.GetKeyUp("space"))
        {
            jumpMovement = -fallSpeed;
            canJump = false;
        }

        if (playerRidgidBody.transform.position.y >= jumpHieght)
        {
            jumpMovement = -fallSpeed;
            canJump = false;
        }


        Vector3 move = cameraTransform.TransformVector(movementDirection);
        move.y = jumpMovement;
        playerRidgidBody.velocity = move;
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpMovement = 0;
        canJump = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        canJump = true;
    }
}
