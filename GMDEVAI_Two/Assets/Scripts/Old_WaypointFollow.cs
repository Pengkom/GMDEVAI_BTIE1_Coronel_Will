using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_WaypointFollow : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    
    [SerializeField]private float speed = 5;
    [SerializeField]private float rotSpeed = 3;
    [SerializeField]private float accuracy = 1;
    
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        
    }
    
    void LateUpdate()
    {
        if (waypoints.Length == 0) return;

        GameObject currentWaypoint = waypoints[currentWaypointIndex];

        Vector3 lookAtGoal = new Vector3(currentWaypoint.transform.position.x, 
                                        this.transform.position.y, 
                                        currentWaypoint.transform.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        if (direction.magnitude < 1.0f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);
        
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
