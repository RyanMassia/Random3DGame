using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncontroller : MonoBehaviour
{
    private GameObject playerModel;
    private GameObject playerCamera;

    private Rigidbody rb;

    private Vector3 moveVector;
    private Vector3 localMoveDirection;

    [SerializeField]
    [Range(0.1f, 100.0f)]
    private float Sens = 5.0f;

    private float maxSpeed = 2.0f;
    private float moveForce = 500.0f;
    private float jumpForce = 200.0f;
    private float airMoveForce = 200.0f;

    private int layerMask = ~(1 << 8);
    private int maxJumps = 2;
    private int currJumps;

    private bool isJumping = false;
    private bool hasAirJumped = false;

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
        // Create a normalized moveVector with no vertical component
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveVector.Normalize();

        // Determine if the player has jumped
        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
        }
        else if (Input.GetKeyUp("space"))
		{
            isJumping = false;
		}
    }

    private void Movement()
    {
		// Check if the player is touching the ground
		RaycastHit hit;
		if (Physics.Raycast(playerModel.transform.position, -playerModel.transform.up, out hit, 0.5f, layerMask))
		{
			// Convert the moveVector force to local space for the player
			rb.AddForce(playerModel.transform.forward * moveVector.z * moveForce, ForceMode.Acceleration);
			rb.AddForce(playerModel.transform.right * moveVector.x * moveForce, ForceMode.Acceleration);
		}
		else
		{
			// When not touching the ground use a smaller move force so the player has less control
			rb.AddForce(playerModel.transform.forward * moveVector.z * airMoveForce, ForceMode.Acceleration);
			rb.AddForce(playerModel.transform.right * moveVector.x * airMoveForce, ForceMode.Acceleration);
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
        if (Physics.Raycast(playerModel.transform.position, -playerModel.transform.up, out hit, 0.5f, layerMask) && isJumping)
        {
            // Reset the player's air jump potential
            hasAirJumped = false;

            // Set the player's vertical speed to 0
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

            // Add a vertical impulse force to the player model
            rb.AddForce(playerModel.transform.up * jumpForce, ForceMode.Impulse);

            isJumping = false;
        }
        // Allow the player one jump while in the air
		else if (!hasAirJumped && isJumping)
		{
            // Disallow the player from jumping a second time in the air
            hasAirJumped = true;

            // Set the player's vertical speed to 0
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

            // Add a vertical impulse force to the player model
            rb.AddForce(playerModel.transform.up * jumpForce, ForceMode.Impulse);

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
