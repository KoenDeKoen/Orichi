using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (MechanicController.stepstaken == Custominput.exercises + 1) {
			Application.LoadLevel("MainMenu");
		}
	}
}
