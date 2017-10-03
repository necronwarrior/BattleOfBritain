using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform Startpos, Finishpos, Parent;
	public float GoTime;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > GoTime) {
			//GetComponent<SplineController> ().SplineRoot = Parent;
			//GetComponent<SplineController> ().Duration = 8.0f;
		}
	}
}
