using UnityEngine;

public class Stone : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject obstacle;
    public GameObject target;
    private GameObject[] agents;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        agents = GameObject.FindGameObjectsWithTag("Zombie");

        Physics.IgnoreLayerCollision(3, 3);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            foreach (GameObject a in agents)
            {
                a.GetComponent<ZombieAI>().DetectNewTarget(gameObject.transform.position);
            }
        }
    }
}
