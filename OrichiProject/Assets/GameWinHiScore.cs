using UnityEngine;
using System.Collections;

public class GameWinHiScore : MonoBehaviour {
	public Shutter shutter;
	private bool done;


	void Start()
	{
		done = true;
	}
	// Update is called once per frame
	void Update () {
	if (MechanicControllerHiScore.stepstaken == 50 && done) {
	
			shutter.loadSceneAfterClosing("scorescreen");
			done = false;
		}
	}


}
