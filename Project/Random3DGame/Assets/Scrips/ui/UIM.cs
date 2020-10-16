using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
    private static UIM instance = null;
    public Text timerText;

    public float seconds;
    public float minutes;

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
        Timer(timerText);
    }

    void Timer(Text trackTime )
    {
        // has the floats track time in mintues and seconds 
        minutes = (int)(Time.time / 60.0f);
        seconds = (int)(Time.time % 60.0f);
        //converts the floats to a string to be displayed in game 
        trackTime.text = minutes.ToString("00") + ":" + seconds.ToString("00");
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

    //closes the application and quits the game 
    public void quitGame()
    {
        Application.Quit();
    }
}
