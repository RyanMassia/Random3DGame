using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncontroller : MonoBehaviour
{
    private GameObject playerModel;
    private GameObject playerCamera;

    private Rigidbody rb;

    private Vector3 moveVector;
    private Vector3 camOffset;

    [SerializeField]
    [Range(0.1f, 100.0f)]
    private float Sens = 5.0f;

    private float maxSpeed = 5.0f;
    private float moveForce = 2000.0f;
    private float jumpSpeed = 20.0f;
    private float airMoveForce = 35.0f;

    private int layerMask = ~(1 << 8);
    private int maxJumps = 2;
    private int currJumps;

    private bool isJumping = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerModel = GameObject.Find("Player Model");
        playerCamera = GameObject.Find("Player Camera");

        rb = playerModel.GetComponent<Rigidbody>();

        currJumps = maxJumps;
    }

    private void MovementInput()
	{
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
        }
    }

    private void Movement()
    {
        // Check if the player is touching the ground
        RaycastHit hit;
        if (Physics.Raycast(playerModel.transform.position, -playerModel.transform.up, out hit, 0.5f, layerMask))
        {
            // Convert the moveVector force to local space for the player
            rb.AddForce(playerModel.transform.forward * moveVector.z * moveForce);
            rb.AddForce(playerModel.transform.right * moveVector.x * moveForce);
        }
        else
        {
            rb.AddForce(playerModel.transform.forward * moveVector.z * airMoveForce);
            rb.AddForce(playerModel.transform.right * moveVector.x * airMoveForce);
        }

        // Enforce max horizontal velocity
        if (rb.velocity.x > maxSpeed)
		{
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
		}
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }
        if (rb.velocity.z < -maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
        }
    }

    private void CameraMovement()
    {
        playerModel.transform.Rotate(0, Input.GetAxis("Mouse X") * Sens, 0, Space.Self);
    }

    private void Jumping()
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
        MovementInput();
        CameraMovement();
    }

	private void FixedUpdate()
	{
        Jumping();
        Movement();
	}
}
