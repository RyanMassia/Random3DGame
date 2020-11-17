using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    UIM UIM; //ui manager
    //GameManager GM; //game manger
    GameObject playerModel; //player object
    public GameObject spawnPoint; //spawn point of player after death 
    float deaths; //death counter 
    public float health = 100f; // keeps track of player healtrh

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("shadow"); // Looks for player object
        UIM = GameObject.Find("UIM").GetComponent<UIM>(); // gets the UI manager
        //GM = GameObject.Find("GM").GetComponent<GameManager>(); // gets the game manager
    }

    void DamageTaken()
    {
        //TBC
    }

    void Spawn()
    {
        // sets player postion to spawn point 
        health = 100;// resets health to 100
        playerModel.transform.position = spawnPoint.transform.position; 
    }    

    void Death()
    {
        deaths++; // upddates death counter
        Spawn(); // runs spawn function
    }


    //add other functions above please
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Out of Bounds"))
        {
            Death(); // if the player hits a out of bounds area death function plays 
        }
        if (other.CompareTag("Coin"))
        {
            UIM.ScoreToText();
        }
        //if (other.CompareTag("Enemy"))
        //{
        //    DamageTaken(); TBC
        //}
    }
}
