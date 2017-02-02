using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class pause : MonoBehaviour {

    public AudioClip music;


	// Use this for initialization
	void Start () {

        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = music;
        source.loop = true;
        source.volume = MusicVolume.musicvolume;
        source.Play();

    }
    void OnEnable()
    {
        Time.timeScale = 0;
    }
    void OnDisable()
    {
        Time.timeScale = 1;
    }
}
