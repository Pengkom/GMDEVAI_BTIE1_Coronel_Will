using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    private Animator anim;
    public GameObject player;

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
        //anim.SetFloat("health", this.GetComponent<HealthComponent>().currentHealth);
    }
}