using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject playerModel; //player object
    public GameObject spawnPoint; //spawn point of player after death 
    float deaths; //death counter 
    UIM UIM; //ui manager
    GameManager GM; //game manger

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("shadow"); // Looks for player object
        UIM = GameObject.Find("UIM").GetComponent<UIM>(); // gets the UI manager
        //GM = GameObject.Find("GM").GetComponent<GameManager>(); // gets the game manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Out of Bounds"))
        {
            Death(); // if the player hits a out of bounds area death function plays 
        }
        if (other.CompareTag("Coin"))
        {
            UIM.ScoreToText();
        }
    }
    
    void Spawn()
    {
        // sets player postion to spawn point 
        playerModel.transform.position = spawnPoint.transform.position; 
    }    

    void Death()
    {
        deaths++; // upddates death counter
        //UIM.deathcount.text = deaths.ToString("0"); // displays deathcounter of screen
        Spawn(); // runs spawn function
    }
}
