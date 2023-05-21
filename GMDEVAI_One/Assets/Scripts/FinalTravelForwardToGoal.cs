using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTravelForwardToGoal : MonoBehaviour
{
    public Transform goal;
    private float speed = 3;
    private float rotSpeed = 3;
    
    void LateUpdate() //EVERY FRAME
    {
        //LookAt but disregard goal's posY by looking at self posY
        Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        
        //Find direction by subtracting pointB to pointA
        Vector3 direction = lookAtGoal - transform.position;

        //Slowly rotate toward goal(direction)
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        //Stop movement when too close
        if (Vector3.Distance(lookAtGoal, transform.position) > 1)
        {
            //Movement Maths
            Vector3.Lerp(this.transform.position, goal.position, speed * Time.deltaTime);
        }
        
    }
}
