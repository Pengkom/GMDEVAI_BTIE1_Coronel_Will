using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject player;
    private GameObject[] agents;
    
    
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    void Update()
    {
        foreach (GameObject ai in agents)
        {
            ai.GetComponent<AIControl>().agent.SetDestination(player.transform.position);
        }
    }
}
