using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject> ();
	private GameObject[] touchListOld;
	private RaycastHit touchHit;

	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR

		if (Input.GetMouseButton(0) ||
			Input.GetMouseButtonDown(0)||
			Input.GetMouseButtonUp(0)) {

			touchListOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchListOld);
			touchList.Clear ();

			foreach (Touch touch in Input.touches) {
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit touchHit;

				if (Physics.Raycast (ray, out touchHit, 1000, touchInputMask)) {
					GameObject hitObject = touchHit.transform.gameObject;
					if (Input.GetMouseButtonDown(0)) {
						hitObject.SendMessage ("OnTouchDown", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
					if (Input.GetMouseButtonUp(0)) {
						hitObject.SendMessage ("OnTouchUp", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
					if ((Input.GetMouseButton(0)) {
						hitObject.SendMessage ("OnTouchStay", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
					if (touch.phase == TouchPhase.Canceled) {
						hitObject.SendMessage ("OnTouchExit", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
				}
			}

			foreach (GameObject G in touchListOld) {
				if (!touchList.Contains (G)) {
					G.SendMessage ("OnTouchExit",touchHit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

		#endif

		if (Input.touchCount > 0) {

			touchListOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchListOld);
			touchList.Clear ();

			foreach (Touch touch in Input.touches) {
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit touchHit;

				if (Physics.Raycast (ray, out touchHit, 1000, touchInputMask)) {
					GameObject hitObject = touchHit.transform.gameObject;
					if (touch.phase == TouchPhase.Began) {
						hitObject.SendMessage ("OnTouchDown", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
					if (touch.phase == TouchPhase.Ended) {
						hitObject.SendMessage ("OnTouchUp", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
						hitObject.SendMessage ("OnTouchStay", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
					if (touch.phase == TouchPhase.Canceled) {
						hitObject.SendMessage ("OnTouchExit", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
				}
			}

			foreach (GameObject G in touchListOld) {
				if (!touchList.Contains (G)) {
					G.SendMessage ("OnTouchExit",touchHit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
