using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Looks for the player tag 
        {
            other.gameObject.transform.parent = transform; // sets transform to same as platform so player doesnt fall off 
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player")) // Looks for the player tag 
        {
            other.gameObject.transform.parent = null; // upon leabing the platform transform parent is reset 
        }

    }
}
