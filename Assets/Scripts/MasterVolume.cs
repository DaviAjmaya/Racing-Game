using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour {

    Slider slider;

	// Use this for initialization
	void Start () {

        slider = GameObject.Find("MasterSlider").GetComponent<Slider>();

        slider.value = AudioListener.volume;


	}
	
    
    public void OnValueChanged()
    {
        AudioListener.volume = slider.value;
    }

}
