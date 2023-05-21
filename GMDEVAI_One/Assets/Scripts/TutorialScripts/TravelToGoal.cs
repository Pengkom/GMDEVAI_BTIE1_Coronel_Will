using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToGoal : MonoBehaviour
{
    public Transform goal;
    private float speed = 5;
    
    void Start()
    {
        
    }
    
    void LateUpdate() //EVERY FRAME
    {
        //Find direction by subtracting pointB to pointA's vector/position (xyz)
        //NOTE: Direction = B - A
        Vector3 direction = goal.position - this.transform.position;
        
        //LookAt...
        transform.LookAt(goal);

        //Stop movement when too close
        if (direction.magnitude > 1)
        {
            //Movement Maths
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        
    }
}
