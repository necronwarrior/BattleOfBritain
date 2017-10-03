using System.Collections;
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


	void Start() {

		TrailPrefab = Resources.Load("Prefabs/Touchtrail");
		spherePrefab = Resources.Load("Prefabs/TestSphere");

		ActivateHoldingPattern ();
	}

	public void OnTouchUp(Vector3 point)
	{
		if (TrailTouch!=null){
			Vector3 TempOld = TrailTouch.transform.position;
			TrailTouch.transform.position = Vector3.Lerp(TempOld, SplineHolder.transform.GetChild(0).transform.position, 2.0f);
		}
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
		TrailTouch.transform.position = point;
		TrailTime = 0.0f;
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
		TrailTime += Time.deltaTime;
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
		GetComponent<SplineController> ().SplineRoot = HoldingPatternHolder;
		GetComponent<SplineController> ().RestartSpline (4.0f);
		HoldingPatternHolder.GetComponent<LineRenderer> ().enabled = true;
		for (int i = 0; i < 4; i++) {
			HoldingPatternHolder.GetComponent<LineRenderer> ().SetPosition (i, HoldingPatternHolder.transform.GetChild (i).transform.position);
		}
		GetComponent<SplineInterpolator> ().enabled = true;
	}
}
