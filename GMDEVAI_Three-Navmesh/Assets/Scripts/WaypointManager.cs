using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction {UNI, BI};
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();
    
    void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }

            foreach (Link a in links)
            {
                graph.AddEdge(a.node1, a.node2);
                if (a.dir == Link.direction.BI)
                {
                    graph.AddEdge(a.node2, a.node1);
                }
            }
        }
    }
    
    void Update()
    {
        graph.debugDraw();
    }
}
