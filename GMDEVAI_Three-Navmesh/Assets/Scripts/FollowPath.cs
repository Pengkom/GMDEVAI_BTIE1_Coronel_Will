using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject wpManager;
    private GameObject[] wps;

    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<NavMeshAgent>();
    }
    
    

    public void GoToHelipad()
    {
        // graph.AStar(currentNode, wps[11]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[11].transform.position);
    }
    
    public void GoToRuins()
    {
        // graph.AStar(currentNode, wps[15]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[15].transform.position);
    }
    
    public void GoToFactory()
    {
        // graph.AStar(currentNode, wps[5]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[5].transform.position);
    }
    
    public void GoToTwinMountains()
    {
        // graph.AStar(currentNode, wps[18]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[18].transform.position);
    }
    
    public void GoToBarracks()
    {
        // graph.AStar(currentNode, wps[9]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[9].transform.position);
    }
    
    public void GoToCommandCenter()
    {
        // graph.AStar(currentNode, wps[17]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[17].transform.position);
    }
    
    public void GoToOilRefineryPumps()
    {
        // graph.AStar(currentNode, wps[14]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[14].transform.position);
    }
    
    public void GoToTankers()
    {
    //     graph.AStar(currentNode, wps[13]);
    //     currentWaypointIndex = 0;
        agent.SetDestination(wps[13].transform.position);
    }
    
    public void GoToRadar()
    {
        // graph.AStar(currentNode, wps[16]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[16].transform.position);
    }
    
    public void GoToCommandPost()
    {
        // graph.AStar(currentNode, wps[12]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[12].transform.position);
    }
    
    public void GoToMiddleOfMap()
    {
        // graph.AStar(currentNode, wps[20]);
        // currentWaypointIndex = 0;
        agent.SetDestination(wps[20].transform.position);
    }

}
