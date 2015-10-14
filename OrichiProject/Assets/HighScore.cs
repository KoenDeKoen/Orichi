using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (MechanicController.stepstaken == Custominput.exercises) {
			PlayerPrefs.SetFloat ("highscore", HighScoreMode.timerscore);
			PlayerPrefs.Save ();
		}
	}
}
