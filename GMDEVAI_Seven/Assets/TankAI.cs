using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

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
