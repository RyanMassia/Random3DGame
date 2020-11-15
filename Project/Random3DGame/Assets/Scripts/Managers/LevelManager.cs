using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

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
        // loads a scene selected in the scence manager
        SceneManager.LoadScene(sceneName);
    }
    //to be worked on
    //public void ExitScene(int sceneIndex)
    //{
    //    SceneManager.UnloadSceneAsync(sceneIndex);
    //}
}
