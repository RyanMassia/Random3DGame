using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
    private static UIM instance = null;
    public Text timerText;
    public GameObject levelPanel;
    public Text deathcount;
    public Text ScoreText;
    GameManager GM;

    float seconds;
    float minutes;

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
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //levelPanel = GameObject.Find("Level Panel");
    }

    // Update is called once per frame
    void Update()
    {
        Timer(timerText);
    }

    void Timer(Text trackTime)
    {
        // has the floats track time in mintues and seconds 
        minutes = (int)(Time.time / 60.0f);
        seconds = (int)(Time.time % 60.0f);
        //converts the floats to a string to be displayed in game 
        trackTime.text = minutes.ToString("0") + ":" + seconds.ToString("00");
    }

    public void ScoreToText()
    {
        GM.ScoreUpdate();
        ScoreText.text = GM.score.ToString("0");
    }


    public void openPanel(GameObject Panel)
    {
        //sets the current panel to active 
        Panel.SetActive(true);
    }

    public void closePanel(GameObject Panel)
    {
        //closes the current panel open 
        Panel.SetActive(false);
    }

    //public void MusicToggle() TBC
    //{

    //}

    //closes the application and quits the game 
    public void quitGame()
    {
        Application.Quit();
    }


}
