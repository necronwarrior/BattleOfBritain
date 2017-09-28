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

#else
        if (Input.touchCount > 0) {
#endif

            touchListOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchListOld);
			touchList.Clear ();

			foreach (Touch touch in Input.touches) {
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit touchHit;

				if (Physics.Raycast (ray, out touchHit, 1000, touchInputMask)) {

                    /*
                        We can safely send the message to the gameobject since
                        it will just call every method with that name inside every
                        component in the game object. We need to be careful with not naming some
                        other functions like these. :D
                    
                    */
                    GameObject hitObject = touchHit.transform.gameObject;

#if UNITY_EDITOR

                    if (Input.GetMouseButtonDown(0)) {
#else
                    if (touch.phase == TouchPhase.Began) {

#endif
                        hitObject.SendMessage ("OnTouchDown", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}else

#if UNITY_EDITOR
                    if (Input.GetMouseButtonUp(0)) {
#else
                    if (touch.phase == TouchPhase.Ended) {
#endif
                        hitObject.SendMessage ("OnTouchUp", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}else

#if UNITY_EDITOR
                    if (Input.GetMouseButton(0)) {
#else
					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
#endif
                        hitObject.SendMessage ("OnTouchStay", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}else

#if UNITY_EDITOR
                    if (Input.GetMouseButton(1)) {
#else
					if (touch.phase == TouchPhase.Canceled) {
#endif
                        hitObject.SendMessage ("OnTouchExit", touchHit.point, SendMessageOptions.DontRequireReceiver);

					}
				}
			}

			foreach (GameObject G in touchListOld) {
				if (!touchList.Contains (G)) {
					G.SendMessage ("OnTouchExit",touchHit.point, SendMessageOptions.DontRequireReceiver);
				}
			}


		}//End of if(input)


	}//End of Update()

}//End of Class
