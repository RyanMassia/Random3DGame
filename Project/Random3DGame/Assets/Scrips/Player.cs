using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject playerModel; // player object
    public GameObject spawnPoint; // spawn point of player after death 
    //public GameObject checkPoint; // safe points throughout the level
    public float health; // players health
    public float deaths; // death counter 

    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        playerModel = GameObject.Find("Player Model"); // Looks for player object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Out of Bounds"))
        {
            Spawn();
        }  
    }
    
    void Spawn()
    {
        playerModel.transform.position = spawnPoint.transform.position;
    }    
}
