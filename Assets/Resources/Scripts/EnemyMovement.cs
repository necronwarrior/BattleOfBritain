using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform Startpos, Finishpos, Parent;
	public float GoTime, timecount;
	// Use this for initialization
	void Start () {
		transform.position = Startpos.position;
		timecount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > GoTime) {
			transform.position = Vector3.Lerp (Startpos.position, Finishpos.position, timecount);
			timecount += (Time.deltaTime/3.0f);
		}
	}
}
