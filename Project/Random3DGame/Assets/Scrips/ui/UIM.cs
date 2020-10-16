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
        minutes = (int)(Time.time / 60.0f);
        seconds = (int)(Time.time % 60.0f);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); 
    }

    public void openPanel(GameObject Panel)
    {
        Panel.SetActive(true);
    }

    public void closePanel(GameObject Panel)
    {
        Panel.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
