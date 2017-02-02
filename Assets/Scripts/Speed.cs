using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class Speed : MonoBehaviour
    {
        public double speed;
        Text textbox;
        Rigidbody rb;
        public GameObject obj;

        // Use this for initialization
        void Start()    
        {
            rb = obj.GetComponent<Rigidbody>();

            textbox = GameObject.Find("Speed").GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {

            if (StartGame.start && !StartGame.end)
             { 
                speed=rb.velocity.magnitude;
                speed = speed*3.6;
                textbox.enabled = true;
                textbox.text = speed.ToString("0");
            }
        }
    }
