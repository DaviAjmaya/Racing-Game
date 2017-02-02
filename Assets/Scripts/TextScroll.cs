using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour {
    Text txt;
    Scrollbar scroll;
	// Use this for initialization
	void Start () {
        txt = GameObject.Find("ScrollText").GetComponent<Text>();
        scroll = GameObject.Find("Scrollbar").GetComponent<Scrollbar>();
		
	}
	
    public void changeText(int value)
    {
        if (scroll.value >= 0 && scroll.value < 0.33f)
        {
            txt.text = "Body";
        }
        else if (scroll.value > 0.33f && scroll.value < 0.66f)
        {
            txt.text = "Interior";
        }
        else
        {
            txt.text = "Wheels";
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
