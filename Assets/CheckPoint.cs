using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

  
    int count;
    int total;

	// Use this for initialization
	void Start () {

        count = 0;
        total = 0;
        
        


    }
	
	// Update is called once per frame
	void Update () {

		
	}

    private void OnTriggerEnter(Collider other)
    {   
        if(total==0)
        {
			total = TrackSpawner.count;
        }
			
        GameObject.Find("CheckP").GetComponent<Text>().text = "CheckPoint" + "\n" + count.ToString() + " " + "/" + " " + total.ToString();
		count++;
        other.enabled = false;


    }
}
