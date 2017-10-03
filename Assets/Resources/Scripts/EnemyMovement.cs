using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform Startpos, Finishpos;
	public float GoTime;
	// Use this for initialization
	void Start () {
		transform.position = Startpos.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > GoTime) {
			GetComponent<SplineInterpolator> ().enabled;
		}
	}
}
