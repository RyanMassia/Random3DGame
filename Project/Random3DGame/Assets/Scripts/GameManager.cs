using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{  
    UIM UIM;
    public int score = 0;
    private static GameManager instance = null;

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
        UIM = GameObject.Find("UIM").GetComponent<UIM>();
    }

    public void ScoreUpdate()
    {
        score++;
    }

    public void LevelCompleted()
    {
        UIM.levelPanel.SetActive(true);
    }
}
