using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRecieveTest : MonoBehaviour, ITouchReceiver {

	public Transform TempParent;
	Object HoldingPattern;

	void Start (){
		HoldingPattern = Resources.Load ("Aeroplanes/HoldingPatterns");
	}

	void ITouchReceiver.OnTouchDown(Vector3 point){
		//Delete all children
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}
		//Instantiate holding pattern
		Instantiate(HoldingPattern,transform);
		//Begin creating splinepath
		Instantiate((Object)new GameObject("Start"), TempParent);
	}

	void ITouchReceiver.OnTouchUp(Vector3 point){
	
	}

	void ITouchReceiver.OnTouchMove(Vector3 point){

	}

	void ITouchReceiver.OnTouchStay(Vector3 point){

	}

	void ITouchReceiver.OnTouchExit(Vector3 point){

	}
}
