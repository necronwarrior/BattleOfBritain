using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantTimer : MonoBehaviour {

	public float LevelTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LevelTimer = Time.timeSinceLevelLoad;
	}
}
