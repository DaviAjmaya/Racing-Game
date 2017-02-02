using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {
    void Start()
    {
    }
    void OnEnable()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
