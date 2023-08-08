using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;

    public float rockDetectionRadius = 5;

    [Header("AI LoS")] 
    public float sightRadius;
    public float angle;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;

    private float defaultSightRadius;
    private float debuffedSightRadius;
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
        playerController = player.GetComponent<PlayerController>();
            
        defaultSightRadius = sightRadius;
        debuffedSightRadius = defaultSightRadius / 2;
    }

    private void Update()
    {
        animator.SetFloat("Distance", Vector3.Distance(this.transform.position, player.transform.position));

        SneakDebuff();
        CheckView();
        animator.SetBool("PlayerDetected", canSeePlayer);
    }
    
    private void CheckView()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(this.transform.position, sightRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - this.transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(this.transform.position, target.position);

                if (!Physics.Raycast(this.transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else canSeePlayer = false;
            }
        }
        // else if(canSeePlayer)
        // {
        //     canSeePlayer = false;
        // }
    }

    private void SneakDebuff()
    {
        if (playerController.sneaking)
        {
            sightRadius = debuffedSightRadius;
        }
        else sightRadius = defaultSightRadius;
    }
    
    
    //Stone Throw
    public void DetectNewTarget(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < rockDetectionRadius)
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