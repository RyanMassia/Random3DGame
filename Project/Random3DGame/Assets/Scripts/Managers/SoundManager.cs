using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound;

    private static SoundManager sminstance;

    private void Awake()
    {
        if (sminstance == null)
        {
            sminstance = this;
            DontDestroyOnLoad(this);
        }
        else if (sminstance != this)
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
}
