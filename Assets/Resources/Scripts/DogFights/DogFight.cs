using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFight : MonoBehaviour {



    public Vector3 dogfightCenter;
    private bool dogFighting = false;
    private SphereCollider rangeCollider;


    //Dancing Stuff
    private Vector3 targetDancingPoint;
    public float targetThreshold = 0.1f;
    public float sphereDancingRadius = 1.0f;
    public float fightingSpeed = 1.0f;

    void Awake() {

        rangeCollider = GetComponentInChildren<SphereCollider>();

    }

	// Use this for initialization
	void Start () {

        targetDancingPoint.Set(100.0f, 100.0f, 100.0f);


    }
	
	// Update is called once per frame
	void Update () {

        if (dogFighting) {
            Dance();
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane"))
        {
            Debug.Log("Dogfighting");

            dogFighting = true;

            dogfightCenter = other.gameObject.transform.position;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane"))
        {
            Debug.Log("End of the dogfight");

            dogFighting = false;
        }
    }

    void Dance() {

        // We get a new targe if we reached the previous one (or the first one for that matter)
        if ((transform.position - targetDancingPoint).magnitude < targetThreshold) {
            Debug.Log("Changing target");
            targetDancingPoint = dogfightCenter + Random.onUnitSphere * sphereDancingRadius;
        }

        float step = Time.deltaTime * fightingSpeed;

        Vector3 deltaPosition = ((targetDancingPoint - transform.position) * step);
        
        Vector3 nextPosition = transform.position + deltaPosition;


        var targetRotation = Quaternion.LookRotation(deltaPosition);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);


    }

}
