using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float detectionRadius = 5;

    private NavMeshAgent agent;
    private Animator animator;

    public GameObject GetPlayer()
    {
        return player;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
    }

    public void DetectNewTarget(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(location, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
            }
        }
    }
}