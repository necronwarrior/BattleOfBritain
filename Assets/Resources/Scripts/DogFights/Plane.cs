using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    public float health = 100.0f;
    public float damagePerSecond = 20.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float damage) {

        this.health -= damage;
        if (this.health <= 0.0f) {
            Die();
        }
    }

    void Die() { 

        //Destroy(transform.gameobject, 0.2f);

    }

}
