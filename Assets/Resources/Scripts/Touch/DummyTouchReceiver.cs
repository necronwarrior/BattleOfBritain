using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTouchReceiver : MonoBehaviour, ITouchReceiver
{

    public float distanceBetweenObjects = 1.0f;

    
    private Vector3 lastPointPosition;

    //Prefab
    private UnityEngine.Object spherePrefab;

    void Start() {

        spherePrefab = Resources.Load("Prefabs/TestSphere");

    }

    public void OnTouchUp(Vector3 point)
    {
        Debug.Log("OnTouchUp called, point: " + point);
    }

    public void OnTouchDown(Vector3 point)
    {
        generatePoint(point);
        Debug.Log("OnTouchDown called, point: " + point);
    }

    public void OnTouchMove(Vector3 point)
    {
        Debug.Log("OnTouchMove called, point: " + point);
        if ((point - lastPointPosition).magnitude >= distanceBetweenObjects)
        {
            generatePoint(point);
        }
    }

    public void OnTouchStay(Vector3 point)
    {
        Debug.Log("OnTouchStay called, point: " + point);
    }

    public void OnTouchExit(Vector3 point)
    {
        Debug.Log("OnTouchExit called, point: " + point);
    }

    private void generatePoint(Vector3 position) {
        GameObject newSphere = (GameObject) Instantiate(spherePrefab, transform);

        newSphere.transform.position = position;

        this.lastPointPosition = position;
    }


}
