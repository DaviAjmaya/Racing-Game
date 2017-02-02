using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour {

    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {

        Application.runInBackground = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationPause(bool pause)
    {
        pauseMenu.SetActive(true);
    }
}
