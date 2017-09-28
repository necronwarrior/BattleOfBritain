using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingermove : MonoBehaviour {

	public bool finish;
	public bool fincontrol;
	float oldpos;
	// Use this for initialization
	void Start () {
		finish = false;
		fincontrol = false;

	//	GetComponent<SplineController> ().StartSpline ();   

	}

	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {
			fincontrol = true;      

			GetComponent<SplineController> ().StartSpline ();   
		}

	
		oldpos = gameObject.transform.position.z;
	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "StopTrail") {
			fincontrol = false;
			finish = true;
			this.enabled = false;
		}
	}
}
