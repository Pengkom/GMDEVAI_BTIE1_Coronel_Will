using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public enum Team
	{
		Player,
		Enemy
	}
	
	public GameObject explosion;
	public Team team;
	
	void OnCollisionEnter(Collision col)
    {
    	GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
    	Destroy(e,1.5f);
    	Destroy(this.gameObject);
    }


}
