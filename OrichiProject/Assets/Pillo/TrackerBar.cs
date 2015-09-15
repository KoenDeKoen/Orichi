using UnityEngine;
using System.Collections;

public class TrackerBar : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;

	public GameObject indicatorTeam1;

	public GameObject team1;

	
	// Update is called once per frame
	void Update () {

		float distanceLevel = (endPoint.position.x + 20) - startPoint.position.x;

		//takes the 
		float curIndicatorTeam1 = team1.transform.position.x / distanceLevel * 100;

		//give indicators there place
		indicatorTeam1.transform.localPosition = new Vector2(curIndicatorTeam1 - 50, -10);
	}
}