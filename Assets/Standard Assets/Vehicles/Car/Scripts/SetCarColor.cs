using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarColor : MonoBehaviour {
    Renderer body, body2, body3, interior;
    Renderer[] wheels;
    // Use this for initialization
    void Start () {

        body = GameObject.Find("SkyCarBody").GetComponent<Renderer>();
        body2 = GameObject.Find("SkyCarMudGuardFrontLeft").GetComponent<Renderer>();
        body3 = GameObject.Find("SkyCarMudGuardFrontRight").GetComponent<Renderer>();
        body.material.color = CarColor.bodyColor;
        body2.material.color = CarColor.bodyColor;
        body3.material.color = CarColor.bodyColor;
        wheels = new Renderer[4];
        wheels[0] = GameObject.Find("SkyCarWheelFrontLeft").GetComponent<Renderer>();
        wheels[1] = GameObject.Find("SkyCarWheelFrontRight").GetComponent<Renderer>();
        wheels[2] = GameObject.Find("SkyCarWheelRearLeft").GetComponent<Renderer>();
        wheels[3] = GameObject.Find("SkyCarWheelRearRight").GetComponent<Renderer>();

        for (int i = 0; i < 4; i++)
        {
            wheels[i].material.color = CarColor.wheelsColor;
        }

        interior = GameObject.Find("SkyCarComponents").GetComponent<Renderer>();
        if (CarColor.interiorColor.a != 0)
        {
            interior.materials[0].color = CarColor.interiorColor;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
