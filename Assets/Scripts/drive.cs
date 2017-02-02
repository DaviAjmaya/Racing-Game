using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class drive : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    float acceleration = 0.0F;


    // Update is called once per frame
    void Update () {
        if (StartGame.start)
        {
            float translation = speed * acceleration; // translation is the value for going forward or backwards 
            float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed; // rotate is the value for turning 

            // Makes the controls consistent 
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation); // Applies the value so the car will start moving 
            transform.Rotate(0, rotation, 0); // Applies the value so the car will turn 

            acceleratControle();
        }

    }

    void acceleratControle()
    {
        if(CrossPlatformInputManager.GetAxis("Vertical") == 1.0)
        {
            if(acceleration < 1F)
               acceleration += 0.1F * Time.deltaTime;
        }
        else
        {
            if (acceleration > 0.0F)
                acceleration -= 0.1F * Time.deltaTime;
        }
    }
}
