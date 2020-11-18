using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coinSound;
    //public AudioClip backgroundSound1;
    //public AudioClip backgroundSound2;
    //public AudioClip backgroundSound3;
    //public AudioSource audio;

    private static SoundManager smInstance;

    private void Awake()
    {
        if (smInstance == null)
        {
            smInstance = this;
            
        }
        else if (smInstance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //audio = GetComponent<AudioSource>();
        //BackGroundMusic();
    }

    //public void BackGroundMusic()
    //{
    //    audio.clip = coinSound;
    //    audio.Play();
    //}

}
