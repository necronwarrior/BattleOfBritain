using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPadManager : MonoBehaviour, ITouchReceiver {


	BoxCollider collider;
	ITouchReceiver touchReceiver;


	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	private GameObject selectedPlane;

	public void setSelectedPlane(GameObject gameObject){
	
		selectedPlane = gameObject;
		touchReceiver = selectedPlane.GetComponent<ITouchReceiver> ();

	}

	public void OnTouchUp(Vector3 point)
	{
		Debug.Log ("Calling this shit");
		touchReceiver.OnTouchUp (point);

	}

	public void OnTouchDown(Vector3 point)
	{
	}

	public void OnTouchMove(Vector3 point)
	{

		touchReceiver.OnTouchMove (point);

	}

	public void OnTouchStay(Vector3 point)
	{

		touchReceiver.OnTouchStay (point);

	}

	public void OnTouchExit(Vector3 point)
	{

		touchReceiver.OnTouchExit (point);

	}


}
