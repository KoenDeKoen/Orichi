using UnityEngine;
using System.Collections;

public class ResetCount : MonoBehaviour {

	public void ResetCounter(){
		MechanicController.stepstaken = 0;
		EvoSystem.evolevel = 0;
		Custominput.exercises = 0;

	}

}
