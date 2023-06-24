using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    private GameObject[] goalLocations;
    private NavMeshAgent agent;
    private Animator animator;
    private float speedMultiplier;
    private float detectionRadius = 6;
    private float fleeRadius = 10;

    void ResetAgent()
    {
        speedMultiplier = Random.Range(0.1f, 1.5f);
        agent.speed = 2 * speedMultiplier;
        agent.angularSpeed = 120;
        animator.SetFloat("speedMultiplier", speedMultiplier);
        animator.SetTrigger("isWalking");
        agent.ResetPath();
    }
    
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        animator.SetTrigger("isWalking");
        animator.SetFloat("wOffset", Random.Range(0.1f, 1f));
        ResetAgent();
    }
    
    void LateUpdate()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }

    public void DetectNewObstacle(Vector3 location, GameObject target)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            if (target.name == "Monster")
            {
                Vector3 fleeDirection = (this.transform.position - location).normalized;
                Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(newGoal, path);

                if (path.status != NavMeshPathStatus.PathInvalid)
                {
                    agent.SetDestination(path.corners[path.corners.Length - 1]);
                    animator.SetTrigger("isRunning");
                    agent.speed = 10;
                    agent.angularSpeed = 500;   
                }
            }
            else if (target.name == "Not Monster")
            {
                Vector3 toDirection = (location - this.transform.position).normalized;
                Vector3 newGoal = this.transform.position + toDirection;

                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(newGoal, path);

                if (path.status != NavMeshPathStatus.PathInvalid)
                {
                    agent.SetDestination(path.corners[path.corners.Length - 1]);
                    animator.SetTrigger("isRunning");
                    agent.speed = 10;
                    agent.angularSpeed = 500;   
                }
            }

        }
    }
}
