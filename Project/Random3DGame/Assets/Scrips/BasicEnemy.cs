using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
	private Rigidbody playerRB;
	private GameObject playerModel;
	
	private NavMeshAgent agent;

	// How hard the enemies push the player
	private float pushForce;

	// The cd before an enemy can move again after pushing the player
	private int cooldown;
	private int cdTimer;

	private void Start()
	{
		playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
		playerModel = GameObject.Find("Player Model");
		agent = GetComponent<NavMeshAgent>();

		cooldown = 150;
		cdTimer = 0;
		pushForce = 2000;
	}

	private void Update()
	{
		// Set the target destination to the player
		if (cdTimer == 0)
		agent.SetDestination(playerModel.transform.position);

		// Check if the player is within 1 unit of this enemy
		if (Vector3.Distance(playerModel.transform.position, transform.position) < 2)
		{
			// Put this enemy on cooldown for 'cooldown' frames
			cdTimer = cooldown;
			agent.SetDestination(transform.position);
			
			// Push the player away
			playerRB.AddForce(new Vector3(playerModel.transform.position.x - transform.position.x, 0, playerModel.transform.position.z - transform.position.z).normalized * pushForce);
		}

		// Decrement the cd timer
		if (cdTimer > 0)
		{
			cdTimer -= 1;
		}

	}
}
