﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTouchReciever : MonoBehaviour, ITouchReceiver {

	public GameObject Map;

	public float distanceBetweenObjects = 1.0f;

	public GameObject SplineHolder, HoldingPatternHolder,TrailTouch;

	public float TrailTime;

	private Vector3 lastPointPosition;

	//Prefab
	private UnityEngine.Object TrailPrefab, spherePrefab ;
	public bool doOncePerSpline;

	void Start() {

		TrailPrefab = Resources.Load("Prefabs/Touchtrail");
		spherePrefab = Resources.Load("Prefabs/TestSphere");

		ActivateHoldingPattern ();
	}

	public void OnTouchUp(Vector3 point)
	{
		GetComponent<SplineController> ().AutoClose = false;
		GetComponent<SplineController> ().WrapMode = eWrapMode.ONCE;
		GetComponent<SplineController> ().SplineRoot = SplineHolder;
		GetComponent<SplineController> ().RestartSpline (SplineHolder.transform.childCount/3.0f);
		HoldingPatternHolder.GetComponent<LineRenderer> ().enabled = false;
	}

	public void OnTouchDown(Vector3 point)
	{
		GameObject newSphere = (GameObject) Instantiate(spherePrefab, SplineHolder.transform);
		foreach (Transform child in SplineHolder.transform) {
			GameObject.Destroy(child.gameObject);
		}
		Map.SendMessage("SetSelectedObject", transform.gameObject, SendMessageOptions.DontRequireReceiver);

		ActivateHoldingPattern ();

		if (TrailTouch != null)
			GameObject.Destroy (TrailTouch);

		TrailTouch = (GameObject)Instantiate (TrailPrefab);
		TrailTouch.transform.parent = transform.parent.transform.parent;
		TrailTouch.GetComponent<TrailRenderer> ().time = Mathf.Infinity;
		TrailTouch.GetComponent<TrailRenderer> ().widthMultiplier = 0.02f;
		TrailTouch.transform.position = point;

		TrailTime = 0.0f;

		doOncePerSpline = true;
		//Map.SendMessage ("OnTouchDown", point, SendMessageOptions.DontRequireReceiver);
	}

	public void OnTouchMove(Vector3 point)
	{
		if ((point - lastPointPosition).magnitude >= distanceBetweenObjects)
		{
			generatePoint(point);
		}
		if (TrailTouch!=null)
		TrailTouch.transform.position = point;
	}

	public void OnTouchStay(Vector3 point)
	{
		
	}

	void Update(){
		if (GetComponent<SplineInterpolator> ().isFinished == true 
			&& doOncePerSpline == true) {
			if (TrailTouch != null)
				GameObject.Destroy (TrailTouch);
			ActivateHoldingPattern();

			doOncePerSpline = false;
		}
	}

	public void OnTouchExit(Vector3 point)
	{
	}
		

	private void generatePoint(Vector3 position) {
		GameObject newSphere = (GameObject) Instantiate(spherePrefab, SplineHolder.transform);

		newSphere.transform.position = position;

		this.lastPointPosition = position;
	}

	public void ActivateHoldingPattern()
	{
		HoldingPatternHolder.transform.position = transform.position;
		GetComponent<SplineController> ().AutoClose = true;
		GetComponent<SplineController> ().WrapMode = eWrapMode.LOOP;
		GetComponent<SplineController> ().SplineRoot = HoldingPatternHolder;
		GetComponent<SplineController> ().RestartSpline (3.0f);
		HoldingPatternHolder.GetComponent<LineRenderer> ().enabled = true;
		for (int i = 0; i < 4; i++) {
			HoldingPatternHolder.GetComponent<LineRenderer> ().SetPosition (i, HoldingPatternHolder.transform.GetChild (i).transform.position);
		}
		GetComponent<SplineInterpolator> ().enabled = true;
	}
}