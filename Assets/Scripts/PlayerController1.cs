using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    public float jumpHieght;
    public float moveSpeed;
    public float fallSpeed;
    public GameObject keyIndicator;
    //private GameObject player;
    private Rigidbody playerRidgidBody;
    private Transform cameraTransform;
    private Vector3 movementDirection;
    private bool canJump = true;
    [SerializeField]
    private float jumpMovement;
    private float heightAtJump;
    private bool hasKey = false;

    void Start()
    {
        //player = GetComponent<GameObject>();
        playerRidgidBody = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        movementDirection = Vector3.zero;
        heightAtJump = playerRidgidBody.transform.position.z;
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
            if (playerRidgidBody.transform.position.y < jumpHieght +  heightAtJump && canJump)
            {
                jumpMovement = jumpSpeed;
                heightAtJump = playerRidgidBody.transform.position.y;
            }            
        }

        if (Input.GetKeyUp("space"))
        {
            jumpMovement = -fallSpeed;
            canJump = false;
        }

        if (playerRidgidBody.transform.position.y >= jumpHieght + heightAtJump)
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
        if (collision.collider.tag == "Key")
        {
            hasKey = true;
            Destroy(collision.collider.gameObject);
            Instantiate(keyIndicator, playerRidgidBody.transform);
        }
        else if (collision.collider.tag == "Door" && hasKey)
        {
            Destroy(collision.collider.gameObject);
        }
        else
        {
            jumpMovement = 0;
            canJump = true;
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        canJump = true;
    }
}
