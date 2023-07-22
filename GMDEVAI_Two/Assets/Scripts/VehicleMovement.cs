using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;
    public float speed = 0;
    public float rotSpeed = 1;

    public float acceleration = 5;
    public float deceleration = 5;
    public float minSpeed = 0;
    public float maxSpeed = 10;
    public float breakAngle = 20;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    void LateUpdate() 
    {
        //LookAt but disregard goal's posY by looking at self posY
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);

        //Find direction by subtracting pointB to pointA [Vector3]
        Vector3 direction = lookAtGoal - transform.position;

        //Slowly rotate toward goal(direction)
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);

                                                    //breakAngle value, higher = slower & flipping > to < breaks it
        if (Vector3.Angle(goal.forward, this.transform.forward) > breakAngle && speed > 3)
        {   //Decell
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {   //Acell
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        //Apply
        this.transform.Translate(0, 0, speed);
            
            
        //it don work anymore
        //this.transform.position = Vector3.Lerp(this.transform.position,lookAtGoal, speed);

    }
}
