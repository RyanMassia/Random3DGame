using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncontroller : MonoBehaviour
{
    private GameObject playerModel;
    private GameObject playerCamera;

    private Rigidbody rb;

    [SerializeField]
    [Range(0.1f, 100.0f)]
    private float vSens = 5.0f;
    [SerializeField]
    [Range(0.1f, 100.0f)]
    private float hSens = 5.0f;

    private float moveSpeed = 0.05f;
    private float jumpSpeed = 20.0f;

    private int layerMask = ~(1 << 8);
    private int maxJumps = 2;
    private int currJumps;

    private bool isJumping = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        playerModel = GameObject.Find("Player Model");
        playerCamera = GameObject.Find("Player Camera");

        currJumps = maxJumps;
    }

    void Movement()
	{
        if (Input.GetKey("w"))
        {
            transform.position += moveSpeed * transform.forward;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= moveSpeed * transform.forward;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= moveSpeed * transform.right;
        }
        if (Input.GetKey("d"))
        {
            transform.position += moveSpeed * transform.right;
        }

        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
        }
    }

    void CameraMovement()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * hSens, 0, Space.Self);

        // Lock the camera to above and behind the playerModel
        if ((playerCamera.transform.position.y - playerModel.transform.position.y > 1 && Input.GetAxis("Mouse Y") > 0) ||
            (Vector3.Dot(playerModel.transform.forward, -playerCamera.transform.forward) < 0 && Input.GetAxis("Mouse Y") < 0))   // Dot product will be negative when the camera is behind the player
        {
            playerCamera.transform.RotateAround(playerModel.transform.position, playerModel.transform.right, -Input.GetAxis("Mouse Y") * vSens);
        }
    }

    void Jumping()
	{
        // Check if the player is on the ground
        RaycastHit hit;
        if (Physics.Raycast(playerModel.transform.position, -playerModel.transform.up, out hit, 0.5f, layerMask))
		{
            // Reset the amount of jumps the player has available
            currJumps = maxJumps;
		}

        // Limit the player's jumps to maxJumps 
        if (currJumps > 0 && isJumping)
        {
            // Set the player's vertical velocity
            rb.velocity = transform.up * jumpSpeed;
            currJumps--;
            isJumping = false;
        }
    }

    private void Update()
	{
        Movement();
        CameraMovement();
    }

	private void FixedUpdate()
	{
        Jumping();
	}
}
