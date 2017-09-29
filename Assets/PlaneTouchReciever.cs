using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTouchReciever : MonoBehaviour, ITouchReceiver {

	public GameObject Map;

	public float distanceBetweenObjects = 1.0f;

	public GameObject SplineHolder, HoldingPatternHolder;

	private Vector3 lastPointPosition;

	//Prefab
	private UnityEngine.Object spherePrefab;

	void Start() {

		spherePrefab = Resources.Load("Prefabs/TestSphere");
		HoldingPatternHolder.transform.position = transform.position;
		GetComponent<SplineController> ().SplineRoot = HoldingPatternHolder;
		GetComponent<SplineController> ().RestartSpline (4.0f);
	}

	public void OnTouchUp(Vector3 point)
	{
		GetComponent<SplineController> ().SplineRoot = SplineHolder;
		GetComponent<SplineController> ().RestartSpline (SplineHolder.transform.childCount/3.0f);
	}

	public void OnTouchDown(Vector3 point)
	{
		foreach (Transform child in SplineHolder.transform) {
			GameObject.Destroy(child.gameObject);
		}
		Map.SendMessage("SetSelectedObject", transform.gameObject, SendMessageOptions.DontRequireReceiver);
		HoldingPatternHolder.transform.position = transform.position;
		GetComponent<SplineController> ().SplineRoot = HoldingPatternHolder;
		GetComponent<SplineController> ().RestartSpline (4.0f);
		//Map.SendMessage ("OnTouchDown", point, SendMessageOptions.DontRequireReceiver);
	}

	public void OnTouchMove(Vector3 point)
	{
		if ((point - lastPointPosition).magnitude >= distanceBetweenObjects)
		{
			generatePoint(point);
		}
	}

	public void OnTouchStay(Vector3 point)
	{
		
	}

	public void OnTouchExit(Vector3 point)
	{
	}

	private void generatePoint(Vector3 position) {
		GameObject newSphere = (GameObject) Instantiate(spherePrefab, SplineHolder.transform);

		newSphere.transform.position = position;

		this.lastPointPosition = position;
	}

}
