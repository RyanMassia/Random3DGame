using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject playerModel; // player object
    public GameObject spawnPoint; // spawn point of player after death 
    public float deaths; // death counter 
    UIM UIM;
    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("Player Model"); // Looks for player object
        UIM = GameObject.Find("UIM").GetComponent<UIM>();
        GM = GameObject.Find("GM").GetComponent<GameManager>();
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
        //if(other.CompareTag("Check Point"))
        //{
        //    GM.UpdateSpawn(); to be fixed 
        //    Debug.Log("updated");
        //}
        if(other.CompareTag("end zone"))
        {
            //GM.
        }
    }
    
    void Spawn()
    {
        playerModel.transform.position = spawnPoint.transform.position; // sets player postion to spawn point 
    }    

    void Death()
    {
        deaths++; // upddates death counter
        UIM.deathcount.text = deaths.ToString("0"); // displays deathcounter of screen
        Spawn(); // runs spawn function
    }
}
