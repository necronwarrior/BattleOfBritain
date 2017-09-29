using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFight : MonoBehaviour {

    private UnityEngine.Object spherePrefab;


    public Vector3 dogfightCenter;
    private bool dogFighting = false;
    private SphereCollider rangeCollider;


    //Dancing Stuff
    public float fightingSpeed = 1.0f;
    public float currentTime = 0.0f;

    //OtherPlane
    Transform otherPlaneTransform;

    void Awake() {

        spherePrefab = Resources.Load("Prefabs/TestSphere");

        rangeCollider = GetComponentInChildren<SphereCollider>();

    }

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

        if (dogFighting) {
            Dance();
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (dogFighting) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane"))
        {
            Debug.Log("Dogfighting");

            dogFighting = true;

            dogfightCenter = transform.position + ((other.gameObject.transform.position - transform.position) /2.0f);

            //dogfightCenter = transform.TransformPoint(dogfightCenter);

            GameObject newSphere = (GameObject)Instantiate(spherePrefab, transform);
            newSphere.transform.position = dogfightCenter;

            this.rangeCollider.radius = this.rangeCollider.radius * 2.0f;

            otherPlaneTransform = other.gameObject.transform;

        }

    }

    void OnTriggerExit(Collider other)
    {

        if (!dogFighting) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyPlane"))
        {
            Debug.Log("End of the dogfight");

            dogFighting = false;

            this.rangeCollider.radius = this.rangeCollider.radius / 2.0f;

            otherPlaneTransform = null;

        }
    }

    void Dance() {

        currentTime += Time.deltaTime;

        Vector3 noiseAxis = new Vector3(
            Mathf.PerlinNoise(currentTime / 3.0f , 0.0f),
            Mathf.PerlinNoise((currentTime+50.0f) / 3.0f, 0.0f),
            Mathf.PerlinNoise((currentTime+100.0f) / 3.0f, 0.0f));
        
        noiseAxis.Scale(new Vector3(2.0f, 2.0f, 2.0f));
        noiseAxis -= new Vector3(1.0f, 1.0f, 1.0f);
        noiseAxis.Normalize();


        Vector3 noiseAxis2 = new Vector3(
            Mathf.PerlinNoise((currentTime + 100.0f) / 3.0f, 0.0f),
            Mathf.PerlinNoise((currentTime + 10.0f) / 3.0f, 0.0f),
            Mathf.PerlinNoise((currentTime + 200.0f) / 3.0f, 0.0f));

        noiseAxis2.Scale(new Vector3(2.0f, 2.0f, 2.0f));
        noiseAxis2 -= new Vector3(1.0f, 1.0f, 1.0f);
        noiseAxis2.Normalize();


        transform.RotateAround(dogfightCenter, noiseAxis, fightingSpeed * Time.deltaTime);
        otherPlaneTransform.RotateAround(dogfightCenter, noiseAxis2, fightingSpeed * Time.deltaTime);
        

    }

}
