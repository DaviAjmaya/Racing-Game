using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishLine : MonoBehaviour
{
    public GameObject obj; 
    float time;
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            time = GameObject.Find("Timer").GetComponent<timer>().time;
            StartGame.end = true;
            obj.SetActive(true);
            GameObject.Find("Time").GetComponent<Text>().text = time.ToString("0.00") +  " seconds";
        }

        
    }

    public float Time()
    {
        return time;
    }
}