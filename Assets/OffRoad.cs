using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffRoad : MonoBehaviour
{
    Ray rayLeft;
    RaycastHit hit;
    public Transform rayStart;
    public Rigidbody car;
    public static bool offroad;

    // Use this for initialization
    void Start()
    {
        rayLeft.direction = Vector3.down;
        rayLeft.origin = rayStart.position;
    }

    // Update is called once per frame
    void Update()
    {
        //shoot raycast under car
        rayLeft.origin = rayStart.position;
        if (Physics.Raycast(rayLeft, out hit))
        {
            //check if on road
            if (hit.collider.gameObject.name == "road" || hit.collider.gameObject.name == "road_curve") //on road
            {
                car.drag = 0.1f;
                offroad = false;

            } 
            else //off road
            {
                car.drag = 1f;
                offroad = true;

            }
        }

    }
}
