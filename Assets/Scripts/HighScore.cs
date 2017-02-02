using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScore : MonoBehaviour
{

    float currentTime;
    public AudioClip music;
    public GameObject highscores;

    // Use this for initialization
    void Start()
    {

        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = music;
        source.loop = true;
        source.volume = MusicVolume.musicvolume;
        source.Play();

        currentTime = GameObject.Find("Timer").GetComponent<timer>().time;
        
        SetHighScore();

        PrintScore();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetHighScore()
    {
        if (currentTime < PlayerPrefs.GetFloat("highscore") || PlayerPrefs.GetFloat("highscore") < 1) 
        {
            PlayerPrefs.SetFloat("highscore", currentTime);
            PlayerPrefs.Save();

            SeeResult();
        }   
    }


    

    void PrintScore()
    {

        string high = PlayerPrefs.GetFloat("highscore").ToString("0.00");

        GameObject.Find("HighScores").GetComponent<Text>().text = high + "   Seconds" ; 


    }

    public void SeeResult()
    {
        if(highscores.activeSelf)
        {
            highscores.SetActive(false);
        }

        else
        {
            highscores.SetActive(true);
        }
    }


 }




