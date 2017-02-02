using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{

    Slider slider;
    AudioSource music;
    public static float musicvolume = 0.5f;

    // Use this for initialization
    void Start()
    {


        slider = GameObject.Find("MusicSlider").GetComponent<Slider>();

        music = GameObject.Find("Music").GetComponent<AudioSource>();

        slider.value = music.volume;


    }

    public void OnValueChanged()
    {
        music.volume = slider.value;
        musicvolume = slider.value;
    }

}
