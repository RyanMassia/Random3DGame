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

    private float moveForce = 100.0f;
    private float airMoveForce = 35.0f;
    private float maxSpeed = 5.0f;
    private float slowForce = 3.0f;
    private float jumpForce = 200.0f;

    private int layerMask = ~(1 << 8);

    private bool isJumping = false;
    private bool hasAirJumped = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerModel = GameObject.Find("Player Model");
        playerCamera = GameObject.Find("Player Camera");

        rb = playerModel.GetComponent<Rigidbody>();
    }

    private void MovementInput()
	{
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveVector.Normalize();
        // Convert to local space
        moveVector = rb.transform.TransformDirection(moveVector);

        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
        }
    }

    private void Movement()
    {
        // Check if the player is touching the ground, slow their movement if in the air
        if (TouchingGround())
        {
            rb.AddForce(moveVector * moveForce, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveVector * airMoveForce, ForceMode.Acceleration);
        }

        Vector3 horizVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Check if the player has exceeded the max speed, add force in the opposite direction if they have
        if (horizVel.magnitude > maxSpeed)
		{
            rb.AddForce(-horizVel * slowForce, ForceMode.Acceleration);
		}
    }

    private void CameraMovement()
    {
        playerModel.transform.Rotate(0, Input.GetAxis("Mouse X") * Sens, 0, Space.Self);
    }

    private void Jumping()
	{
        // Check if the player is grounded
        bool isGrounded = TouchingGround();

        // Reset their air jumps if they are
        if (isGrounded)
		{
            hasAirJumped = false;
		}

        // Check if the player has pressed the jump button
        if (isJumping)
        {
            if (isGrounded)
			{
                // Set the player's vertical velocity to 0
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

                // Add an upward impulse force to the rb
                rb.AddForce(rb.transform.up * jumpForce, ForceMode.Impulse);
            }
            // If they are in the air and have an air jump available
            else if (!isGrounded && !hasAirJumped)
            {
                // Stops the player from air jumping multiple times
                hasAirJumped = true;

                // Set the player's vertical velocity to 0
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

                // Add an upward impulse force to the rb
                rb.AddForce(rb.transform.up * jumpForce, ForceMode.Impulse);
            }

            isJumping = false;
        }
    }

    private bool TouchingGround()
	{
        // Check if the player is on the ground
        if (Physics.Raycast(playerModel.transform.position, -playerModel.transform.up, 0.5f, layerMask))
        {
            return true;
        }
        return false;
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
