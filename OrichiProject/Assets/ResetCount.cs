using UnityEngine;
using System.Collections;

public class ResetCount : MonoBehaviour {

	public void ResetCounter(){
		MechanicControllerHiScore.stepstaken = 0;
		MechanicController.stepstaken = 0;
		EvoSystemHiScore.evolevel = 0;
		Custominput.exercises = 0;

	}

}
