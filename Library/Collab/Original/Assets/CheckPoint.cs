using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

    TrackSpawner spawn;
    int count;

	// Use this for initialization
	void Start () {

        spawn = gameObject.GetComponent<TrackSpawner>();

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    private void OnTriggerEnter(Collider other)
    {
        int total = TrackSpawner.totalspawn;
        total = total - 1;

       GameObject.Find("CheckP").GetComponent<Text>().text = "CheckPoint" + "\n" + count.ToString() + " " + "/" + " " + total.ToString();

        count++;
        other.enabled = false;


    }
}
