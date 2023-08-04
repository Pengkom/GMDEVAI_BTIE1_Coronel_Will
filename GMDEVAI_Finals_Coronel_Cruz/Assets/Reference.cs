using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Reference : MonoBehaviour
{
    //Application.targetFrameRate = 60; LIMIT FPS SO UPDATE CAN BE IN SYNC
    
    #region TankAI
    /*
        public class TankAI : MonoBehaviour
        {
            private Animator anim;
            public GameObject player;
            public GameObject bullet;
            public GameObject turret;

            public GameObject GetPlayer()
            {
                return player;
            }

            private void Start()
            {
                anim = this.GetComponent<Animator>();
            }

            private void Update()
            {
                anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
                anim.SetFloat("health", this.GetComponent<HealthComponent>().currentHealth);
            }

            private void Fire()
            {
                GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
                b.GetComponent<Bullet>().team = Bullet.Team.Enemy;
            }
       
            public void StartFiring()
            {
                InvokeRepeating("Fire", 0.5f, 0.5f);
            } 
       
            public void StopFiring()
            {
                CancelInvoke("Fire");
            }
        }
    */
    #endregion

    #region Dynamic Obstacle Spawn
    /*
    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Instantiate(monster, hit.point, monster.transform.rotation);
            foreach (GameObject a in agents)
            {
                a.GetComponent<AIControl>().DetectNewObstacle(hit.point, monster);
            }
        }
    }
    
    public void DetectNewObstacle(Vector3 location, GameObject target)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
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
    }
    */
    #endregion

    #region BaseFSM
    /*
        public class NPCBaseFSM : StateMachineBehaviour
        {
            public GameObject NPC;
            public GameObject opponent;
            public float speed = 2.0f;
            public float rotSpeed = 1.0f;
            public float accuracy = 3.0f;

            public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                NPC = animator.gameObject;
                opponent = NPC.GetComponent<TankAI>().GetPlayer();
            }


        }
     */
    #endregion
     
    #region ChaseFSM
    /*
        public class Chase : NPCBaseFSM
        {
            public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                base.OnStateEnter(animator, stateInfo, layerIndex);
            }

            public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                var direction = opponent.transform.position - NPC.transform.position;
                NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
                                                            Quaternion.LookRotation(direction),
                                                            rotSpeed * Time.deltaTime); 
                NPC.transform.Translate(0, 0, Time.deltaTime * speed); 
            }
        }
    */
    #endregion
    
    #region AttackFSM
    /*
        public class Attack : NPCBaseFSM
        {
            public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                base.OnStateEnter(animator, stateInfo, layerIndex);
                NPC.GetComponent<TankAI>().StartFiring();
            }

            public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                NPC.transform.LookAt(opponent.transform.position);
            }

            public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                NPC.GetComponent<TankAI>().StopFiring();
            }
        }
    */
    #endregion

    #region PatrolWaypointFSM
    /*
        public class Patrol : NPCBaseFSM
        {
            private GameObject[] waypoints;
            private int currentWaypoint;

            private void Awake()
            {
                waypoints = GameObject.FindGameObjectsWithTag("waypoint");
            }

            // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
            override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                base.OnStateEnter(animator, stateInfo, layerIndex);
                currentWaypoint = Random.Range(0, waypoints.Length);
            }

            // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
            override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                base.OnStateUpdate(animator, stateInfo, layerIndex);
                
                if (waypoints.Length == 0) return;

                if (Vector3.Distance(waypoints[currentWaypoint].transform.position, NPC.transform.position) < accuracy)
                {
                    currentWaypoint++;
                    if (currentWaypoint >= waypoints.Length)
                    {
                        currentWaypoint = Random.Range(0, waypoints.Length);
                    }
                }

                var direction = waypoints[currentWaypoint].transform.position - NPC.transform.position;
                NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
                                                            Quaternion.LookRotation(direction),
                                                            rotSpeed * Time.deltaTime);
                
                NPC.transform.Translate(0, 0, Time.deltaTime * speed); 
            }

            // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
            override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                base.OnStateExit(animator, stateInfo, layerIndex);
            }
        }
    */
    #endregion
    
    #region FPSController WHOLESCRIPT
    /*
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        [RequireComponent(typeof(CharacterController))]

        public class SC_FPSController : MonoBehaviour
        {
            public float walkingSpeed = 7.5f;
            public float runningSpeed = 11.5f;
            public float jumpSpeed = 8.0f;
            public float gravity = 20.0f;
            public Camera playerCamera;
            public float lookSpeed = 2.0f;
            public float lookXLimit = 45.0f;

            CharacterController characterController;
            Vector3 moveDirection = Vector3.zero;
            float rotationX = 0;

            [HideInInspector]
            public bool canMove = true;

            void Start()
            {
                characterController = GetComponent<CharacterController>();

                // Lock cursor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            void Update()
            {
                // We are grounded, so recalculate move direction based on axes
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                // Press Left Shift to run
                bool isRunning = Input.GetKey(KeyCode.LeftShift);
                float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
                float movementDirectionY = moveDirection.y;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
                {
                    moveDirection.y = jumpSpeed;
                }
                else
                {
                    moveDirection.y = movementDirectionY;
                }

                // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
                // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
                // as an acceleration (ms^-2)
                if (!characterController.isGrounded)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }

                // Move the controller
                characterController.Move(moveDirection * Time.deltaTime);

                // Player and Camera rotation
                if (canMove)
                {
                    rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                }
            }
        }
    */
    #endregion
}
