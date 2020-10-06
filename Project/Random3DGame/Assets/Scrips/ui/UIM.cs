using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
    private static UIM instance = null;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;
    public GameObject Panel1;
    GameObject Panel2;

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
