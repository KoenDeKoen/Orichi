using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {
	public Shutter shutter;
	public SpawnGroundAndProps sgap;
	private bool lolk;
	// Use this for initialization
	void Start () {
		lolk=false;
	}
	
	// Update is called once per frame
	void Update () {
	if (MechanicController.stepstaken == Custominput.exercises + 1) {
			sgap.arrive = true;
		}

		if(sgap.time <= 0 && lolk == false){
			shutter.loadSceneAfterClosing("MainMenu");
			lolk = true;
		}
	}
}
