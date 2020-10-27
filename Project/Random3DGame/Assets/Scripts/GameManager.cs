using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject checkpoint;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateSpawn()
    {
        //player.spawnPoint.transform.position = checkpoint.transform.position;
    }

    public void LevelCompleted()
    {   
    }
}
