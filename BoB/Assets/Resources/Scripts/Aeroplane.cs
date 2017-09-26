using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aeroplane : MonoBehaviour {

	public GameObject Finger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Finger.GetComponent<fingermove>().finish==true) {
			transform.GetComponent<SplineController> ().StartSpline ();
			Finger.GetComponent<fingermove>().finish = false;
		}
	}
}
