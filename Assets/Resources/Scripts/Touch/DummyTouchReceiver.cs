using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTouchReceiver : MonoBehaviour, ITouchReceiver
{

    public void OnTouchUp(Vector3 point)
    {
        Debug.Log("OnTouchUp called, point: " + point);
    }

    public void OnTouchDown(Vector3 point)
    {
        Debug.Log("OnTouchDown called, point: " + point);
    }

    public void OnTouchMove(Vector3 point)
    {
        Debug.Log("OnTouchMove called, point: " + point);
    }

    public void OnTouchStay(Vector3 point)
    {
        Debug.Log("OnTouchStay called, point: " + point);
    }

    public void OnTouchExit(Vector3 point)
    {
        Debug.Log("OnTouchExit called, point: " + point);
    }


}
