using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squadfollowline : MonoBehaviour {

	public LineRenderer LR;
	public SplineController SC;

	Vector3[] LinePoints;

	// Use this for initialization
	void Start () {
		LR = GetComponent<LineRenderer> ();
		SC = GetComponent<SplineController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Aeroplane>().Finger.GetComponent<fingermove> ().finish == true) {
			ActivateLine ();
		}
	}

	void GetLinePositions(){
		for (int i = 0; i < SC.mTransforms.Length; i++) {
			LinePoints [i] = SC.mTransforms [i].position; 
		}
		LR.SetPositions(LinePoints);
	}

	public void ActivateLine(){

		GetLinePositions ();

	}
}
