using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour {

	bool InUse;
	GameObject Empty;

	// Use this for initialization
	void Start () {
		Empty = new GameObject ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (!InUse) {
			Instantiate (Empty);
		} 
	}
}
