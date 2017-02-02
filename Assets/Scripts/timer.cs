using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    public float time;
    Text text;
	// Use this for initialization
	void Start ()
    {
        text = GameObject.Find("Timer").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (StartGame.start && !StartGame.end)
        {
            text.enabled = true;
            time += Time.deltaTime;
            text.text = time.ToString("0.00");
        }
    }
}
