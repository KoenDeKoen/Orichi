using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {
	public Shutter shutter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (MechanicController.stepstaken == Custominput.exercises + 1) {
			shutter.loadSceneAfterClosing("MainMenu");
		}
	}
}
