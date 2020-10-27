using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repsawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnpoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.transform.position = spawnpoint.transform.position;
            //Physics.SyncTransforms();
        }
        
    }

}
