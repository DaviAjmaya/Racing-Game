using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    AudioSource volume;

    // Use this for initialization
    void Start()
    {

        volume = GameObject.Find("Music").GetComponent<AudioSource>();
        volume.volume = MusicVolume.musicvolume;
    }

}

