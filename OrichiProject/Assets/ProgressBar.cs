using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	public Transform startPoint;
	public Transform endPoint;
	
	public GameObject indicator;
	float totalexercises = 50;
	float currentexercises = 25;
	// Update is called once per frame

	void Start() {

	}
	void Update () {
//		float currentexercises = MechanicController.stepstaken;
	//	float totalexercises = Custominput.exercises;

		//lengte tussen begin en eind
		float distanceLevel = (endPoint.position.x ) - startPoint.position.x;
		
		//percentage completion tussen totale exercises
		float curIndicator = currentexercises / totalexercises * 100;
	
		
		//give indicator their place
		indicator.transform.localPosition = new Vector3 (distanceLevel * curIndicator / 100, 0, 0);

	}
}


// de totale exercises 
// je current exercises
// afstand van begin tot eind
// als current exercises 0 is is afstand 0
// als current exercises totale exercises is is afstand 100
//waiting for internet...
//...
//...
//...
//error 404 internet not found