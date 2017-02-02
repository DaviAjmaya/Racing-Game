using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name.ToString());
        if (other.name == "ColliderBottom")
        {
            Debug.Log("d");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
