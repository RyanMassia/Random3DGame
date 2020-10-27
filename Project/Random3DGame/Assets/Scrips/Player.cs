using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject playerModel; // player object
    public float health; // players health
    public float deaths; // death counter 
    public GameObject spawnPoint; // spawn point of player after death 
    public GameObject checkPoint; // safe points throughout the level
    //public GameObject deathPoint; // place where death occurs 

    // Start is called before the first frame update
    void Start()
    {
        health = 100.0f;
        playerModel = GameObject.Find("Player"); // Looks for player opbject
    }

    // Update is called once per frame
    void Update()
    {
        // Needs work PlayerDeath();
    }

    void OnTriggerEnter(Collider other)
    {
        
        Spawn();
       
        
    }
    

    void Spawn()
    {
        playerModel.transform.position = spawnPoint.transform.position;
    }

    //Needs work 
    
}
