using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private Transform goal;
    private float speed = 8.0f;
    private float accuracy = 1.0f;
    private float rotSpeed = 3.0f;
    public GameObject wpManager;
    private GameObject[] wps;
    private GameObject currentNode;
    private int currentWaypointIndex = 0;
    private Graph graph;

    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }
    
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        // the node we are closest to at the moment
        currentNode = graph.getPathPoint(currentWaypointIndex);

        // if we are close enough to the current waypoint, move to the next one
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position, transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        // IF WE ARE NOT AT THE END OF THE PATH
        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoToHelipad()
    {
        graph.AStar(currentNode, wps[11]);
        currentWaypointIndex = 0;
    }

    public void GoToRuins()
    {
        graph.AStar(currentNode, wps[15]);
        currentWaypointIndex = 0;
    }

    public void GoToFactory()
    {
        graph.AStar(currentNode, wps[5]);
        currentWaypointIndex = 0;
    }
    
    public void GoToTwinMountains()
    {
        graph.AStar(currentNode, wps[18]);
        currentWaypointIndex = 0;
    }
    
    public void GoToBarracks()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }
    
    public void GoToCommandCenter()
    {
        graph.AStar(currentNode, wps[17]);
        currentWaypointIndex = 0;
    }
    
    public void GoToOilRefineryPumps()
    {
        graph.AStar(currentNode, wps[14]);
        currentWaypointIndex = 0;
    }
    
    public void GoToTankers()
    {
        graph.AStar(currentNode, wps[13]);
        currentWaypointIndex = 0;
    }
    
    public void GoToRadar()
    {
        graph.AStar(currentNode, wps[16]);
        currentWaypointIndex = 0;
    }
    
    public void GoToCommandPost()
    {
        graph.AStar(currentNode, wps[12]);
        currentWaypointIndex = 0;
    }
    
    public void GoToMiddleOfMap()
    {
        graph.AStar(currentNode, wps[20]);
        currentWaypointIndex = 0;
    }

}
