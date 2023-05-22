using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    private float speed = 4;
    private float rotSpeed = 3;
    
    void LateUpdate() //EVERY FRAME
    {
        //LookAt but disregard goal's posY by looking at self posY
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        
        //Find direction by subtracting pointB to pointA [Vector3]
        Vector3 direction = lookAtGoal - transform.position;

        //Slowly rotate toward goal(direction)
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        
        //FOR LERP---------------------------------------------------------------------------------------------------------------------------------
        //Calculate distance [Distance/Magnitude]
        float distance = Vector3.Distance(lookAtGoal, this.transform.position);

        //Stop movement when too close
        if (distance > 2)   
        {
            //Movement Maths
            this.transform.position = Vector3.Lerp(this.transform.position, lookAtGoal, (Time.deltaTime * speed) / distance);
            
        }
        
    }
}
